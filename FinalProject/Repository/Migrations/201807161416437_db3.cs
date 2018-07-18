namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Color");
        }
    }
}
