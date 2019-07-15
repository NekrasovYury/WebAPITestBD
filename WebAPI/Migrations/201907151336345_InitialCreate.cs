namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        InfoUserID = c.Int(nullable: false, identity: true),
                        InfoBalance = c.String(),
                        InfoUserName = c.String(),
                        InfoRegisterDate = c.DateTime(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.InfoUserID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserInfoes", new[] { "User_UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserInfoes");
        }
    }
}
