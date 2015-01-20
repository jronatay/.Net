using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projector.Models;

namespace Projector.Controllers
{
    public class SignInController : Controller
    {
        //
        // GET: /SignIn/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SignInInputModel user)
        {
            if (ModelState.IsValid)
            {
                ProjectorContext db=new ProjectorContext();
                PersonService service=new PersonService(db);

                if (service.SignIn(user))
                {
                    return RedirectToAction("Index","Projects");
                }
                else
                {
                    return View();
                }
                //if successfull
            }
            return View(user);
        }

    }
}
