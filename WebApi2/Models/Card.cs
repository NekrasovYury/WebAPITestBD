using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2.Models
{
    public class Card
    {
        public int CardID { get; set; }
        public int CardValue { get; set; }
        public int OwnreID { get; set; }
    }
}