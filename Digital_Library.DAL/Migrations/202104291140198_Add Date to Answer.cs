namespace Digital_Library.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatetoAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionnaries", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questionnaries", "IsActive");
        }
    }
}
