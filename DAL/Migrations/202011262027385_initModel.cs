namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Duration = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 30),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 30),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 40),
                        CourseId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Url = c.String(nullable: false),
                        SectionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: false)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Course_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: false)
                .Index(t => t.User_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        TagId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TagId, t.CourseId })
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .Index(t => t.TagId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.UserPreferedTags",
                c => new
                    {
                        TagId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TagId, t.UserId })
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.TagId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Videos", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.UserPreferedTags", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPreferedTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.UserCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.UserCourses", "User_Id", "dbo.Users");
            DropIndex("dbo.UserPreferedTags", new[] { "UserId" });
            DropIndex("dbo.UserPreferedTags", new[] { "TagId" });
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            DropIndex("dbo.CourseTags", new[] { "TagId" });
            DropIndex("dbo.UserCourses", new[] { "Course_Id" });
            DropIndex("dbo.UserCourses", new[] { "User_Id" });
            DropIndex("dbo.Videos", new[] { "SectionId" });
            DropIndex("dbo.Sections", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.UserPreferedTags");
            DropTable("dbo.CourseTags");
            DropTable("dbo.UserCourses");
            DropTable("dbo.Videos");
            DropTable("dbo.Sections");
            DropTable("dbo.Tags");
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
