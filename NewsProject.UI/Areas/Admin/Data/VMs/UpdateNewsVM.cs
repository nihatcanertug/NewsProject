using NewsProject.EntityLayer.Entities.Concrete;
using NewsProject.UI.Areas.Admin.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsProject.UI.Areas.Admin.Data.VMs
{
    public class UpdateNewsVM
    {
        public UpdateNewsVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
            NewsArticleDTO = new NewsArticleDTO();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }
        public NewsArticleDTO NewsArticleDTO { get; set; }

    }
}