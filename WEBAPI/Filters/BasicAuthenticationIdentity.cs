using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
namespace WEBAPI.Filters
{
    public class BasicAuthenticationIdentity :GenericIdentity
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }

        public BasicAuthenticationIdentity (string userName,string password)
            : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
        }

    }
        
}
