namespace PIZZERIA_DA_GIGI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DettaglioOrdines", "Quantita", c => c.Int(nullable: false));
            DropColumn("dbo.Ordines", "Quantita");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ordines", "Quantita", c => c.Int(nullable: false));
            DropColumn("dbo.DettaglioOrdines", "Quantita");
        }
    }
}
