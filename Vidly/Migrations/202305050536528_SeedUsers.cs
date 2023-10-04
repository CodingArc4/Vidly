namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a6647a6d-6808-4bd0-ab51-ea775d836004', N'guest@vidly.com', 0, N'APld1ZnxTCAj96AxU3JpqT5jHIeP6a2Ry6bYXqX7+wO9NNdFAtxVWrNtsspVLiOnIQ==', N'25f46edd-03aa-4b32-ae70-7038e6630b78', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c78173b0-5886-49ca-aa83-305bcb2dffbe', N'admin@vidly.com', 0, N'AD14w/jE2rXOa/GQbh1V5x4kxUVp7UCzkJQMNHK5dgbkm1MX6ZqP21Ueuo6mr1tcsA==', N'7a035413-6fcc-4932-8605-403547c3f2e6', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
               
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd8527a4c-1c92-496e-bdd9-55ee1997d543', N'CanManageMovie')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c78173b0-5886-49ca-aa83-305bcb2dffbe', N'd8527a4c-1c92-496e-bdd9-55ee1997d543')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
