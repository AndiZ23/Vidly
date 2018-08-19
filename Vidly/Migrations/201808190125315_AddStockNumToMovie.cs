namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockNumToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumInStock");
        }
    }
}
