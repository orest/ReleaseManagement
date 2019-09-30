namespace ReleaseManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addapiuicompleteflag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "IsApiCompleted", c => c.Boolean());
            AddColumn("dbo.Features", "IsUiCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkItems", "IsApiCompleted", c => c.Boolean());
            AddColumn("dbo.WorkItems", "IsUiCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkItems", "StatusCode", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.WorkItems", "TypeCode", c => c.String(maxLength: 10, unicode: false));
            DropColumn("dbo.Features", "TypeCode");
            DropColumn("dbo.Features", "IsCompleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Features", "IsCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Features", "TypeCode", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.WorkItems", "TypeCode", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.WorkItems", "StatusCode");
            DropColumn("dbo.WorkItems", "IsUiCompleted");
            DropColumn("dbo.WorkItems", "IsApiCompleted");
            DropColumn("dbo.Features", "IsUiCompleted");
            DropColumn("dbo.Features", "IsApiCompleted");
        }
    }
}
