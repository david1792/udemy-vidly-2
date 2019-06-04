namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
            Sql("UPDATE Customers SET BirthDate = '19921005' WHERE Id = 1");
            Sql("UPDATE Customers SET BirthDate = '19871128' WHERE Id = 2");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
