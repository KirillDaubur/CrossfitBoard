using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DALviaWebAPI.Controllers
{
    public class ProfileController : Controller
    {        
       [HttpGet]
        public ActionResult Profile(UserDto user )
        {
            return View(user);
        }

       [HttpGet]
       public ActionResult GoToWardList(UserDto user)
       {
           return RedirectToAction("WardList", "WardList", user);
       }
    }
}
