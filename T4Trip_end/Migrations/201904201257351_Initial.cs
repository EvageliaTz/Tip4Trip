namespace T4Trip_end.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Owner = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        LocationId = c.Int(nullable: false),
                        MaxOccupancy = c.Int(nullable: false),
                        PriceperNight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCity = c.String(nullable: false),
                        NameMunicipality = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(nullable: false),
                        renter = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Occupants = c.Int(nullable: false),
                        DateOfBooking = c.DateTime(nullable: false),
                        CustommerComments = c.String(),
                        PricePerNightCharged = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Houses", t => t.HouseId, cascadeDelete: true)
                .Index(t => t.HouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.Houses", "LocationId", "dbo.Locations");
            DropIndex("dbo.Reservations", new[] { "HouseId" });
            DropIndex("dbo.Houses", new[] { "LocationId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Locations");
            DropTable("dbo.Houses");
        }
    }
}
