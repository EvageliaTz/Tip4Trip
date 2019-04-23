namespace T4Trip_end.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "DateOfBooking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "DateOfBooking", c => c.DateTime(nullable: false));
        }
    }
}
