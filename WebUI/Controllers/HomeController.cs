using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }

        #region АДД
        /// <summary>
        /// Меню АДД
        /// </summary>
        /// <returns></returns>
        public ActionResult ADD()
        {
            return View();
        }
        /// <summary>
        /// Меню ДЦ-2
        /// </summary>
        /// <returns></returns>
        public ActionResult BFS2()
        {
            return View();
        }
        /// <summary>
        /// Меню Загрузка
        /// </summary>
        /// <returns></returns>
        public ActionResult BFS2Unload()
        {
            return View();
        }
        #endregion

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// Отобразить ссылки
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public PartialViewResult MenuHierarchy(string list)
        {
            if (list == null) return null;
            return PartialView((object)list);
        }
        /// <summary>
        /// Смена культуры
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;

            List<string> cultures = new List<string>() { "ru", "en", "uk" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        [ChildActionOnly]
        public ActionResult Lock()
        {
            return PartialView();
        }
    }
}