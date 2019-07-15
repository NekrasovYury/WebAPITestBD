using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI3.Models
{
    public class Cards
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public int NumberCard { get; set; }
        public decimal CardMoney { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        // Navigation property
        public User User { get; set; }
    }
}