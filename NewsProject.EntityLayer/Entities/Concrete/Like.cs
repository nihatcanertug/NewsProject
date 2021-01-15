using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.EntityLayer.Entities.Concrete
{
    public class Like:BaseEntity
    {
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int NewsArticleId { get; set; }
        public virtual NewsArticle NewsArticle { get; set; }
    }
}
