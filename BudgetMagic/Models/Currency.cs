using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class Currency
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyShortName { get; set; }
        public char CurrencySymbol { get; set; }
        public string CurrencyFormatRegex { get; set; }
    }
}