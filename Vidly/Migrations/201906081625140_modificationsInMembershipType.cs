namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationsInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
            Sql("UPDATE MembershipTypes SET Name = 'Name 1' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Name 2' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Name 3' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Name 4' WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
