using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.DataBase
{
    public class UserInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int InfoUserID { get; set; }
        public string InfoBalance { get; set; }
        public string InfoUserName { get; set; }
        public DateTime InfoRegisterDate { get; set; }
        public virtual User User { get; set; }
    }
}