using NewsProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsProject.UI.Areas.Admin.Data.VMs
{
    public class AddNewsVM
    {
        public AddNewsVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
        }

        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }
    }
}