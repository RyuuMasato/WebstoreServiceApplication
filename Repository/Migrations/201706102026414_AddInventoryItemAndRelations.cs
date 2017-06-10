namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventoryItemAndRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Inventory_InventoryId", "dbo.Inventories");
            DropIndex("dbo.Products", new[] { "Inventory_InventoryId" });
            CreateTable(
                "dbo.InventoryItems",
                c => new
                    {
                        InventoryItemId = c.Int(nullable: false, identity: true),
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.Products", "Inventory_InventoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Inventory_InventoryId", c => c.Int());
            DropForeignKey("dbo.InventoryItems", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.InventoryItems", "ProductId", "dbo.Products");
            DropIndex("dbo.InventoryItems", new[] { "ProductId" });
            DropIndex("dbo.InventoryItems", new[] { "InventoryId" });
            DropTable("dbo.InventoryItems");
            CreateIndex("dbo.Products", "Inventory_InventoryId");
            AddForeignKey("dbo.Products", "Inventory_InventoryId", "dbo.Inventories", "InventoryId");
        }
    }
}
