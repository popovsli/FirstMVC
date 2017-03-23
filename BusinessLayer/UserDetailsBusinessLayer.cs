using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLayer
{
    public class UserDetailsBusinessLayer
    {
        public UserStatus GetUserValidity(UserDetails userDetails)
        {
            if (userDetails.UserName == "admin" && userDetails.Password == "admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (userDetails.UserName == "popovsli" && userDetails.Password == "popovsli")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
    }
}