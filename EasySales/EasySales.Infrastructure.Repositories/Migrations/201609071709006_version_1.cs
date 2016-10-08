using System;
using System.Data.Entity.Migrations;

namespace EasySales.Infrastructure.Repositories.Migrations
{
    
    public partial class version_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Key = c.Guid(nullable: false),
                        DateEdit = c.DateTime(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entities");
        }
    }
}
