using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Images;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;
using Facebook.Presentation.Web.ViewModels;
using Facebook.Presentation.Web.ViewModels.Messages;
using Facebook.Presentation.Web.ViewModels.Notifications;
using Facebook.Presentation.Web.ViewModels.Posts;
using Facebook.Presentation.Web.ViewModels.User;

namespace Facebook.Presentation.Web.Utils.AutoMapper
{
    public class FacebookAutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();


            // TODO: Use formatter in order of reuse code ...
            CreateMap<Message, MessageViewModel>();

            CreateMap<Image, ImageViewModel>().ConvertUsing(image => new ImageViewModel
                                                                         {
                                                                             ImgId = image.Id,
                                                                             Description = image.Description
                                                                         });

            CreateMap<dynamic, UserViewModel>().ConvertUsing(d => new UserViewModel
                                                                      {
                                                                          FacebookId = d.User.Keyword,
                                                                          Id = d.User.Id,
                                                                          Name = d.User.FirstName + " " + d.User.LastName,
                                                                          FriendshipStatus = d.FriendshipStatus,
                                                                          Photo = Mapper.Map<Image, ImageViewModel>(d.User.Photo)
                                                                      });

            CreateMap<User, UserViewModel>().ConvertUsing(account => new UserViewModel
                                                                                {
                                                                                    FacebookId = account.Keyword,
                                                                                    Id = account.Id,
                                                                                    Name = account.FirstName + " " + account.LastName,
                                                                                    Photo = Mapper.Map<Image, ImageViewModel>(account.Photo),
                                                                                });

            CreateMap<User, UserProfileViewModel>().ConvertUsing(user => new UserProfileViewModel
                                                                             {
                                                                                 State = user.Profile.ContactInformation.Address.State,
                                                                                 AboutMe = user.Profile.PersonalInformation.AboutMe,
                                                                                 City = user.Profile.ContactInformation.Address.City,
                                                                                 BirthDay = user.Profile.PersonalInformation.BirthDay,
                                                                                 HomeTown = user.Profile.PersonalInformation.HomeTown,
                                                                                 EMail = user.Profile.ContactInformation.EMail,
                                                                                 EMailOnlyForFriends = user.Profile.ContactInformation.EMailOnlyForFriends,
                                                                                 Country = user.Profile.ContactInformation.Address.Country,
                                                                                 AddressInfo = user.Profile.ContactInformation.Address.AddressInfo,
                                                                                 AddressOnlyForFriends = user.Profile.ContactInformation.AddressOnlyForFriends,
                                                                                 InterestedInMen = user.Profile.PersonalInformation.InterestedInMen,
                                                                                 InterestedInWomen = user.Profile.PersonalInformation.InterestedInWomen,
                                                                                 LookingForFriendship = user.Profile.PersonalInformation.LookingForFriendship,
                                                                                 LookingForRelationship = user.Profile.PersonalInformation.LookingForRelationship,
                                                                                 MobileNumber = user.Profile.ContactInformation.MobileNumber,
                                                                                 MobileNumberOnlyForFriends = user.Profile.ContactInformation.MobileNumberOnlyForFriends,
                                                                                 
                                                                             });

            CreateMap<Post, PostViewModel>().ConvertUsing(post => new PostViewModel
                                                                      {
                                                                          Author = new UserViewModel
                                                                                           {
                                                                                               Name = post.Author.FirstName + " " + post.Author.LastName,
                                                                                               Id = post.Author.Id,
                                                                                               FacebookId = post.Author.Keyword
                                                                                           },
                                                                          OwnerId = post.Owner.Id,
                                                                          Text = post.Text,
                                                                          Comments = new CommentCollectionViewModel
                                                                                         {
                                                                                             OwnerId = post.Id,
                                                                                             Comments = post.Comments.Select(Mapper.Map<Comment, CommentViewModel>).ToList()
                                                                                         }
                                                                      });

            CreateMap<Comment, CommentViewModel>().ConvertUsing(comment => new CommentViewModel
                                                                               {
                                                                                   Author = new UserViewModel
                                                                                                {
                                                                                                    Name = comment.Author.FirstName + " " + comment.Author.LastName,
                                                                                                    Id = comment.Author.Id,
                                                                                                    FacebookId = comment.Author.Keyword
                                                                                                },
                                                                                   Text = comment.Text
                                                                               });

            CreateMap<Post, PostCreationViewModel>();

            CreateMap<Notification, NotificationViewModel>();

            CreateMap<dynamic, PostCollectionViewModel>().ConvertUsing(d => new PostCollectionViewModel
                                                                                {
                                                                                    Posts = ((IEnumerable<Post>) d.Posts).Select(Mapper.Map<Post, PostViewModel>),
                                                                                    OwnerId = d.OwnerId,
                                                                                    Page = d.Page,
                                                                                    Count = d.Count
                                                                                });

            CreateMap<IList<Notification>, IList<NotificationViewModel>>().ConvertUsing(list => list.Select(Mapper.Map<Notification, NotificationViewModel>).ToList());

            CreateMap<IList<Message>, IList<MessageViewModel>>().ConvertUsing(list => list.Select(Mapper.Map<Message, MessageViewModel>).ToList());

            CreateMap<IList<User>, IList<UserViewModel>>().ConvertUsing(list => list.Select(Mapper.Map<User, UserViewModel>).ToList());
            CreateMap<IList<dynamic>, IList<UserViewModel>>().ConvertUsing(list => list.Select(Mapper.Map<dynamic, UserViewModel>).ToList());
        }
    }
}