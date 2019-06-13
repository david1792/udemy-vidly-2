namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity:true ),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO genres ( Id,Description) VALUES (1, 'Genre 1')");
            Sql("INSERT INTO genres ( Id,Description) VALUES (2,'Genre 2')");
            Sql("INSERT INTO genres ( Id,Description) VALUES (3, 'Genre 3')");
            Sql("INSERT INTO genres ( Id,Description) VALUES (4, 'Genre 4')");
            Sql("INSERT INTO genres ( Id,Description) VALUES (5, 'Genre 5')");
            Sql("INSERT INTO Movies ( Id, Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES (1, 'Description 1', '20000202', '20010911', 5, 1)");
            Sql("INSERT INTO Movies ( Id, Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES (2, 'Description 2', '20000202', '20010911', 4, 2)");
            Sql("INSERT INTO Movies ( Id, Name, ReleaseDate, DateAdded, Stock, GenreId) VALUES (3, 'Description 3', '20000202', '20010911', 3, 3)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
