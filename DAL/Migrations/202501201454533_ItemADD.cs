namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemADD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Barcode = c.String(),
                        Quantity = c.Int(nullable: false),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}
