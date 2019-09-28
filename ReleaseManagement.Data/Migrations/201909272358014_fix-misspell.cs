namespace ReleaseManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixmisspell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Releases", "QaEndDate", c => c.DateTime());
            DropColumn("dbo.Releases", "QatEndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Releases", "QatEndDate", c => c.DateTime());
            DropColumn("dbo.Releases", "QaEndDate");
        }
    }
}
