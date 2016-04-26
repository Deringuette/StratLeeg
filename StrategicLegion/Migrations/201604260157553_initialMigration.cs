namespace StrategicLegion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChecklistGroups",
                c => new
                    {
                        ChecklistGroupId = c.Int(nullable: false, identity: true),
                        ParentChecklistId = c.Int(nullable: false),
                        GroupName = c.String(),
                        ItemCount = c.Int(nullable: false),
                        Checklist_ChecklistId = c.Int(),
                    })
                .PrimaryKey(t => t.ChecklistGroupId)
                .ForeignKey("dbo.Checklists", t => t.Checklist_ChecklistId)
                .Index(t => t.Checklist_ChecklistId);
            
            CreateTable(
                "dbo.ChecklistItems",
                c => new
                    {
                        ChecklistItemId = c.Int(nullable: false, identity: true),
                        ParentChecklistGroupId = c.Int(nullable: false),
                        ChecklistItemName = c.String(),
                        ChecklistGroup_ChecklistGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.ChecklistItemId)
                .ForeignKey("dbo.ChecklistGroups", t => t.ChecklistGroup_ChecklistGroupId)
                .Index(t => t.ChecklistGroup_ChecklistGroupId);
            
            CreateTable(
                "dbo.Checklists",
                c => new
                    {
                        ChecklistId = c.Int(nullable: false, identity: true),
                        ChecklistName = c.String(),
                        GroupCount = c.Int(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                        Submitter = c.String(),
                    })
                .PrimaryKey(t => t.ChecklistId);
            
            CreateTable(
                "dbo.NotepadStrategyModels",
                c => new
                    {
                        NotepadId = c.String(nullable: false, maxLength: 128),
                        NotepadName = c.String(),
                        NotepadContent = c.String(),
                    })
                .PrimaryKey(t => t.NotepadId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ChecklistGroups", "Checklist_ChecklistId", "dbo.Checklists");
            DropForeignKey("dbo.ChecklistItems", "ChecklistGroup_ChecklistGroupId", "dbo.ChecklistGroups");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ChecklistItems", new[] { "ChecklistGroup_ChecklistGroupId" });
            DropIndex("dbo.ChecklistGroups", new[] { "Checklist_ChecklistId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.NotepadStrategyModels");
            DropTable("dbo.Checklists");
            DropTable("dbo.ChecklistItems");
            DropTable("dbo.ChecklistGroups");
        }
    }
}
