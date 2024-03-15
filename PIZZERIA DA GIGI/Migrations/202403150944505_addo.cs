namespace PIZZERIA_DA_GIGI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DettaglioOrdines", "OrdineId", "dbo.Ordines");
            DropIndex("dbo.DettaglioOrdines", new[] { "OrdineId" });
            AlterColumn("dbo.DettaglioOrdines", "OrdineId", c => c.Int());
            CreateIndex("dbo.DettaglioOrdines", "OrdineId");
            AddForeignKey("dbo.DettaglioOrdines", "OrdineId", "dbo.Ordines", "OrdineId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioOrdines", "OrdineId", "dbo.Ordines");
            DropIndex("dbo.DettaglioOrdines", new[] { "OrdineId" });
            AlterColumn("dbo.DettaglioOrdines", "OrdineId", c => c.Int(nullable: false));
            CreateIndex("dbo.DettaglioOrdines", "OrdineId");
            AddForeignKey("dbo.DettaglioOrdines", "OrdineId", "dbo.Ordines", "OrdineId", cascadeDelete: true);
        }
    }
}
