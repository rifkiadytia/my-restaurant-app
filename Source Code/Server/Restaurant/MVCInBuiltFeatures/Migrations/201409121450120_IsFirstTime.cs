namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFirstTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsFirstTime", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsFirstTime");
        }
    }
}
