using NewsProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.MapLayer.Mapping
{
    public class CommentMap:BaseMap<Comment>
    {
        public CommentMap()
        {
            Property(x => x.Text).HasMaxLength(500).IsRequired();

            HasRequired(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);
            HasRequired(x => x.NewsArticle).WithMany(x => x.Comments).HasForeignKey(x => x.NewsArticleId).WillCascadeOnDelete(false);
        }
    }
}
