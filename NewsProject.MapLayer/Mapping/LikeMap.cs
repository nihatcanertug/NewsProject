using NewsProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.MapLayer.Mapping
{
    public class LikeMap:BaseMap<Like>
    {
        public LikeMap()
        {
            HasRequired(x => x.AppUser).WithMany(x => x.Likes).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);
            HasRequired(x => x.NewsArticle).WithMany(x => x.Likes).HasForeignKey(x => x.NewsArticleId).WillCascadeOnDelete(false);
        }
    }
}
