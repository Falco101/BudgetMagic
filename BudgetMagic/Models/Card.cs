using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetMagic.Models
{
    public class Card
    {
        public int CardID { get; set; }
        public Guid ScryfallID { get; set; }
        public Guid OracleID { get; set; }
        public ICollection<int> MultiverseIDs { get; set; }
        public int MTGOID { get; set; }
        public int MTGOFoilID { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public string ScryfallUri { get; set; }
        public string Layout { get; set; }
        public bool HiresImage { get; set; }
        public ICollection<string> ImageUris { get; set; }
        public int CMC { get; set; }
        public string TypeLine { get; set; }
        public string OracleText { get; set; }
        public string ManaCost { get; set; }
        public int Loyalty { get; set; }
        public ICollection<char> Colors { get; set; }
        public ICollection<char> ColorIdentity { get; set; }
        public ICollection<object> Legalities { get; set; }
        public bool Reserved { get; set; }
        public bool Reprint { get; set; }
        public MagicSet Set { get; set; }
        public string RulingsUri { get; set; }
        public string PrintsSearchUri { get; set; }
        public int CollectorNumber { get; set; }
        public bool Digital { get; set; }
        public enum Rarity {
            Common,
            Uncommon,
            Rare,
            Mythic,
            Timeshifted
        }
        public int Power { get; set; }
        public int Toughness { get; set; }
        public string Identity { get; set; }
    }
}