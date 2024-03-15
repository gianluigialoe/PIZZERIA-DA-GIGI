namespace PIZZERIA_DA_GIGI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DettaglioOrdines",
                c => new
                    {
                        DettaglioOrdineId = c.Int(nullable: false, identity: true),
                        OrdineId = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                        Quantita = c.Int(nullable: false),
                        CostoTotale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IndirizzoSpedizione = c.String(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.DettaglioOrdineId)
                .ForeignKey("dbo.Ordines", t => t.OrdineId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.OrdineId)
                .Index(t => t.PizzaId);
            
            CreateTable(
                "dbo.Ordines",
                c => new
                    {
                        OrdineId = c.Int(nullable: false, identity: true),
                        UtenteId = c.Int(nullable: false),
                        DataOrdine = c.DateTime(nullable: false),
                        Evaso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrdineId)
                .ForeignKey("dbo.Users", t => t.UtenteId, cascadeDelete: true)
                .Index(t => t.UtenteId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UtenteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UtenteId);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        PizzaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Foto = c.String(),
                        Prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TempoConsegna = c.Int(nullable: false),
                        Ingredienti = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaId);
            
            CreateTable(
                "dbo.StatisticheGiornalieres",
                c => new
                    {
                        Data = c.DateTime(nullable: false),
                        NumeroOrdiniEvasi = c.Int(nullable: false),
                        TotaleIncassato = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Data);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioOrdines", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.Ordines", "UtenteId", "dbo.Users");
            DropForeignKey("dbo.DettaglioOrdines", "OrdineId", "dbo.Ordines");
            DropIndex("dbo.Ordines", new[] { "UtenteId" });
            DropIndex("dbo.DettaglioOrdines", new[] { "PizzaId" });
            DropIndex("dbo.DettaglioOrdines", new[] { "OrdineId" });
            DropTable("dbo.StatisticheGiornalieres");
            DropTable("dbo.Pizzas");
            DropTable("dbo.Users");
            DropTable("dbo.Ordines");
            DropTable("dbo.DettaglioOrdines");
        }
    }
}
