using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Blog.EntityModels;
namespace Blog.MVC
{
    public class BlogDBContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlePigeonholeClassification> PigeonholeClassifications { get; set; }
        public DbSet<Attach> Attaches { get; set; }
        public DbSet<UserAccountEntity> AccountEntities { get; set; }
        public DbSet<UserAccountInfo> AccountInfos { get; set; }
        public DbSet<UserOpertionLog> OpertionLogs { get; set; }
    }
}