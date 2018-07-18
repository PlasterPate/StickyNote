namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Notes", "Text", c => c.String());
            AlterColumn("dbo.Notes", "Title", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Notes", "Title");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Notes", "Title", c => c.String());
            AlterColumn("dbo.Notes", "Text", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Notes", "Text");
        }
    }
}
