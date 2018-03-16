namespace BudgetMagic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MagicBlocks",
                c => new
                    {
                        MagicBlockID = c.Int(nullable: false, identity: true),
                        BlockName = c.String(),
                        Format_FormatID = c.Int(),
                    })
                .PrimaryKey(t => t.MagicBlockID)
                .ForeignKey("dbo.Formats", t => t.Format_FormatID)
                .Index(t => t.Format_FormatID);
            
            CreateTable(
                "dbo.MagicSets",
                c => new
                    {
                        MagicSetID = c.Int(nullable: false, identity: true),
                        SetName = c.String(),
                        SetBlock_MagicBlockID = c.Int(),
                        Format_FormatID = c.Int(),
                    })
                .PrimaryKey(t => t.MagicSetID)
                .ForeignKey("dbo.MagicBlocks", t => t.SetBlock_MagicBlockID)
                .ForeignKey("dbo.Formats", t => t.Format_FormatID)
                .Index(t => t.SetBlock_MagicBlockID)
                .Index(t => t.Format_FormatID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CardImage = c.Binary(),
                        ManaCost = c.String(),
                        CMC = c.Int(nullable: false),
                        Type = c.String(),
                        OracleText = c.String(),
                        Power = c.Int(nullable: false),
                        Toughness = c.Int(nullable: false),
                        Identity = c.String(),
                        Deck_DeckID = c.Int(),
                        Deck_DeckID1 = c.Int(),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.Decks", t => t.Deck_DeckID)
                .ForeignKey("dbo.Decks", t => t.Deck_DeckID1)
                .Index(t => t.Deck_DeckID)
                .Index(t => t.Deck_DeckID1);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyID = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(),
                        CurrencyShortName = c.String(),
                        CurrencyFormatRegex = c.String(),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.Decks",
                c => new
                    {
                        DeckID = c.Int(nullable: false, identity: true),
                        Creator = c.String(),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        Format_FormatID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeckID)
                .ForeignKey("dbo.Formats", t => t.Format_FormatID, cascadeDelete: true)
                .Index(t => t.Format_FormatID);
            
            CreateTable(
                "dbo.Formats",
                c => new
                    {
                        FormatID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        MainboardCardLimit = c.Int(nullable: false),
                        MainboardCardMinimum = c.Int(nullable: false),
                        SideboardCardLimit = c.Int(nullable: false),
                        HasCommanders = c.Boolean(nullable: false),
                        IsSignleton = c.Boolean(nullable: false),
                        MinCMC = c.Int(nullable: false),
                        MaxCMC = c.Int(nullable: false),
                        MaxUncommonCards = c.Int(nullable: false),
                        MaxRareCards = c.Int(nullable: false),
                        MaxMythicCards = c.Int(nullable: false),
                        MaxCardPrice = c.Double(nullable: false),
                        MaxCommanderPrice = c.Double(nullable: false),
                        Currency_CurrencyID = c.Int(),
                    })
                .PrimaryKey(t => t.FormatID)
                .ForeignKey("dbo.Currencies", t => t.Currency_CurrencyID)
                .Index(t => t.Currency_CurrencyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "Deck_DeckID1", "dbo.Decks");
            DropForeignKey("dbo.Cards", "Deck_DeckID", "dbo.Decks");
            DropForeignKey("dbo.Decks", "Format_FormatID", "dbo.Formats");
            DropForeignKey("dbo.MagicSets", "Format_FormatID", "dbo.Formats");
            DropForeignKey("dbo.Formats", "Currency_CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.MagicBlocks", "Format_FormatID", "dbo.Formats");
            DropForeignKey("dbo.MagicSets", "SetBlock_MagicBlockID", "dbo.MagicBlocks");
            DropIndex("dbo.Formats", new[] { "Currency_CurrencyID" });
            DropIndex("dbo.Decks", new[] { "Format_FormatID" });
            DropIndex("dbo.Cards", new[] { "Deck_DeckID1" });
            DropIndex("dbo.Cards", new[] { "Deck_DeckID" });
            DropIndex("dbo.MagicSets", new[] { "Format_FormatID" });
            DropIndex("dbo.MagicSets", new[] { "SetBlock_MagicBlockID" });
            DropIndex("dbo.MagicBlocks", new[] { "Format_FormatID" });
            DropTable("dbo.Formats");
            DropTable("dbo.Decks");
            DropTable("dbo.Currencies");
            DropTable("dbo.Cards");
            DropTable("dbo.MagicSets");
            DropTable("dbo.MagicBlocks");
        }
    }
}
