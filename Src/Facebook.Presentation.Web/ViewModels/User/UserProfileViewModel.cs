using System;
using System.Dynamic;
using System.IO;
using System.Web;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Images;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Presentation.Web.ViewModels.User
{
    public class UserProfileViewModel
    {
        #region Image


        public HttpPostedFileBase Image { get; set; }


        #endregion


        #region Personal Information



        public virtual bool? InterestedInMen { get; set; }


        public virtual bool? InterestedInWomen { get; set; }


        public virtual bool? LookingForFriendship { get; set; }


        public virtual bool? LookingForRelationship { get; set; }


        public virtual DateTime? BirthDay { get; set; }


        public virtual string HomeTown { get; set; }


        public virtual string AboutMe { get; set; }


        #endregion


        #region Contact Information




        public virtual string EMail { get; set; }


        public virtual bool? EMailOnlyForFriends { get; set; }


        public virtual int? MobileNumber { get; set; }


        public virtual bool? MobileNumberOnlyForFriends { get; set; }


        public string AddressInfo { get; set; }


        public virtual string City { get; set; }


        public virtual string State { get; set; }


        public virtual string Country { get; set; }


        public virtual bool? AddressOnlyForFriends { get; set; }


        #endregion


        public void Update(Business.Domain.Users.User user)
        {
            ContractUtil.NotNull(user);

            if(Image != null)
            {
                var format = Path.GetExtension(Image.FileName);
                var data = new byte[Image.InputStream.Length];
                Image.InputStream.Read(data, 0, data.Length);

                var img = new Image(data, format, "");
                user.SetPhoto(img);
            }

            if (State != user.Profile.ContactInformation.Address.State)
                user.Profile.ContactInformation.Address.State = State;

            if (AboutMe != user.Profile.PersonalInformation.AboutMe)
                user.Profile.PersonalInformation.AboutMe = AboutMe;

            if (City != user.Profile.ContactInformation.Address.City)
                user.Profile.ContactInformation.Address.City = City;

            if (BirthDay != user.Profile.PersonalInformation.BirthDay)
                user.Profile.PersonalInformation.BirthDay = BirthDay;

            if (HomeTown != user.Profile.PersonalInformation.HomeTown)
                user.Profile.PersonalInformation.HomeTown = HomeTown;

            if (EMail != user.Profile.ContactInformation.EMail)
                user.Profile.ContactInformation.EMail = EMail;

            if (EMailOnlyForFriends != user.Profile.ContactInformation.EMailOnlyForFriends)
                user.Profile.ContactInformation.EMailOnlyForFriends = EMailOnlyForFriends;

            if (Country != user.Profile.ContactInformation.Address.Country)
                user.Profile.ContactInformation.Address.Country = Country;

            if (AddressInfo != user.Profile.ContactInformation.Address.AddressInfo)
                user.Profile.ContactInformation.Address.AddressInfo = AddressInfo;

            if (AddressOnlyForFriends != user.Profile.ContactInformation.AddressOnlyForFriends)
                user.Profile.ContactInformation.AddressOnlyForFriends = AddressOnlyForFriends;

            if (InterestedInMen != user.Profile.PersonalInformation.InterestedInMen)
                user.Profile.PersonalInformation.InterestedInMen = InterestedInMen;

            if (InterestedInWomen != user.Profile.PersonalInformation.InterestedInWomen)
                user.Profile.PersonalInformation.InterestedInWomen = InterestedInWomen;

            if (LookingForFriendship != user.Profile.PersonalInformation.LookingForFriendship)
                user.Profile.PersonalInformation.LookingForFriendship = LookingForFriendship;

            if (LookingForRelationship != user.Profile.PersonalInformation.LookingForRelationship)
                user.Profile.PersonalInformation.LookingForRelationship = LookingForRelationship;

            if (MobileNumber != user.Profile.ContactInformation.MobileNumber)
                user.Profile.ContactInformation.MobileNumber = MobileNumber;

            if (MobileNumberOnlyForFriends != user.Profile.ContactInformation.MobileNumberOnlyForFriends)
                user.Profile.ContactInformation.MobileNumberOnlyForFriends = MobileNumberOnlyForFriends;
        }
    }
}