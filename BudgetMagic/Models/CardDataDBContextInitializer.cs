using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BudgetMagic.Models
{
    public class CardDataDBContextInitializer : DropCreateDatabaseIfModelChanges<CardDataDBContext>
    {
        private CardDataDBContext context = new CardDataDBContext();

        protected override void Seed(CardDataDBContext context)
        {
            List<Deck> decks = new List<Deck>
            {
                new Deck()
                {
                    Title = "Mono Black Control",
                    Creator = "John Doe"
                },
                new Deck()
                {
                    Title = "Plunder the Graves",
                    Creator = "Meren of Clan NelToth"
                }
            };

            List<Format> formats = new List<Format>
            {
                new Format()
                {
                    Title = "Pauper",
                    MaxMythicCards = 0,
                    MaxRareCards = 0,
                    MaxUncommonCards = 0
                },
                new Format()
                {
                    Title = "Commander",
                    IsSignleton = true,

                }
            };

            
        }
    }
}