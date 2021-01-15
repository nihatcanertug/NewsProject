using NewsProject.DataAccessLayer.Repositories.Concrete.EfRepository;
using NewsProject.EntityLayer.Entities.Concrete;
using NewsProject.EntityLayer.Enums;
using NewsProject.UI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewsProject.UI.Controllers
{
    public class AccountController : Controller
    {
        EfAppUserRepository _appUserRepo;

        public AccountController() => _appUserRepo = new EfAppUserRepository();

        // GET: Account
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = _appUserRepo.FindByUserName(HttpContext.User.Identity.Name);
                if (appUser.Status != Status.Passive)
                {
                    if (appUser.Role == Role.Admin)
                    {
                        string cookie = appUser.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = appUser.FirstName + " " + appUser.LastName;
                        Session["ImagePath"] = appUser.UserImage;
                        return Redirect("/Admin/Home/Index");
                    }
                    else if (appUser.Role == Role.Author)
                    {
                        string cookie = appUser.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = appUser.FirstName + " " + appUser.LastName;
                        Session["ImagePath"] = appUser.UserImage;
                        return Redirect("/Author/Home/Index");
                    }
                    else
                    {
                        string cookie = appUser.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = appUser.FirstName + " " + appUser.LastName;
                        Session["ImagePath"] = appUser.UserImage;
                        return Redirect("/Member/Home/Index");
                    }
                }
                else
                {
                    ViewData["error"] = "Please register out web side..!";
                    return View();
                }
            }
            else
            {
                TempData["class"] = "custom-hide";
                return View();
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                if (_appUserRepo.CheckCredential(loginDTO.UserName, loginDTO.Password))
                {
                    AppUser appUser = _appUserRepo.FindByUserName(loginDTO.UserName);
                    if (appUser.Status != Status.Passive)
                    {
                        if (appUser.Role == Role.Admin)
                        {
                            string cookie = appUser.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = appUser.FirstName + " " + appUser.LastName;
                            Session["ImagePath"] = appUser.UserImage;
                            return Redirect("/Admin/Home/Index");
                        }
                        else if (appUser.Role == Role.Author)
                        {
                            string cookie = appUser.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = appUser.FirstName + " " + appUser.LastName;
                            Session["ImagePath"] = appUser.UserImage;
                            return Redirect("/Author/Home/Index");
                        }
                        else
                        {
                            string cookie = appUser.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = appUser.FirstName + " " + appUser.LastName;
                            Session["ImagePath"] = appUser.UserImage;
                            return Redirect("/Member/Home/Index");
                        }
                    }
                    else
                    {
                        ViewData["error"] = "Please register out web side..!";
                        return View();
                    }
                }
                else
                {
                    ViewData["error"] = "Credantion info are wrong..!";
                    return View(loginDTO);
                }
            }
            else
            {
                TempData["class"] = "custom-hide";
                return View(loginDTO);
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}