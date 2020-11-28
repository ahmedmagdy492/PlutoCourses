namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImgColumnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "BannerImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "BannerImgUrl");
        }
    }
}
