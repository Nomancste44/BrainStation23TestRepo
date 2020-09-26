namespace FeedBackCollectionWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Demo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        CommentTime = c.DateTime(nullable: false),
                        Post_PostId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Post_PostId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostContent = c.String(),
                        PostTime = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        ReactionId = c.Int(nullable: false, identity: true),
                        IsLike = c.Boolean(nullable: false),
                        Comment_CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.ReactionId)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentId)
                .Index(t => t.Comment_CommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Reactions", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Reactions", new[] { "Comment_CommentId" });
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropTable("dbo.Reactions");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
