namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Title");
        }
    }
}
