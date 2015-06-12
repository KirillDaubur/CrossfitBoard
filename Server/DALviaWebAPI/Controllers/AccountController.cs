using DALviaWebAPI.DAL;
using DALviaWebAPI.Models.DatabaseEntities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DALviaWebAPI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View(new UserDto());
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new UserDto());
        }
       

        [HttpPost]
        public ActionResult Login(UserDto user)
        {
            IRepository rep = new MsSqlRepository();
            User result = rep.GetUserByEmail(user.Email);
            
            if(result != null)
            {
                return RedirectToAction("Profile", "Profile", Converter.FromUserToDto(result));
            }
            else
            {
                ViewBag.ErrorMessage = "Wrong Username or password!";
                return View();
            }
           
            
        }

        [HttpPost]
        public ActionResult Register(UserDto user)
        {
            try
            {
                IRepository rep = new MsSqlRepository();
                User result = Converter.FromDtoToUser(user);
                rep.AddUser(result);
                return View("Login");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(user);
            }
        }
    }
}
