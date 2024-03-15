namespace PIZZERIA_DA_GIGI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuovo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DettaglioOrdines", "UtenteId", c => c.Int());
            CreateIndex("dbo.DettaglioOrdines", "UtenteId");
            AddForeignKey("dbo.DettaglioOrdines", "UtenteId", "dbo.Users", "UtenteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioOrdines", "UtenteId", "dbo.Users");
            DropIndex("dbo.DettaglioOrdines", new[] { "UtenteId" });
            DropColumn("dbo.DettaglioOrdines", "UtenteId");
        }
    }
}
