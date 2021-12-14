namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChequeBookReqs",
                c => new
                    {
                        ChequeBookRequsetID = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        RequestDate = c.String(),
                        RequestStatus = c.String(),
                    })
                .PrimaryKey(t => t.ChequeBookRequsetID);
            
            CreateTable(
                "dbo.FundDeposits",
                c => new
                    {
                        DepositId = c.Int(nullable: false, identity: true),
                        AccountNo = c.String(),
                        DepositDate = c.String(),
                        DepositAmount = c.String(),
                    })
                .PrimaryKey(t => t.DepositId);
            
            CreateTable(
                "dbo.Fundwithdrawals",
                c => new
                    {
                        WithdrwalID = c.Int(nullable: false, identity: true),
                        AccountNo = c.String(),
                        WithdrwalDate = c.String(),
                        WithdrwalAmount = c.String(),
                    })
                .PrimaryKey(t => t.WithdrwalID);
            
            CreateTable(
                "dbo.NewUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        EmailID = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                        AccountNumber = c.String(),
                        OpeningDate = c.String(),
                        Currentbalance = c.String(),
                        NomineeName = c.String(),
                        DOB = c.String(),
                        AccountType = c.String(),
                        AccountTypeCode = c.String(),
                        BranchName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewUsers");
            DropTable("dbo.Fundwithdrawals");
            DropTable("dbo.FundDeposits");
            DropTable("dbo.ChequeBookReqs");
        }
    }
}
