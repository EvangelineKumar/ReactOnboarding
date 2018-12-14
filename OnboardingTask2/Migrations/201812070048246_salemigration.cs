namespace OnboardingTask2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salemigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        DateSold = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.StoreId);
            
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Stores", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Stores", "Address", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "StoreId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Sales", new[] { "ProductId" });
            AlterColumn("dbo.Stores", "Address", c => c.String());
            AlterColumn("dbo.Stores", "Name", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropTable("dbo.Sales");
        }
    }
}
