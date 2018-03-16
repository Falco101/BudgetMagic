using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class MagicSet
    {
        public int MagicSetID { get; set; }
        public string SetName { get; set; }
        public string SetUri { get; set; }
        public string SetSearchUri { get; set; }
        public string ScryfallSetUri { get; set; }
        public virtual MagicBlock SetBlock { get; set; }
    }
}