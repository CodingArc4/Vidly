namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillingGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Type) VALUES ('Action'),('Comedy'),('Family'),('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
