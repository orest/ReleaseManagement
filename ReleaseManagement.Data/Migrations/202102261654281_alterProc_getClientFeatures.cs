namespace ReleaseManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterProc_getClientFeatures : DbMigration
    {
        public override void Up()
        {
            var sp = @"BEGIN 
                            SELECT f.displayName, f.featureId, c.clientName, c.clientId, r.statusCode as 'ReleaseStatus', f.statusCode as 'FeatureStatus', r.ReleaseDate, r.releaseId, r.applicationVersion 
                            FROM features f LEFT JOIN releaseFeatures rf on rf.featureId = f.featureId 
                            LEFT JOIN releases r on r.releaseId = rf.releaseId 
                            LEFT JOIN clients c on r.clientId = c.clientId 
                            ORDER BY f.featureId, c.clientId 
                       END";

            AlterStoredProcedure("dbo.GetClientFeatures", sp);
        }
        
        public override void Down()
        {
            var sp = @"BEGIN 
                            SELECT f.displayName, f.featureId, c.clientName, c.clientId, r.statusCode as 'ReleaseStatus', f.statusCode as 'FeatureStatus', r.ReleaseDate, r.applicationVersion 
                            FROM features f LEFT JOIN releaseFeatures rf on rf.featureId = f.featureId 
                            LEFT JOIN releases r on r.releaseId = rf.releaseId 
                            LEFT JOIN clients c on r.clientId = c.clientId 
                            ORDER BY f.featureId, c.clientId 
                       END";

            AlterStoredProcedure("dbo.GetClientFeatures", sp);
        }
    }
}
