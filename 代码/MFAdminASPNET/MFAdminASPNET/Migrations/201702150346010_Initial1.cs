namespace MFAdminASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
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
                        createTime = c.DateTime(nullable: false),
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
                        createTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                        createTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Role_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.user", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.role");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.user");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.user");
            DropTable("dbo.role");
            DropTable("dbo.loginInfo");
        }
    }
}
