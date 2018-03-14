using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;

namespace NPGeek.Web.Controllers
{
    public class ParkController : Controller
    {
        IParkDAL dal;

        public ParkController(IParkDAL dal)
        {
            this.dal = dal;
        }


        // GET: Park
        public ActionResult Detail(string parkCode)
        {
            Park park = dal.GetParkByParkCode(parkCode);

            return View("Detail", park);
                
        }
    }
}