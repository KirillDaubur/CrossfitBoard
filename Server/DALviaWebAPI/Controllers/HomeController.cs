using DALviaWebAPI.DAL;
using DALviaWebAPI.Models;
using DALviaWebAPI.Models.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DALviaWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IRepository rep = new MsSqlRepository();
            //rep.AddUser(new User()
            //{
            //    RoleID = 0,
            //    FirstName = "Olga",
            //    LastName = "Kocherga",
            //    Age = 20,
            //    Email = "olga@gmail.com",
            //    Sex = "Female"
            //});
            //rep.AddUser(new User()
            //{
            //    RoleID = 1,
            //    FirstName = "Kirill",
            //    LastName = "Daubur",
            //    Age = 20,
            //    Email = "daubur@gmail.com",
            //    Sex = "Male"
            //});
            //rep.AddUser(new User()
            //{
            //    RoleID = 0,
            //    FirstName = "Alexander",
            //    LastName = "Grebeniuk",
            //    Age = 21,
            //    Email = "ggss@gmail.com",
            //    Sex = "Male"
            //});
            //rep.AddUser(new User()
            //{
            //    RoleID = 0,
            //    FirstName = "Valera",
            //    LastName = "Tkachev",
            //    Age = 19,
            //    Email = "valet@gmail.com",
            //    Sex = "Male"
            //});

            //rep.AddWardToTrainer(1, 2);
            //rep.AddWardToTrainer(3, 2);  

            //List<User> Users = rep.GetAllUsers();
            
            return View();
        }
    }
}
