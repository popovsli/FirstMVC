using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public class UserDetails
    {
        [StringLength(15, MinimumLength = 2, ErrorMessage = "UserName length should be between 2 and 7")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}