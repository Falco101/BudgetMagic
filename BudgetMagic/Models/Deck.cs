using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class Deck
    {
        public int DeckID { get; set; }
        public string Creator { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Format Format { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        [Required]
        public virtual ICollection<Card> MainBoard { get; set; }
        [Required]
        public virtual ICollection<Card> SideBoard { get; set; }        
    }
}