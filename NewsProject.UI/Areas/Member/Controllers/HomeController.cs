using NewsProject.DataAccessLayer.Repositories.Concrete.EfRepository;
using NewsProject.UI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsProject.UI.Areas.Member.Controllers
{
    [LoginControl]
    public class HomeController : Controller
    {
        EfNewsArticleRepository _newsRepository;

        public HomeController() => _newsRepository = new EfNewsArticleRepository();



        // GET: Member/Home
        public ActionResult Index()
        {
            return View(_newsRepository.GetActive().OrderByDescending(x=>x.CreateDate));
        }
    }
}