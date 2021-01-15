using NewsProject.DataAccessLayer.Repositories.Concrete.EfRepository;
using NewsProject.EntityLayer.Entities.Concrete;
using NewsProject.EntityLayer.Enums;
using NewsProject.UI.Areas.Admin.Data.DTOs;
using NewsProject.UI.Areas.Admin.Data.VMs;
using NewsProject.UI.Models.Attributes;
using NewsProject.Utility.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsProject.UI.Areas.Admin.Controllers
{
    [LoginControl]
    public class NewsArticleController : Controller
    {
        EfNewsArticleRepository _newsRepo;
        EfCategoryRepository _categoryRepo;
        EfAppUserRepository _appUserRepo;

        public NewsArticleController()
        {
            _newsRepo = new EfNewsArticleRepository();
            _categoryRepo = new EfCategoryRepository();
            _appUserRepo = new EfAppUserRepository();
        }
       
        // GET: Admin/Post
        public ActionResult Create()
        {
            AddNewsVM model = new AddNewsVM()
            {
                Categories = _categoryRepo.GetActive(),
                AppUsers = _appUserRepo.GetDefault(x => x.Role != Role.Member)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NewsArticle data, HttpPostedFileBase Image)
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadImagePaths[0];

            if (data.ImagePath == "1" || data.ImagePath == "2" || data.ImagePath == "3")
            {
                data.ImagePath = ImageUploader.DefaultProfileImagePath;
                data.ImagePath = ImageUploader.DefaultXSmallProfileImagePath;
                data.ImagePath = ImageUploader.DefaultCruptedProfileImagePath;
            }
            else
            {
                data.ImagePath = UploadImagePaths[1];
                data.ImagePath = UploadImagePaths[2];
            }

            _newsRepo.Add(data);
            return Redirect("/Admin/NewsArticle/List");
        }

        public ActionResult List()
        {
            return View(_newsRepo.GetActive());
        }

        public ActionResult Update(int id)
        {
            NewsArticle newsArticle = _newsRepo.GetById(id);
            UpdateNewsVM data = new UpdateNewsVM();
            data.NewsArticleDTO.Id = newsArticle.Id;
            data.NewsArticleDTO.Header = newsArticle.Header;
            data.NewsArticleDTO.Content = newsArticle.Content;
            data.NewsArticleDTO.ImagePath = newsArticle.ImagePath;
            data.Categories = _categoryRepo.GetActive();
            data.AppUsers = _appUserRepo.GetDefault(x => x.Role != Role.Member);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(NewsArticleDTO data, HttpPostedFileBase Image)
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadImagePaths[0];

            NewsArticle newsArticle = _newsRepo.GetById(data.Id);

            if (data.ImagePath == "1" || data.ImagePath == "2" || data.ImagePath == "3")
            {
                if (newsArticle.ImagePath == null || newsArticle.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    newsArticle.ImagePath = ImageUploader.DefaultProfileImagePath;
                    newsArticle.ImagePath = ImageUploader.DefaultXSmallProfileImagePath;
                    newsArticle.ImagePath = ImageUploader.DefaultCruptedProfileImagePath;
                }
            }
            else
            {
                newsArticle.ImagePath = UploadImagePaths[0];
                newsArticle.ImagePath = UploadImagePaths[1];
                newsArticle.ImagePath = UploadImagePaths[2];
            }

            newsArticle.Header = data.Header;
            newsArticle.Content = data.Content;
            newsArticle.CategoryId = data.CategoryId;
            newsArticle.AppUserId = data.AppUserId;
            newsArticle.Status = Status.Active;
            newsArticle.UpdateDate = DateTime.Now;
            _newsRepo.Update(newsArticle);
            return Redirect("/Admin/NewsArticle/List");
        }

        public ActionResult Delete(int id)
        {
            _newsRepo.Remove(id);
            return Redirect("/Admin/NewsArticle/List");
        }
    }
}