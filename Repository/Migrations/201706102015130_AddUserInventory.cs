namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            AddColumn("dbo.Products", "Inventory_InventoryId", c => c.Int());
            AddColumn("dbo.Users", "Cash", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "Inventory_InventoryId", c => c.Int());
            CreateIndex("dbo.Products", "Inventory_InventoryId");
            CreateIndex("dbo.Users", "Inventory_InventoryId");
            AddForeignKey("dbo.Products", "Inventory_InventoryId", "dbo.Inventories", "InventoryId");
            AddForeignKey("dbo.Users", "Inventory_InventoryId", "dbo.Inventories", "InventoryId");
            DropColumn("dbo.Users", "Credit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Credit", c => c.Double(nullable: false));
            DropForeignKey("dbo.Users", "Inventory_InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Products", "Inventory_InventoryId", "dbo.Inventories");
            DropIndex("dbo.Users", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.Products", new[] { "Inventory_InventoryId" });
            DropColumn("dbo.Users", "Inventory_InventoryId");
            DropColumn("dbo.Users", "Cash");
            DropColumn("dbo.Products", "Inventory_InventoryId");
            DropTable("dbo.Inventories");
        }
    }
}
