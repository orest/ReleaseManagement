namespace ReleaseManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(maxLength: 250, unicode: false),
                        ImageUrl = c.String(maxLength: 250, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        ReleaseId = c.Int(nullable: false, identity: true),
                        ApplicationVersion = c.String(maxLength: 250, unicode: false),
                        ClientId = c.Int(nullable: false),
                        StatusCode = c.String(maxLength: 10, unicode: false),
                        QaStartDate = c.DateTime(),
                        QatEndDate = c.DateTime(),
                        UatStartDate = c.DateTime(),
                        UatEndDate = c.DateTime(),
                        ClientApproverName = c.String(maxLength: 250, unicode: false),
                        Notes = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ReleaseId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 250, unicode: false),
                        TypeCode = c.String(maxLength: 10, unicode: false),
                        StatusCode = c.String(maxLength: 10, unicode: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureId);
            
            CreateTable(
                "dbo.ReleasePlatforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlatformCode = c.String(maxLength: 250, unicode: false),
                        ReleaseId = c.Int(nullable: false),
                        AvailableInStoreDate = c.DateTime(),
                        SubmittedForApprovalDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Releases", t => t.ReleaseId, cascadeDelete: true)
                .Index(t => t.ReleaseId);
            
            CreateTable(
                "dbo.WorkItems",
                c => new
                    {
                        WorkItemId = c.Int(nullable: false, identity: true),
                        ReleaseId = c.Int(nullable: false),
                        Title = c.String(maxLength: 250, unicode: false),
                        TypeCode = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.WorkItemId)
                .ForeignKey("dbo.Releases", t => t.ReleaseId, cascadeDelete: true)
                .Index(t => t.ReleaseId);
            
            CreateTable(
                "dbo.ReleaseFeatures",
                c => new
                    {
                        ReleaseId = c.Int(nullable: false),
                        FeaturesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReleaseId, t.FeaturesId })
                .ForeignKey("dbo.Releases", t => t.ReleaseId, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.FeaturesId, cascadeDelete: true)
                .Index(t => t.ReleaseId)
                .Index(t => t.FeaturesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItems", "ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.ReleasePlatforms", "ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.ReleaseFeatures", "FeaturesId", "dbo.Features");
            DropForeignKey("dbo.ReleaseFeatures", "ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.Releases", "ClientId", "dbo.Clients");
            DropIndex("dbo.ReleaseFeatures", new[] { "FeaturesId" });
            DropIndex("dbo.ReleaseFeatures", new[] { "ReleaseId" });
            DropIndex("dbo.WorkItems", new[] { "ReleaseId" });
            DropIndex("dbo.ReleasePlatforms", new[] { "ReleaseId" });
            DropIndex("dbo.Releases", new[] { "ClientId" });
            DropTable("dbo.ReleaseFeatures");
            DropTable("dbo.WorkItems");
            DropTable("dbo.ReleasePlatforms");
            DropTable("dbo.Features");
            DropTable("dbo.Releases");
            DropTable("dbo.Clients");
        }
    }
}
