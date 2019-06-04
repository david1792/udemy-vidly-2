namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipDescription", c => c.String());
            Sql("UPDATE MembershipTypes SET MembershipDescription = 'DES 1' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipDescription = 'DES 2' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipDescription = 'DES 3' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipDescription = 'DES 4' WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipDescription");
        }
    }
}
