using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class MagicBlock
    {
        public int MagicBlockID { get; set; }
        public string BlockName { get; set; }
        public virtual ICollection<MagicSet> SetsInBlock { get; set; }
    }
}