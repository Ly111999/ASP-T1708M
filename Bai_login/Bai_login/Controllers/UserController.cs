using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai_login.Models;

namespace Bai_login.Controllers
{
    public class UserController : Controller
    {
        public UserDBContext db = new UserDBContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.tblUSer user)
        {
          
            var userDetail = db.tblUSers.FirstOrDefault(x => x.username == user.username && x.password == user.password);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            else
            {
                Session["id"] = userDetail.id;
                return RedirectToAction("Index", "Home");
            }
        }

        
    }
}
