using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Projector.Filters;
using Projector.Models;

namespace Projector.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class SignInController : Controller
    {
        //
        // GET: /SignIn/
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignInInputModel user)
        {
            ProjectorContext db=new ProjectorContext();
                PersonService service=new PersonService(db);
            if (ModelState.IsValid && service.SignIn(user))
            {
                Person p=service.userLogged(user);
                FormsAuthentication.SetAuthCookie(p.first_name, false);
                 return RedirectToAction("Index", "Projects");
 
            }
            return View(user);
        }

    }
}
