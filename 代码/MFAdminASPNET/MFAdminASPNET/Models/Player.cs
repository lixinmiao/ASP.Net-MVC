using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MFAdminASPNET.Models
{
    [Table("player")]
    public class Player
    {
        [Key]
        [Column("playerId")]
        public int PlayerId { get; set; }

        [Column("playerName")]
        public String PlayerName { get; set; }
    }
}