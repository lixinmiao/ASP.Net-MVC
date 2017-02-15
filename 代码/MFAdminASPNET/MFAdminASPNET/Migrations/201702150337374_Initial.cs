namespace MFAdminASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.user");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.role");
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            AddColumn("dbo.media", "createTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.verifyCode", "createTime", c => c.DateTime(nullable: false));
            DropTable("dbo.loginInfo");
            DropTable("dbo.role");
            DropTable("dbo.user");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Role_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id });
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        loginName = c.String(nullable: false),
                        password = c.String(nullable: false),
                        mobile = c.String(),
                        email = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        info = c.String(),
                        businessPermissionString = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.loginInfo",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        loginToken = c.Guid(nullable: false),
                        lastAccessTime = c.DateTime(nullable: false),
                        userID = c.Long(nullable: false),
                        loginName = c.String(),
                        clientIP = c.String(),
                        enumLoginAccountType = c.Int(nullable: false),
                        businessPermissionString = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.verifyCode", "createTime");
            DropColumn("dbo.media", "createTime");
            CreateIndex("dbo.UserRoles", "Role_Id");
            CreateIndex("dbo.UserRoles", "User_Id");
            AddForeignKey("dbo.UserRoles", "Role_Id", "dbo.role", "id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "User_Id", "dbo.user", "id", cascadeDelete: true);
        }
    }
}
