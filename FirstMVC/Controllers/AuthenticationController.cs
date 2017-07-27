using BusinessEntities;
using BusinessLayer;
using FirstMVC.Cryptography;
using FirstMVC.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FirstMVC.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            //Chack browser cababilities
            var browser = Request.Browser;

            CultureInfo uiCulture = Thread.CurrentThread.CurrentUICulture;
            return View();
        }

        [HttpPost]
        //Използва се когато binding model-а е weakly-typed за да се намапне от view -то към параметрите на метода
        //public ActionResult DoLogin([Bind(Prefix="user")]UserDetails userDetails) 
        public ActionResult DoLogin(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                UserDetailsBusinessLayer bol = new UserDetailsBusinessLayer();
                //New Code Start
                UserStatus status = bol.GetUserValidity(userDetails);
                bool IsAdmin = false;
                if (status == UserStatus.AuthenticatedAdmin)
                {
                    IsAdmin = true;
                }
                else if (status == UserStatus.AuthentucatedUser)
                {
                    IsAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }
                //FormsAuthentication.SetAuthCookie(userDetails.UserName, true);

                string sessionID = Guid.NewGuid().ToString();

                Session.Add(sessionID, IsAdmin);
                CreatingFormsAuthentication(userDetails, sessionID);

                RijndaelAlgorithm crypter = new RijndaelAlgorithm(userDetails);
                crypter.EncryptData();

                return RedirectToAction("Index", "Employee");
                //New Code End
            }
            else
            {
                return View("Login");
            }
        }
               
        /// <summary>
        /// Creating authorization cookies, this method is as SetAuthCookie()
        /// </summary>
        /// <param name="userDetails"></param>
        /// <param name="sessionID"></param>
        private void CreatingFormsAuthentication(UserDetails userDetails, string sessionID)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            1,
            userDetails.UserName,
            DateTime.Now,
            DateTime.Now.AddDays(90),
            true,
            sessionID);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket); //FormsAuthentication.FormsCookieName
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
        }
      
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        //Remote validation
        public JsonResult IsUserAvailable(string UserName)
        {
            UserDetailsBusinessLayer bol = new UserDetailsBusinessLayer();
            if (!bol.UserExists(UserName))//!WebSecurity.UserExists(username))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            string suggestedUID = String.Format(CultureInfo.InvariantCulture,
            "{0} is not available.", UserName);
            for (int i = 1; i < 100; i++)
            {
                string altCandidate = UserName + i.ToString();
                if (!bol.UserExists(altCandidate))//!WebSecurity.UserExists(altCandidate))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "{0} is not available. Try {1}.", UserName, altCandidate);
                    break;
                }
            }
            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        public void Authenticate(string uname, string pass)
        {
            //User user = dbContext.Users.First(x => x.UserName.Equals(uname();
            //if (user != null && user.Password.Equals(EncryptHash(pass))
            //{
            //    FormsAuthentication.SetAuthCookie(uname, false);
            //    RedirectToAction("Main", "DashBoard");
            //}
            //// unable to login
            //RenderView("Index", new LoginViewData
            //{
            //    ErrorMessage = "Invalid credentials."
            //});
        }
    }
}