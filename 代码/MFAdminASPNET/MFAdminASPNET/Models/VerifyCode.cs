using Framework.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Models
{
    [Serializable]
    [Table("verifyCode")]
    public class VerifyCode :ModelBase
    {
        [Column("guid")]
        public Guid Guid { get; set; }
        [Column("verifyText")]
        public string VerifyText { get; set; }
    }
}