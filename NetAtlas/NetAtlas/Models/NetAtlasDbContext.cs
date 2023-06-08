using System.Data.Entity;

namespace NetAtlas.Models
{
    public class NetAtlasDbContext : DbContext
    {

        public  NetAtlasDbContext() :base("NetAtlasDB")
        {
            
        }
        
        public DbSet<Membre> Membre { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ReponseMessage> ReponseMessage { get; set; }
        public DbSet<Publication> Publication { get; set; }
        public DbSet<Ressource> Ressource { get; set; }
        public DbSet<ListeAmis> ListeAmis { get; set; }
        public DbSet<TypeAmis> TypeAmis { get; set; }
        public DbSet<PhotoVideo> PhotoVideo{ get; set; }
        public DbSet<Lien> Lien { get; set; }
    }
}
