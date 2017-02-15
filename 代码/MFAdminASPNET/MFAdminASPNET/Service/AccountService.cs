using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MFAdminASPNET.Models;
using Framework.Utility;
using MFAdminASPNET.Common;
using MFAdminASPNET.DAO;
using Core.Cache;
using Core.Config;
using Framework.Contracts;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace MFAdminASPNET.Service
{
    public class AccountService : IAccountService
    {
        private readonly int _UserLoginTimeoutMinutes = CachedConfigContext.Current.SystemConfig.UserLoginTimeoutMinutes;
        private readonly string _LoginInfoKeyFormat = "LoginInfo_{0}";


        public LoginInfo GetLoginInfo(Guid token)
        {
            return CacheHelper.Get<LoginInfo>(string.Format(_LoginInfoKeyFormat, token), () =>
            {
                using (var dbContext = new DaoBase())
                {
                    //如果有超时的，启动超时处理
                    var timeoutList = dbContext.FindAll<LoginInfo>(p => DbFunctions.DiffMinutes(DateTime.Now, p.LastAccessTime) > _UserLoginTimeoutMinutes);
                    if (timeoutList.Count > 0)
                    {
                        foreach (var li in timeoutList)
                            dbContext.LoginInfoes.Remove(li);
                    }

                    dbContext.SaveChanges();


                    var loginInfo = dbContext.FindAll<LoginInfo>(l => l.LoginToken == token).FirstOrDefault();
                    if (loginInfo != null)
                    {
                        loginInfo.LastAccessTime = DateTime.Now;
                        dbContext.Update<LoginInfo>(loginInfo);
                    }

                    return loginInfo;
                }
            });
        }

        public bool CheckVerifyCode(string verifyCodeText, Guid guid)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(List<int> ids)
        {
            throw new NotImplementedException();
        }


        public Role GetRole(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetRoleList(RoleRequest request = null)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            using (var dbContext = new DaoBase())
            {
                return dbContext.Users.Include("Roles").Where(u => u.Id == id).SingleOrDefault();
            }
        }

        public IEnumerable<User> GetUserList(UserRequest request = null)
        {
            request = request ?? new UserRequest();

            using (var dbContext = new DaoBase())
            {
                IQueryable<User> users = dbContext.Users.Include("Roles");

                if (!string.IsNullOrEmpty(request.LoginName))
                    users = users.Where(u => u.LoginName.Contains(request.LoginName));

                if (!string.IsNullOrEmpty(request.Mobile))
                    users = users.Where(u => u.Mobile.Contains(request.Mobile));

                return users.OrderByDescending(u => u.Id).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public LoginInfo Login(string loginName, string password)
        {
            LoginInfo loginInfo = null;

            password = Encrypt.MD5(password);
            loginName = loginName.Trim();

            using (var dbContext = new DaoBase())
            {
                var user = dbContext.Users.Include("Roles").Where(u => u.LoginName == loginName && u.Password == password && u.IsActive).FirstOrDefault();
                if (user != null)
                {
                    var ip = Fetch.UserIp;
                    loginInfo = dbContext.FindAll<LoginInfo>(p => p.LoginName == loginName && p.ClientIP == ip).FirstOrDefault();
                    if (loginInfo != null)
                    {
                        loginInfo.LastAccessTime = DateTime.Now;
                    }
                    else
                    {
                        loginInfo = new LoginInfo(user.Id, user.LoginName);
                        loginInfo.ClientIP = ip;
                        loginInfo.BusinessPermissionList = user.BusinessPermissionList;
                        dbContext.Insert<LoginInfo>(loginInfo);
                    }
                }
            }

            return loginInfo;
        }

        public void Logout(Guid token)
        {
            using (var dbContext = new DaoBase())
            {
                var loginInfo = dbContext.FindAll<LoginInfo>(l => l.LoginToken == token).FirstOrDefault();
                if (loginInfo != null)
                {
                    dbContext.Delete<LoginInfo>(loginInfo);
                }
            }

            CacheHelper.Remove(string.Format(_LoginInfoKeyFormat, token));
        }

        public void ModifyPwd(User user)
        {
            throw new NotImplementedException();
        }

        public void SaveRole(Role role)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public Guid SaveVerifyCode(string verifyCodeText)
        {
            throw new NotImplementedException();
        }
    }
}