namespace HomeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        OperationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Sum = c.Double(nullable: false),
                        OperationType_OperationTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.OperationId)
                .ForeignKey("dbo.OperationTypes", t => t.OperationType_OperationTypeId)
                .Index(t => t.OperationType_OperationTypeId);
            
            CreateTable(
                "dbo.OperationTypes",
                c => new
                    {
                        OperationTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OperationTypeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Operation_OperationId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Operations", t => t.Operation_OperationId)
                .Index(t => t.Operation_OperationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Operation_OperationId", "dbo.Operations");
            DropForeignKey("dbo.Operations", "OperationType_OperationTypeId", "dbo.OperationTypes");
            DropIndex("dbo.Products", new[] { "Operation_OperationId" });
            DropIndex("dbo.Operations", new[] { "OperationType_OperationTypeId" });
            DropTable("dbo.Products");
            DropTable("dbo.OperationTypes");
            DropTable("dbo.Operations");
        }
    }
}
