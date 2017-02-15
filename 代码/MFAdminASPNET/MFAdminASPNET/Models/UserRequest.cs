using Framework.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Models
{
    public class UserRequest:Request
    {
        public String LoginName { get; set; }

        public String Mobile { get; set; }
    }
}