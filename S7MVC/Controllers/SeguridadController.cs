using S7MVC.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace S7MVC.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        // GET: seguridad
        private sieteEntidades db = new sieteEntidades();

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {


            var Existe = db.usuarios.Where(x => x.usu_email == model.Email && x.usu_clave == model.Password).Count();

            if (Existe == 0)
            {

                ViewBag.Error = "Usuarios Invalido";
                return RedirectToAction("index", "Home");
            }
            else
            {


                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);


                var _usu_idn = (from a in db.usuarios
                                where a.usu_email == model.Email
                                select a).FirstOrDefault();

                Session["usu_idn"] = _usu_idn.usu_idn;

                var _emp_usu_sed_idn = (from a in db.usuarios
                                        join b in db.empresas_usuarios_sedes on a.usu_idn equals b.usu_idn
                                        where a.usu_email == model.Email
                                        select b).FirstOrDefault();



                

                if (_emp_usu_sed_idn == null)
                {

                    Session["emp_usu_sed_idn"] = 0;


                }
                else
                {
                    Session["emp_usu_sed_idn"] = _emp_usu_sed_idn.emp_usu_sed_idn;

                }


                return RedirectToAction("index","Home");


            }

        }
        [AllowAnonymous]
        public ActionResult Logout(string returnUrl)
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");



        }


    }
}
