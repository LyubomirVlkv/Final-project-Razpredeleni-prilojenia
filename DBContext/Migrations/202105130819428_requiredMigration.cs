namespace DBContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "keyterms", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Threads", "threadName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Threads", "threadDiscription", c => c.String(nullable: false));
            AlterColumn("dbo.Threads", "threadKeyTerms", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Threads", "threadKeyTerms", c => c.String());
            AlterColumn("dbo.Threads", "threadDiscription", c => c.String());
            AlterColumn("dbo.Threads", "threadName", c => c.String());
            AlterColumn("dbo.Posts", "keyterms", c => c.String());
            AlterColumn("dbo.Posts", "description", c => c.String());
            AlterColumn("dbo.Posts", "title", c => c.String());
        }
    }
}
