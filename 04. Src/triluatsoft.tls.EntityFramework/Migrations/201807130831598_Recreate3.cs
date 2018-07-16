namespace triluatsoft.tls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestEntities",
                c => new
                    {
                        A = c.Int(nullable: false, identity: true),
                        B = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.A);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestEntities");
        }
    }
}
