namespace UserRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registersucess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        AdharcardNumber = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(nullable: false),
                        Landmark = c.String(nullable: false),
                        state = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Pincode = c.Int(nullable: false),
                        OccupationType = c.String(nullable: false),
                        SourceOfIncome = c.String(nullable: false),
                        GrossAnnualIncome = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
