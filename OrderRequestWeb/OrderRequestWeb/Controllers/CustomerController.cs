using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using OrderRequestWeb.Models;


namespace OrderRequestWeb.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private OrderRequestWeb.Models.CustomerModel.CustomerRegistrationInputModel model = new Models.CustomerModel.CustomerRegistrationInputModel();
        private BusinessLogicLayer.CustomerService CustomerService = new CustomerService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult register()
        {
            
            return View();
        }
        [Authorize]
        public JsonResult IsEmailExist(string EmailAddress)
        {
           
            if (CustomerService.IsEmailExixt(EmailAddress))
            {
                return Json("Sorry, this name already exists", JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }


    }
}
