using Core.Cache;
using Framework.Utility;
using Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Common
{
    public class AdminCookieContext : CookieContext
    {
        public static AdminCookieContext Current
        {
            get
            {
                return CacheHelper.GetItem<AdminCookieContext>();
            }
        }

        public override string KeyPrefix
        {
            get
            {
                return Fetch.ServerDomain + "_AdminContext_";
            }
        }
    }
}