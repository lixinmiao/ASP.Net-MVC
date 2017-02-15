using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Models
{
    [Table("role")]
    public class Role:ModelBase
    {
       

        [Required(ErrorMessage = "角色名不能为空")]
        [Column("name")]
        public string Name { get; set; }

        [Column("info")]
        public string Info { get; set; }

        [Column("users")]
        public virtual List<User> Users { get; set; }

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
}