namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Movies",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ( 'Description 1', '20000202', '20010911', 5, 1)");
            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ( 'Description 2', '20000202', '20010911', 4, 2)");
            Sql("INSERT INTO Movies ( Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES ( 'Description 3', '20000202', '20010911', 3, 3)");

        }

        public override void Down()
        {
        }
    }
}
