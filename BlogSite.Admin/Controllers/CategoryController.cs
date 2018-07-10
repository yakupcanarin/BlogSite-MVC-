using BlogSite.Admin.Class;
using BlogSite.Core.InfraStructure;
using BlogSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BlogSite.Core.Repository;
using System.Web.UI;

namespace BlogSite.Admin.Controllers
{
    public class CategoryController : Controller
    {
        UserRepository _userRepository;
        #region Category    

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        public ActionResult UserData()
        {
            var id = TempData["ID"];
            return RedirectToAction("Index", "Home");
        }

        #region List
        [HttpGet]
        public ActionResult List(int page = 1)
        {
            return View(_categoryRepository.GetAll().OrderByDescending(x => x.ID).ToPagedList(page, 6));
        }
        #endregion

        #region Add
        [HttpGet]
        public ActionResult Insert()
        {
            var id = TempData["ID"];
            return View();
        }

        [HttpPost]
        public JsonResult Insert(Category category)
        {
            try
            {
                _categoryRepository.Insert(category);
                _categoryRepository.Save();
                return Json(new ResultJson { Success = true, Message = "New category added." });
            }
            catch (Exception)
            {
                return Json(new ResultJson { Success = false, Message = "New Category Couldn't Add." });
            }
        }
        #endregion

        #region Get List

        public void CategoryList()
        {
            var List = _categoryRepository.GetMany(x => x.ID != 0).ToList();
            ViewBag.List = List;
        }
        #endregion

        #region Delete
        public ActionResult Delete(int ID)
        {
            try
            {
                Category category = _categoryRepository.GetByID(ID);
                if (category == null)
                {
                    throw new Exception("Category couldn't found");
                }
                _categoryRepository.Delete(ID);
                _categoryRepository.Save();

                return RedirectToAction("List", "Category");
            }
            catch (Exception)
            {
                return Json(new ResultJson { Success = true, Message = "Category Couldn't Deleted." });
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Category category = _categoryRepository.GetByID(ID);
            if (category == null)
            {
                throw new Exception("Category Couldn't Found.");
            }
            CategoryList();
            return View(category);
        }

        [HttpPost]
        public JsonResult Update(Category category)
        {
            try
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Category Updated." });
            }
            catch (Exception)
            {
                return Json(new ResultJson { Success = true, Message = "Category Couldn't Update." });
            }
        }

        #endregion

    }
}