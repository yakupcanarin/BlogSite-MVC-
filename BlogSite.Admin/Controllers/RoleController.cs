using BlogSite.Core.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Admin.Controllers
{
    public class RoleController : Controller
    {
        #region Role Operations

        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        #endregion
        #region Get List

        public void RoleList()
        {
            var Roles = _roleRepository.GetMany(x => x.ID != 0).ToList();
            ViewBag.Roles = Roles;
        }
        #endregion

      
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
    }
}