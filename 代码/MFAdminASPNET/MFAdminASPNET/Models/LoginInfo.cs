using Framework.Contracts;
using Framework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Models
{

    [Serializable]
    [Table("loginInfo")]
    public class LoginInfo:ModelBase
    {
        public LoginInfo()
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid();
        }

        public LoginInfo(long userID, string loginName)
        {
            LastAccessTime = DateTime.Now;
            LoginToken = Guid.NewGuid();

            UserID = userID;
            LoginName = loginName;
        }

        [Column("loginToken")]
        public Guid LoginToken { get; set; }
        [Column("lastAccessTime")]
        public DateTime LastAccessTime { get; set; }
        [Column("userID")]
        public long UserID { get; set; }
        [Column("loginName")]
        public string LoginName { get; set; }
        [Column("clientIP")]
        public string ClientIP { get; set; }
        [Column("enumLoginAccountType")]
        public EnumLoginAccountType EnumLoginAccountType { get; set; }
        [Column("businessPermissionString")]

        public string BusinessPermissionString { get; set; }

        [NotMapped]
        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                if (string.IsNullOrEmpty(BusinessPermissionString))
                    return new List<EnumBusinessPermission>();
                else
                    return BusinessPermissionString.Split(",".ToCharArray()).Select(p => int.Parse(p)).Cast<EnumBusinessPermission>().ToList();
            }
            set
            {
                BusinessPermissionString = string.Join(",", value.Select(p => (int)p));
            }
        }
    }

    [Flags]
    public enum EnumLoginAccountType
    {
        [EnumTitle("[无]", IsDisplay = false)]
        Guest = 0,
        /// <summary>
        /// 管理员
        /// </summary>
        [EnumTitle("管理员")]
        Administrator = 1,
    }
}
