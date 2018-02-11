using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class Format
    {
        public int FormatID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int MainboardCardLimit { get; set; }
        public int MainboardCardMinimum { get; set; }
        public int SideboardCardLimit { get; set; }
        [Required]
        public bool HasCommanders { get; set; } = false;
        [Required]
        public bool IsSignleton { get; set; } = false;
        public int MinCMC { get; set; }
        public int MaxCMC { get; set; }
        public int MaxUncommonCards { get; set; }
        public int MaxRareCards { get; set; }
        public int MaxMythicCards { get; set; }
        public virtual Currency Currency { get; set; }
        public double MaxCardPrice { get; set; }
        public double MaxCommanderPrice { get; set; }
        public virtual ICollection<MagicSet> SetRestriction { get; set; }
        public virtual ICollection<MagicBlock> BlockRestrictions { get; set; }
        public virtual ICollection<Card> BanList { get; set; }
    }
}