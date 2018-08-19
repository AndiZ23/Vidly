namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adult')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Children')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Epic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Musical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13, 'Mystery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (14, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (15, 'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (16, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (17, 'War')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (18, 'Western')");
        }
        
        public override void Down()
        {
        }
    }
}
