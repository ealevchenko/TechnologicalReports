using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        [Access(LogVisit = true)]
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
            ViewBag.HierarchyMenu = "HOME:ADD";
            return View();
        }
        /// <summary>
        /// Меню Загрузка
        /// </summary>
        /// <returns></returns>
        public ActionResult BFS2Unload()
        {
            ViewBag.HierarchyMenu = "HOME:ADD;HOME:BFS2";
            return View();
        }
        /// <summary>
        /// Меню энергоресурсы
        /// </summary>
        /// <returns></returns>
        public ActionResult BFS2Energy()
        {
            ViewBag.HierarchyMenu = "HOME:ADD;HOME:BFS2";
            return View();
        }
        /// <summary>
        /// Меню ДЦ-1
        /// </summary>
        /// <returns></returns>
        public ActionResult BFS1()
        {
            ViewBag.HierarchyMenu = "HOME:ADD";
            return View();
        }
        /// <summary>
        /// Меню энергоресурсы
        /// </summary>
        /// <returns></returns>
        public ActionResult BFS1Energy()
        {
            ViewBag.HierarchyMenu = "HOME:ADD;HOME:BFS1";
            return View();
        }

        #endregion

        #region ЭД
        /// <summary>
        /// Меню ЭД
        /// </summary>
        /// <returns></returns>
        public ActionResult ED()
        {
            return View();
        }
        #endregion

        #region СТО
        /// <summary>
        /// Меню СТО
        /// </summary>
        /// <returns></returns>
        public ActionResult CTO()
        {
            return View();
        }
        /// <summary>
        /// Меню управления энергоэффективности
        /// </summary>
        /// <returns></returns>
        public ActionResult UPEE()
        {
            ViewBag.HierarchyMenu = "HOME:CTO";
            return View();
        }
        /// <summary>
        /// Меню энергоресурсы
        /// </summary>
        /// <returns></returns>
        public ActionResult UPEEEnergy()
        {
            ViewBag.HierarchyMenu = "HOME:CTO;HOME:UPEE";
            return View();
        }

        public ActionResult DATP()
        {
            ViewBag.HierarchyMenu = "HOME:CTO";
            return View();
        }

        public ActionResult DATPUG()
        {
            ViewBag.HierarchyMenu = "HOME:CTO;HOME:DATP";
            return View();
        }

        public ActionResult UGEnergy()
        {
            ViewBag.HierarchyMenu = "HOME:CTO;HOME:DATP;HOME:DATPUG";
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