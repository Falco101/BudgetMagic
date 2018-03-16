namespace BudgetMagic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MagicSets", "SetBlock_MagicBlockID", "dbo.MagicBlocks");
            DropForeignKey("dbo.Cards", "Format_FormatID", "dbo.Formats");
            DropForeignKey("dbo.MagicBlocks", "Format_FormatID", "dbo.Formats");
            DropForeignKey("dbo.Formats", "Currency_CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.MagicSets", "Format_FormatID", "dbo.Formats");
            DropForeignKey("dbo.Decks", "Format_FormatID", "dbo.Formats");
            DropForeignKey("dbo.Cards", "Deck_DeckID", "dbo.Decks");
            DropForeignKey("dbo.Cards", "Deck_DeckID1", "dbo.Decks");
            DropIndex("dbo.MagicBlocks", new[] { "Format_FormatID" });
            DropIndex("dbo.MagicSets", new[] { "SetBlock_MagicBlockID" });
            DropIndex("dbo.MagicSets", new[] { "Format_FormatID" });
            DropIndex("dbo.Cards", new[] { "Format_FormatID" });
            DropIndex("dbo.Cards", new[] { "Deck_DeckID" });
            DropIndex("dbo.Cards", new[] { "Deck_DeckID1" });
            DropIndex("dbo.Decks", new[] { "Format_FormatID" });
            DropIndex("dbo.Formats", new[] { "Currency_CurrencyID" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.MagicBlocks");
            DropTable("dbo.MagicSets");
            DropTable("dbo.Cards");
            DropTable("dbo.Currencies");
            DropTable("dbo.Decks");
            DropTable("dbo.Formats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Formats",
                c => new
                    {
                        FormatID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
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
                .PrimaryKey(t => t.FormatID);
            
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
                .PrimaryKey(t => t.DeckID);
            
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
                        Format_FormatID = c.Int(),
                        Deck_DeckID = c.Int(),
                        Deck_DeckID1 = c.Int(),
                    })
                .PrimaryKey(t => t.CardID);
            
            CreateTable(
                "dbo.MagicSets",
                c => new
                    {
                        MagicSetID = c.Int(nullable: false, identity: true),
                        SetName = c.String(),
                        SetBlock_MagicBlockID = c.Int(),
                        Format_FormatID = c.Int(),
                    })
                .PrimaryKey(t => t.MagicSetID);
            
            CreateTable(
                "dbo.MagicBlocks",
                c => new
                    {
                        MagicBlockID = c.Int(nullable: false, identity: true),
                        BlockName = c.String(),
                        Format_FormatID = c.Int(),
                    })
                .PrimaryKey(t => t.MagicBlockID);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.Formats", "Currency_CurrencyID");
            CreateIndex("dbo.Decks", "Format_FormatID");
            CreateIndex("dbo.Cards", "Deck_DeckID1");
            CreateIndex("dbo.Cards", "Deck_DeckID");
            CreateIndex("dbo.Cards", "Format_FormatID");
            CreateIndex("dbo.MagicSets", "Format_FormatID");
            CreateIndex("dbo.MagicSets", "SetBlock_MagicBlockID");
            CreateIndex("dbo.MagicBlocks", "Format_FormatID");
            AddForeignKey("dbo.Cards", "Deck_DeckID1", "dbo.Decks", "DeckID");
            AddForeignKey("dbo.Cards", "Deck_DeckID", "dbo.Decks", "DeckID");
            AddForeignKey("dbo.Decks", "Format_FormatID", "dbo.Formats", "FormatID", cascadeDelete: true);
            AddForeignKey("dbo.MagicSets", "Format_FormatID", "dbo.Formats", "FormatID");
            AddForeignKey("dbo.Formats", "Currency_CurrencyID", "dbo.Currencies", "CurrencyID");
            AddForeignKey("dbo.MagicBlocks", "Format_FormatID", "dbo.Formats", "FormatID");
            AddForeignKey("dbo.Cards", "Format_FormatID", "dbo.Formats", "FormatID");
            AddForeignKey("dbo.MagicSets", "SetBlock_MagicBlockID", "dbo.MagicBlocks", "MagicBlockID");
        }
    }
}
