using BlogSite.Admin.Class;
using BlogSite.Core.InfraStructure;
using BlogSite.Core.Repository;
using BlogSite.Data.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Admin.Controllers
{
    public class UserController : Controller
    {

        #region Users

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Return List

        [HttpGet]
        public ActionResult List(int page = 1)
        {
            return View(_userRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(page, 6));
        }
        #endregion

        #region Get List

        public void UserList()
        {
            var List = _userRepository.GetMany(x => x.ID != 0).ToList();
            ViewBag.List = List;
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int ID)
        {
            User user = _userRepository.GetByID(ID);
            if (user == null)
            {
                throw new Exception("User Couldn't Found.");
            }
            UserList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            try
            {
                _userRepository.Update(user);
                _userRepository.Save();
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        #endregion
    }
}