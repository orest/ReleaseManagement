namespace ReleaseManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreleasefeaturestable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ReleaseFeatures", name: "FeaturesId", newName: "FeatureId");
            RenameIndex(table: "dbo.ReleaseFeatures", name: "IX_FeaturesId", newName: "IX_FeatureId");
            DropPrimaryKey("dbo.ReleaseFeatures");
            AddColumn("dbo.ReleaseFeatures", "ReleaseFeatureId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ReleaseFeatures", "StatusCode", c => c.String(maxLength: 10, unicode: false));
            AddPrimaryKey("dbo.ReleaseFeatures", "ReleaseFeatureId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ReleaseFeatures");
            DropColumn("dbo.ReleaseFeatures", "StatusCode");
            DropColumn("dbo.ReleaseFeatures", "ReleaseFeatureId");
            AddPrimaryKey("dbo.ReleaseFeatures", new[] { "ReleaseId", "FeaturesId" });
            RenameIndex(table: "dbo.ReleaseFeatures", name: "IX_FeatureId", newName: "IX_FeaturesId");
            RenameColumn(table: "dbo.ReleaseFeatures", name: "FeatureId", newName: "FeaturesId");
        }
    }
}
