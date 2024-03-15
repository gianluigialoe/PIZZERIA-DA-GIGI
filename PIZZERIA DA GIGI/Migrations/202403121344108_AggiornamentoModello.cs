namespace PIZZERIA_DA_GIGI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AggiornamentoModello : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ordines", "StatisticheGiornaliere_Data", c => c.DateTime());
            CreateIndex("dbo.Ordines", "StatisticheGiornaliere_Data");
            AddForeignKey("dbo.Ordines", "StatisticheGiornaliere_Data", "dbo.StatisticheGiornalieres", "Data");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ordines", "StatisticheGiornaliere_Data", "dbo.StatisticheGiornalieres");
            DropIndex("dbo.Ordines", new[] { "StatisticheGiornaliere_Data" });
            DropColumn("dbo.Ordines", "StatisticheGiornaliere_Data");
        }
    }
}
