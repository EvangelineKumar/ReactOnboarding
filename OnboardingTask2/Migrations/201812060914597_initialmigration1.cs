namespace OnboardingTask2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
        }
    }
}
