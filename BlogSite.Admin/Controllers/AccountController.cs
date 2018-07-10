using BlogSite.Core.InfraStructure;
using BlogSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region User
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public int UserID;

        [HttpPost]
        public ActionResult Login(User user)
        {
            
            User UserControl = _userRepository.GetMany(x => x.Email == user.Email && x.Password == user.Password && x.Status == true).SingleOrDefault();
            if (UserControl != null)
            {
                
                if (UserControl.Role.RoleName == "Admin")
                {
                    Session["Email"] = UserControl.Email;
                    TempData["ID"] = UserControl.ID;
                    return RedirectToAction("UserData","Category");
                }
                ViewBag.Message = "Invalid User";
                return View();
            }
            ViewBag.Message = "The user couldn't find";
            return View();
        }

    }
}