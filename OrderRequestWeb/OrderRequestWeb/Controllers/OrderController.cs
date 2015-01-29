using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLibrary;
using EntityLibrary.OrderModels;
using BusinessLogicLayer;

namespace OrderRequestWeb.Controllers
{
    public class OrderController : Controller
    {
        private BusinessLogicLayer.OrderService OrderService = new OrderService();
        //
        // GET: /Order/
        
        public ActionResult Index()
        {
            return View(OrderService.OrderProductInputList());
        }
        [HttpPost]
        public ActionResult Index(EntityLibrary.OrderModels.OrderRequestInputModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (OrderService.IsRequestedStoredInTemporaryStorage(OrderService.PopulatedOrderProductFromRequest(model)))
                {

                    return RedirectToAction("OrderCheck",model);
                }
                else
                {
                    ModelState.AddModelError("", "At Least One Product with at least 1 Quantity needed to Process Order");
                    return View(OrderService.OrderProductInputList());
                }
            }
            return View(OrderService.OrderProductInputList());
        }

        public ActionResult OrderCheck(EntityLibrary.OrderModels.OrderRequestInputModel model)
        {

            return View(OrderService.ReturnOrderProductsStored(OrderService.PopulatedOrderProductFromRequest(model)));
        }

    }
}
