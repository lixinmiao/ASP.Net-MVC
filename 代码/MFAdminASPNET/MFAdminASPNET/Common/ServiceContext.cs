using Core.Cache;
using MFAdminASPNET.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Common
{
    public class ServiceContext
    {
        public static ServiceContext Current
        {
            get
            {
                return CacheHelper.GetItem<ServiceContext>("ServiceContext", () => new ServiceContext());
            }
        }

        public IAccountService AccountService
        {
            get
            {
                return new AccountService();
            }
        }
    }
}