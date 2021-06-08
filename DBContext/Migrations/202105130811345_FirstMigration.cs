namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        smallerdescription = c.String(),
                        description = c.String(),
                        keyterms = c.String(),
                        postcreated = c.DateTime(nullable: false),
                        postNumber = c.Long(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        threadName = c.String(),
                        threadDiscription = c.String(),
                        threadKeyTerms = c.String(),
                        threadCreationDate = c.DateTime(nullable: false),
                        threadNumber = c.Long(nullable: false),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        userCreated = c.DateTime(nullable: false),
                        userAge = c.Double(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "UserId", "dbo.Users");
            DropForeignKey("dbo.Threads", "PostId", "dbo.Posts");
            DropIndex("dbo.Threads", new[] { "UserId" });
            DropIndex("dbo.Threads", new[] { "PostId" });
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Posts");
        }
    }
}
