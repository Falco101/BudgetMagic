using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class MagicSet
    {
        public int SetID { get; set; }
        public string SetName { get; set; }
        public virtual MagicBlock SetBlock { get; set; }
    }
}