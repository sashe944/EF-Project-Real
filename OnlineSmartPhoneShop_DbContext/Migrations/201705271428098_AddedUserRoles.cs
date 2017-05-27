namespace OnlineSmartPhoneShop_DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserRoles : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BuySmartphones");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BuySmartphones",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SmartphoneName = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        ImgURL = c.String(nullable: false),
                        BoughtOnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
