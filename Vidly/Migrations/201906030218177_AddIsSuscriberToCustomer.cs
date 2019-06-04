namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSuscriberToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isSuscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "isSuscribedToNewsletter");
        }
    }
}
