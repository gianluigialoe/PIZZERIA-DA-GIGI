namespace PIZZERIA_DA_GIGI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiornamentoModello1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ordines", "Quantita", c => c.Int(nullable: false));
            AddColumn("dbo.Ordines", "CostoTotale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Ordines", "IndirizzoSpedizione", c => c.String(nullable: false));
            AddColumn("dbo.Ordines", "Note", c => c.String());
            DropColumn("dbo.DettaglioOrdines", "Quantita");
            DropColumn("dbo.DettaglioOrdines", "CostoTotale");
            DropColumn("dbo.DettaglioOrdines", "IndirizzoSpedizione");
            DropColumn("dbo.DettaglioOrdines", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DettaglioOrdines", "Note", c => c.String());
            AddColumn("dbo.DettaglioOrdines", "IndirizzoSpedizione", c => c.String(nullable: false));
            AddColumn("dbo.DettaglioOrdines", "CostoTotale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DettaglioOrdines", "Quantita", c => c.Int(nullable: false));
            DropColumn("dbo.Ordines", "Note");
            DropColumn("dbo.Ordines", "IndirizzoSpedizione");
            DropColumn("dbo.Ordines", "CostoTotale");
            DropColumn("dbo.Ordines", "Quantita");
        }
    }
}
