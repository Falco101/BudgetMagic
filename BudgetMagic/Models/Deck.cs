using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class Deck
    {
        public int DeckID { get; set; }
        public string Creator { get; set; }
        public string Title { get; set; }
        public Format Format { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual ICollection<Card> MainBoard { get; set; }
        public virtual ICollection<Card> SideBoard { get; set; }        
    }
}