using Microsoft.EntityFrameworkCore;

namespace Blog.Main
{
    public class BlogDbContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlePigeonholeClassification> PigeonholeClassifications { get; set; }
        public DbSet<Attach> Attaches { get; set; }
        public DbSet<UserAccount> AccountEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Tools.DatabaseFilePath};");
        }
    }
}