namespace NetAtlas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NetAtlasTables1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListeAmis", "Membres_mail", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            CreateIndex("dbo.ListeAmis", "Membres_mail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ListeAmis", new[] { "Membres_mail" });
            DropColumn("dbo.ListeAmis", "Membres_mail");
        }
    }
}
