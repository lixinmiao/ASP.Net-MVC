using System;

namespace Framework.Web
{
    public interface IAuthCookie
    {
        int UserExpiresHours { get; set; }
        
        string UserName { get; set; }

        long UserId { get; set; }

        Guid UserToken { get; set; }

        string VerifyCode { get; set; }

        int LoginErrorTimes { get; set; }

        bool IsNeedVerifyCode { get; }
    }
}
