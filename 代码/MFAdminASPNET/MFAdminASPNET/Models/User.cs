﻿using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Models
{
    [Table("user")]
    public class User:ModelBase
    {
      

        /// <summary>
        /// 登录名
        /// </summary>
        [Column("loginName")]
        [Required(ErrorMessage = "登录名不能为空")]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码，使用MD5加密
        /// </summary>
        [Column("password")]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("mobile")]
        [RegularExpression(@"^[1-9]{1}\d{10}$", ErrorMessage = "不是有效的手机号码")]
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "电子邮件地址无效")]
        public string Email { get; set; }

        [Column("isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        [Column("roles")]
        public virtual List<Role> Roles { get; set; }

        [NotMapped]
        public List<int> RoleIds { get; set; }

        [NotMapped]
        public string NewPassword { get; set; }

        [NotMapped]
        public List<EnumBusinessPermission> BusinessPermissionList
        {
            get
            {
                var permissions = new List<EnumBusinessPermission>();

                foreach (var role in Roles)
                {
                    permissions.AddRange(role.BusinessPermissionList);
                }

                return permissions.Distinct().ToList();
            }
        }
    }
}
