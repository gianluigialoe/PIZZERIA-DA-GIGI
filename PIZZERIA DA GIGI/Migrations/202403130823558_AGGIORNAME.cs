namespace PIZZERIA_DA_GIGI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AGGIORNAME : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ordines", "StatisticheGiornaliere_Data", "dbo.StatisticheGiornalieres");
            DropIndex("dbo.Ordines", new[] { "StatisticheGiornaliere_Data" });
            AddColumn("dbo.Users", "Role", c => c.String(nullable: false));
            DropColumn("dbo.Ordines", "StatisticheGiornaliere_Data");
            DropTable("dbo.StatisticheGiornalieres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StatisticheGiornalieres",
                c => new
                    {
                        Data = c.DateTime(nullable: false),
                        NumeroOrdiniEvasi = c.Int(nullable: false),
                        TotaleIncassato = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Data);
            
            AddColumn("dbo.Ordines", "StatisticheGiornaliere_Data", c => c.DateTime());
            DropColumn("dbo.Users", "Role");
            CreateIndex("dbo.Ordines", "StatisticheGiornaliere_Data");
            AddForeignKey("dbo.Ordines", "StatisticheGiornaliere_Data", "dbo.StatisticheGiornalieres", "Data");
        }
    }
}
