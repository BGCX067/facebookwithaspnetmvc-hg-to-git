using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.Business.Domain.Friendship;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Business.Domain.Facade.Friendship
{
    /// <summary>
    /// This class provide services to manage facebook friendship.
    /// </summary>
    /// <remarks>
    /// NOTE:
    /// That in this class services take efect a pipeline of actions, calls to repositories, saving changes ... that from my point of view are not suitable implement
    /// inside of the User class.
    /// </remarks>
    public class FriendshipManagementService : IFriendshipManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationFactory _notificationFactory;
        private readonly IDateTimeService _dateTimeService;

        public FriendshipManagementService(IUnitOfWork unitOfWork, INotificationFactory notificationFactory, IDateTimeService dateTimeService)
        {
            _unitOfWork = unitOfWork;
            _notificationFactory = notificationFactory;
            _dateTimeService = dateTimeService;
        }

        /// <summary>
        /// Send a friendship request from an user to another one.
        /// </summary>
        /// <param name="sender">The user that sends the request.</param>
        /// <param name="reciver">The user that receives the request.</param>
        public void SendRequest(User sender, User reciver)
        {
            ContractUtil.NotNull(sender);
            ContractUtil.NotNull(reciver);

            var requestRepository = _unitOfWork.FriendshipRequests;

            // Checking that the request isn't already sent ...
            if (requestRepository.FindSentFrom(sender).Any(request => reciver.Id.Equals(request.Reciver.Id)))
                return;

            var notificationRepository = _unitOfWork.Notifications;

            var newRequest = new FriendshipRequest(sender, reciver, _dateTimeService.Now());
            var newNotification = _notificationFactory.CreateFriendshipRequest(sender, reciver);

            requestRepository.Add(newRequest);
            notificationRepository.Add(newNotification);

            _unitOfWork.Commit();
        }

        /// <summary>
        /// Accept a friendship request sent to an user by another one.
        /// </summary>
        /// <param name="sender">The user that sends the request.</param>
        /// <param name="reciver">The user that receives the request and optionaly accept it.</param>
        public void AcceptRequest(User sender, User reciver)
        {
            ContractUtil.NotNull(sender);
            ContractUtil.NotNull(reciver);

            var requestRepository = _unitOfWork.FriendshipRequests;
            var request = requestRepository.FindSentFrom(sender).FirstOrDefault(friendshipRequest => reciver.Id.Equals(friendshipRequest.Reciver.Id));

            // Checking that the request is already sent.
            if (Equals(request, null))
                throw new InvalidOperationException();

            var notificationRepository = _unitOfWork.Notifications;
            var userRepository = _unitOfWork.Users;

            var senderInContext = userRepository.FindById(sender.Id); // NOTE: Rethink and Analize that
            var reciverInContext = userRepository.FindById(reciver.Id);
            var newNotification = _notificationFactory.CreateFriendshipAccepted(sender, reciver);

            senderInContext.AddFriend(reciverInContext);
            reciverInContext.AddFriend(senderInContext);
            notificationRepository.Add(newNotification);
            request.State = FriendshipRequestState.Accepted;

            _unitOfWork.Commit();
        }

        /// <summary>
        /// Find friends to a given user.
        /// </summary>
        /// <param name="user">An user.</param>
        /// <returns>possibles friends for <paramref name="user"/></returns>
        public IEnumerable<User> GetPossiblesFriends(User user)
        {
            ContractUtil.NotNull(user);
            var users = _unitOfWork.Users;
            var friendshipRequests = _unitOfWork.FriendshipRequests;

            var filter = new Func<User, bool>(x =>
                         // no already friends
                         !user.Friends.Contains(x)
                         // no the same user  
                         && !user.Equals(x)
                         // no already requested users  
                         && !friendshipRequests.FindSentTo(x).Any(request => request.Sender.Id.Equals(user.Id))
                         // no user that already sent a request
                         && !friendshipRequests.FindSentFrom(x).Any(request => request.Reciver.Id.Equals(user.Id)));

            return user.Friends
                       .SelectMany(other => other.Friends)
                       .Where(filter)  
                       .ToOccurrenceTable()
                       .OrderByDescending(pair => pair.Value)
                       .Select(pair => pair.Key)
                       .Concat(users.All().Where(filter))
                       .Distinct();
        }

        public IEnumerable<User> GetResquestsTo(User user)
        {
            var requests = _unitOfWork.FriendshipRequests;
            return requests.FindSentTo(user).Select(request => request.Sender);
        }

        public IEnumerable<User> GetUsersWithFriendshipStatus(User user, FriendshipStatus status)
        {
            throw new NotImplementedException();
        }

        public FriendshipStatus GetFriendshipStatus(User current, User other)
        {
            ContractUtil.NotNull(current);
            ContractUtil.NotNull(other);
            if(current.Equals(other))
                throw new Exception();

            if(current.Friends.Contains(other))return FriendshipStatus.AlreadyFriends;
            if(_unitOfWork.FriendshipRequests.FindSentTo(other).Any(request => request.Sender.Id.Equals(current.Id)))return FriendshipStatus.RequestSentByYou;
            if(_unitOfWork.FriendshipRequests.FindSentFrom(other).Any(request => request.Reciver.Id.Equals(current.Id))) return FriendshipStatus.RequestSentByOther;
            return FriendshipStatus.NoRelation;
        }


        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
    }
}