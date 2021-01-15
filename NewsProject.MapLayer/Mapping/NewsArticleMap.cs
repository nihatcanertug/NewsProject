using NewsProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.MapLayer.Mapping
{
    public class NewsArticleMap:BaseMap<NewsArticle>
    {
        public NewsArticleMap()
        {
            Property(x => x.Header).IsRequired();
            Property(x => x.Content).IsRequired();
           

            HasMany(x => x.Comments).WithRequired(x => x.NewsArticle).HasForeignKey(x => x.NewsArticleId).WillCascadeOnDelete(false);
            HasMany(x => x.Likes).WithRequired(x => x.NewsArticle).HasForeignKey(x => x.NewsArticleId).WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser).WithMany(x => x.NewsArticles).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);
            HasRequired(x => x.Category).WithMany(x => x.NewsArticles).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);

        }
    }
}
