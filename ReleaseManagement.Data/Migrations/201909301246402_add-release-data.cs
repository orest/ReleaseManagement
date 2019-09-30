namespace ReleaseManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreleasedata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Releases", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Releases", "ReleaseDate");
        }
    }
}
