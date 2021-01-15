using NewsProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsProject.UI.Areas.Member.Data.VMs
{
    public class NewsArticleVM
    {
        public NewsArticleVM()
        {
            AppUsers = new List<AppUser>();
            Comments = new List<Comment>();
            AppUser = new AppUser();
            NewsArticle = new NewsArticle();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Comment> Comments { get; set; }
        public AppUser AppUser { get; set; }
        public NewsArticle NewsArticle { get; set; }

        public int CommentCount { get; set; }
        public int LikeCount { get; set; }


    }
}