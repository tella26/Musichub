namespace MusicHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class OverridesCreateGigg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Giggs", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Giggs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Giggs", new[] { "Artist_Id" });
            DropIndex("dbo.Giggs", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Giggs", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Giggs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Giggs", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Giggs", "Artist_Id");
            CreateIndex("dbo.Giggs", "Genre_Id");
            AddForeignKey("dbo.Giggs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Giggs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Giggs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Giggs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Giggs", new[] { "Genre_Id" });
            DropIndex("dbo.Giggs", new[] { "Artist_Id" });
            AlterColumn("dbo.Giggs", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Giggs", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Giggs", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Giggs", "Genre_Id");
            CreateIndex("dbo.Giggs", "Artist_Id");
            AddForeignKey("dbo.Giggs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Giggs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
