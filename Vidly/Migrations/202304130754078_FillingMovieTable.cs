namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillingMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,RelaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Hangover','02-06-2009','01-01-2019',4,2)");
            Sql("INSERT INTO Movies(Name,RelaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Taken','07-02-2008','01-05-2019',10,1)");
        }
        
        public override void Down()
        {
        }
    }
}
