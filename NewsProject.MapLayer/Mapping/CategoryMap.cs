using NewsProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.MapLayer.Mapping
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            Property(x => x.Name).IsRequired();

            HasMany(x => x.NewsArticles).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
        }
    }
}
