using NewsProject.DataAccessLayer.Repositories.Concrete.EfRepository;
using NewsProject.EntityLayer.Enums;
using NewsProject.UI.Areas.Member.Data.VMs;
using NewsProject.UI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsProject.UI.Areas.Member.Controllers
{
    [LoginControl]
    public class NewsArticleController : Controller
    {
        EfNewsArticleRepository _newsRepo;
        EfAppUserRepository _appUserRepo;
        EfLikeRepository _likeRepo;
        EfCommentRepository _commentRepo;


        public NewsArticleController()
        {
            _newsRepo = new EfNewsArticleRepository();
            _appUserRepo = new EfAppUserRepository();
            _likeRepo = new EfLikeRepository();
            _commentRepo = new EfCommentRepository();
        }
        // GET: Member/NewsArticle
        public ActionResult Show(int id)
        {
            NewsArticleVM data = new NewsArticleVM();
            data.NewsArticle = _newsRepo.GetById(id);
            data.AppUser = _appUserRepo.GetById(data.NewsArticle.AppUserId);

            data.Comments = _commentRepo.GetDefault(x => x.NewsArticleId == id && x.Status != Status.Passive);

            data.CommentCount = _commentRepo.GetDefault(x => x.NewsArticleId == id && x.Status != Status.Passive).Count;
            data.LikeCount = _likeRepo.GetDefault(x => x.NewsArticleId == id && x.Status != Status.Passive).Count;
            return View();
        }
    }
}