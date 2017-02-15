using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Models
{
    [Table("media")]
    public class Media:ModelBase
    {
      
    

        [Column("mediaName")]
        [Display(Name = "名字")]
        [Required(ErrorMessage = "名字不能为空")]
        [StringLength(160)]
        public String MediaName { get; set; }


        [Column("isActive")]
        [Display(Name = "激活")]
        public bool IsActive { get; set; }


    }
}