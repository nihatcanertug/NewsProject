using NewsProject.DataAccessLayer.Repositories.Concrete.EfRepository;
using NewsProject.EntityLayer.Entities.Concrete;
using NewsProject.EntityLayer.Enums;
using NewsProject.UI.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsProject.UI.Areas.Member.Controllers
{
    [LoginControl]
    public class CommentController : Controller
    {
        EfCommentRepository _commentRepo;
        EfAppUserRepository _appUserRepo;
        EfNewsArticleRepository _postRepo;
        EfLikeRepository _likeRepo;

        public CommentController()
        {
            _commentRepo = new EfCommentRepository();
            _appUserRepo = new EfAppUserRepository();
            _postRepo = new EfNewsArticleRepository();
            _likeRepo = new EfLikeRepository();
        }

        public JsonResult AddComment(string userComment, int id)
        {
            Comment comment = new Comment();

            comment.AppUserId = _appUserRepo.FindByUserName(HttpContext.User.Identity.Name).Id;
            comment.NewsArticleId = id;
            comment.Text = userComment;

            bool isAdded = false;
            try
            {
                _commentRepo.Add(comment);
                isAdded = true;
            }
            catch (Exception)
            {
                isAdded = false;
            }

            return Json(isAdded);
        }

        public JsonResult GetComment(int id)
        {
            Comment comment = _commentRepo.GetDefault(x => x.NewsArticleId == id && x.Status != Status.Passive).LastOrDefault();

            return Json(new
            {
                AppUserImagePath = comment.AppUser.UserImage,
                FirstName = comment.AppUser.FirstName,
                LastName = comment.AppUser.LastName,
                CreateDate = comment.CreateDate.ToShortDateString(),
                CommentText = comment.Text,
                CommentCount = _commentRepo.GetDefault(x => x.NewsArticleId == id && x.Status != Status.Passive).Count(),
                LikeCount = _likeRepo.GetDefault(x => x.NewsArticleId == id && x.Status != Status.Passive).Count(),
            });
        }

        public JsonResult DeleteComment(int id)
        {
            int appUserId = _appUserRepo.FindByUserName(HttpContext.User.Identity.Name).Id;
            Comment comment = _commentRepo.GetById(id);
            bool isDelete = false;


            if (comment.AppUserId == appUserId)
            {
                _commentRepo.Remove(comment.Id);
                isDelete = true;
                return Json(isDelete);
            }
            else
            {
                isDelete = false;
                return Json(isDelete);
            }
        }
    }
}