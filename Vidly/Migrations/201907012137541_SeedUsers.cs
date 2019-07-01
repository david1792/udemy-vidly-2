namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'abea11da-1f7c-48f0-93b2-31d79b5df431', N'admin@vidly.com', 0, N'ACoA3mVbTJ3C0Rh7G1RJ2wOOqbLv+ax/RIU3VmgTt9/S0cv7OiP0J5+1P5G2M5eCWA==', N'65644754-f96b-441a-9ee9-530a5fcd55e9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e6777780-e8b0-4c4c-ac18-6fb3fb246b6c', N'guest@vidly.com', 0, N'AJBgFzYoqFXtpYEMaNyijvIlQLCepKlrQSFG6iQykhD2qf7K/vS9IqCsR1ftEzL5jQ==', N'66efb18e-1c6a-4456-bfae-582f7ac6b637', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8202190a-8add-4840-8d8e-4f7540acc87a', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'abea11da-1f7c-48f0-93b2-31d79b5df431', N'8202190a-8add-4840-8d8e-4f7540acc87a')


");
            /**
             * 1. delete records in the database  and then run this migration. thi will populate our database with users and CanManageMovies rol
             * the beauty pf this approach is taht if you run these migrations on another database, let's say you are testing your production database will have the exat same setup
             * so this is a proper way to seed our database with users and roles
             * in the official tutorials they show you the poor way to do this because migration runs a seed method that execute and update and WILL NOT BE EXECUTE IN PRODUCTIUON  UPDATE-database and you have to
             * change the connection string in web.config and run update database -> read 6. 6. Seeding Users and Roles min 07.00
             */
        }

        public override void Down()
        {
        }
    } 
}
