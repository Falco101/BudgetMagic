using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BudgetMagic.Models
{
    public class CardDataDBContext : DbContext
    {
        //Implement Interface for Repo
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }        
        public DbSet<MagicSet> Sets { get; set; }
        public DbSet<MagicBlock> Blocks { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}