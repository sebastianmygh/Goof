using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Goof_.Models
{
    public class Login
    {
        public String Usuario { get; set; }
        public String Password { get; set; }
    }

    public class LoginUsersDb : DbContext
    {
			
    }

    
}