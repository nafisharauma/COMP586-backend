namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounttransfers",
                c => new
                    {
                        TransId = c.Int(nullable: false, identity: true),
                        TransFromAccountNumber = c.String(),
                        TransToAccountNumber = c.String(),
                        TransAmount = c.String(),
                        TransDate = c.String(),
                    })
                .PrimaryKey(t => t.TransId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounttransfers");
        }
    }
}
