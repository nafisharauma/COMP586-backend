namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatess : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NewUsers", "AccountTypeCode");
            DropColumn("dbo.NewUsers", "BranchName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewUsers", "BranchName", c => c.String());
            AddColumn("dbo.NewUsers", "AccountTypeCode", c => c.String());
        }
    }
}
