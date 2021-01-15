using NewsProject.EntityLayer.Entities.Concrete;
using NewsProject.MapLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.DataAccessLayer.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=NIHOO;Database=NewsProdectDb;uid=nihatcan;pwd=123;";
        }

        public DbSet<Category>Categories { get; set; }
        public DbSet<NewsArticle>NewsArticles { get; set; }
        public DbSet<AppUser>AppUsers { get; set; }
        public DbSet<Comment>Comments { get; set; }
        public DbSet<Like>Likes { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new LikeMap());
            modelBuilder.Configurations.Add(new NewsArticleMap());

            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
