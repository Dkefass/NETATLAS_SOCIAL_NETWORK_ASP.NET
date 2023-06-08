namespace NetAtlas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NetAtlasTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Liens",
                c => new
                    {
                        Lien_id = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Ressource_id_ressource = c.Int(),
                    })
                .PrimaryKey(t => t.Lien_id)
                .ForeignKey("dbo.Ressources", t => t.Ressource_id_ressource)
                .Index(t => t.Ressource_id_ressource);
            
            CreateTable(
                "dbo.ListeAmis",
                c => new
                    {
                        ListeAmisId = c.Int(nullable: false, identity: true),
                        date_amitie = c.DateTime(),
                        email_amis = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Membre_email = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.ListeAmisId)
                .ForeignKey("dbo.Membres", t => t.Membre_email)
                .Index(t => t.email_amis, unique: true)
                .Index(t => t.Membre_email);
            
            CreateTable(
                "dbo.Membres",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128, unicode: false),
                        nom = c.String(nullable: false, maxLength: 8000, unicode: false),
                        prenom = c.String(nullable: false, maxLength: 8000, unicode: false),
                        sexe = c.String(nullable: false, maxLength: 8000, unicode: false),
                        mot_de_passe = c.String(nullable: false),
                        date_de_cretaation = c.DateTime(),
                        image_url = c.String(),
                        statut = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.email)
                .Index(t => t.email, unique: true);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        id_publication = c.Int(nullable: false, identity: true),
                        date_de_publication = c.DateTime(),
                        Membre_email = c.String(maxLength: 128, unicode: false),
                        Ressource_id_ressource = c.Int(),
                    })
                .PrimaryKey(t => t.id_publication)
                .ForeignKey("dbo.Membres", t => t.Membre_email)
                .ForeignKey("dbo.Ressources", t => t.Ressource_id_ressource)
                .Index(t => t.Membre_email)
                .Index(t => t.Ressource_id_ressource);
            
            CreateTable(
                "dbo.TypeAmis",
                c => new
                    {
                        id_typeamis = c.Int(nullable: false, identity: true),
                        nom_type = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Membre_email = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.id_typeamis)
                .ForeignKey("dbo.Membres", t => t.Membre_email)
                .Index(t => t.nom_type, unique: true)
                .Index(t => t.Membre_email);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        message_id = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Ressource_id_ressource = c.Int(),
                    })
                .PrimaryKey(t => t.message_id)
                .ForeignKey("dbo.Ressources", t => t.Ressource_id_ressource)
                .Index(t => t.Ressource_id_ressource);
            
            CreateTable(
                "dbo.ReponseMessages",
                c => new
                    {
                        reponsemessage_id = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Ressource_id_ressource = c.Int(),
                    })
                .PrimaryKey(t => t.reponsemessage_id)
                .ForeignKey("dbo.Ressources", t => t.Ressource_id_ressource)
                .Index(t => t.Ressource_id_ressource);
            
            CreateTable(
                "dbo.PhotoVideos",
                c => new
                    {
                        photovideo_id = c.Int(nullable: false, identity: true),
                        nom_photovideo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        photovideo_url = c.String(),
                        Taille = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Ressource_id_ressource = c.Int(),
                    })
                .PrimaryKey(t => t.photovideo_id)
                .ForeignKey("dbo.Ressources", t => t.Ressource_id_ressource)
                .Index(t => t.Ressource_id_ressource);
            
            CreateTable(
                "dbo.Ressources",
                c => new
                    {
                        id_ressource = c.Int(nullable: false, identity: true),
                        nom_ressource = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.id_ressource)
                .Index(t => t.nom_ressource, unique: true);
            
            CreateTable(
                "dbo.ReponseMessageMessages",
                c => new
                    {
                        ReponseMessage_reponsemessage_id = c.Int(nullable: false),
                        Message_message_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReponseMessage_reponsemessage_id, t.Message_message_id })
                .ForeignKey("dbo.ReponseMessages", t => t.ReponseMessage_reponsemessage_id, cascadeDelete: true)
                .ForeignKey("dbo.Messages", t => t.Message_message_id, cascadeDelete: true)
                .Index(t => t.ReponseMessage_reponsemessage_id)
                .Index(t => t.Message_message_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReponseMessages", "Ressource_id_ressource", "dbo.Ressources");
            DropForeignKey("dbo.Publications", "Ressource_id_ressource", "dbo.Ressources");
            DropForeignKey("dbo.PhotoVideos", "Ressource_id_ressource", "dbo.Ressources");
            DropForeignKey("dbo.Messages", "Ressource_id_ressource", "dbo.Ressources");
            DropForeignKey("dbo.Liens", "Ressource_id_ressource", "dbo.Ressources");
            DropForeignKey("dbo.ReponseMessageMessages", "Message_message_id", "dbo.Messages");
            DropForeignKey("dbo.ReponseMessageMessages", "ReponseMessage_reponsemessage_id", "dbo.ReponseMessages");
            DropForeignKey("dbo.TypeAmis", "Membre_email", "dbo.Membres");
            DropForeignKey("dbo.Publications", "Membre_email", "dbo.Membres");
            DropForeignKey("dbo.ListeAmis", "Membre_email", "dbo.Membres");
            DropIndex("dbo.ReponseMessageMessages", new[] { "Message_message_id" });
            DropIndex("dbo.ReponseMessageMessages", new[] { "ReponseMessage_reponsemessage_id" });
            DropIndex("dbo.Ressources", new[] { "nom_ressource" });
            DropIndex("dbo.PhotoVideos", new[] { "Ressource_id_ressource" });
            DropIndex("dbo.ReponseMessages", new[] { "Ressource_id_ressource" });
            DropIndex("dbo.Messages", new[] { "Ressource_id_ressource" });
            DropIndex("dbo.TypeAmis", new[] { "Membre_email" });
            DropIndex("dbo.TypeAmis", new[] { "nom_type" });
            DropIndex("dbo.Publications", new[] { "Ressource_id_ressource" });
            DropIndex("dbo.Publications", new[] { "Membre_email" });
            DropIndex("dbo.Membres", new[] { "email" });
            DropIndex("dbo.ListeAmis", new[] { "Membre_email" });
            DropIndex("dbo.ListeAmis", new[] { "email_amis" });
            DropIndex("dbo.Liens", new[] { "Ressource_id_ressource" });
            DropTable("dbo.ReponseMessageMessages");
            DropTable("dbo.Ressources");
            DropTable("dbo.PhotoVideos");
            DropTable("dbo.ReponseMessages");
            DropTable("dbo.Messages");
            DropTable("dbo.TypeAmis");
            DropTable("dbo.Publications");
            DropTable("dbo.Membres");
            DropTable("dbo.ListeAmis");
            DropTable("dbo.Liens");
        }
    }
}
