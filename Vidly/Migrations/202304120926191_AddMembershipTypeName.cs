namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());

            Sql("UPDATE Membershiptypes SET MembershipName = 'PayAsYouGo' WHERE Id = 1");
            Sql("UPDATE Membershiptypes SET MembershipName = 'Monthly' WHERE Id = 2");
            Sql("UPDATE Membershiptypes SET MembershipName = 'Quaterly' WHERE Id = 3");
            Sql("UPDATE Membershiptypes SET MembershipName = 'Annual' WHERE Id = 4");

        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
