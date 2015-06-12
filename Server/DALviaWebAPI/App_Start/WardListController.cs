using DALviaWebAPI.DAL;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DALviaWebAPI.App_Start
{
    public class WardListController : Controller
    {

        IRepository rep = new MsSqlRepository();

        public ActionResult WardList(UserDto trainre)
        {
            List<Int32> ids = rep.GetWardIDsOfCurrentTrainer(trainre.ID);
            List<UserDto> res = new List<UserDto>();
            ids.ForEach(item => {
                UserDto addable = Converter.FromUserToDto(rep.GetUserByID(item));
                res.Add(addable);
            });
            return View(res);
        }

    }
}
