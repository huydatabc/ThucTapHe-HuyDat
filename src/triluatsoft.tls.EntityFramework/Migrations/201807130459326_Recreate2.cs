namespace triluatsoft.tls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replies", "PosterName", c => c.String());
            AddColumn("dbo.Threads", "PosterName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "PosterName");
            DropColumn("dbo.Replies", "PosterName");
        }
    }
}
