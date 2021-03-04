namespace MusicHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGigg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Giggs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Venue = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Artist_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Giggs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Giggs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Giggs", new[] { "Genre_Id" });
            DropIndex("dbo.Giggs", new[] { "Artist_Id" });
            DropTable("dbo.Giggs");
            DropTable("dbo.Genres");
        }
    }
}
