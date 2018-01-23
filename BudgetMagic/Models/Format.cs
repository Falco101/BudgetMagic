using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class Format
    {
        public int FormatID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Rules Rules { get; set; }
    }
}