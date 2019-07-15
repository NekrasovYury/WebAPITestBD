using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.DataBase
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; } 
    }
}