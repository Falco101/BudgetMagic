using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class Card
    {
        public int CardID { get; set; }
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public int CMC { get; set; }
        public string Type { get; set; }
        public string OracleText { get; set; }
        public int Power { get; set; }
        public int Toughness { get; set; }
        public string Identity { get; set; }
    }
}