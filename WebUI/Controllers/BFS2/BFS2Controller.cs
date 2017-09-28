using EFBF9.Abstract;
using EFBF9.Concrete;
using EFBF9.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.BFS2
{
    public class BFS2Controller : Controller
    {

        IBF9UnloadBunker unb;
        IBF9UnloadMaterial unm;

        public BFS2Controller(IBF9UnloadBunker unb, IBF9UnloadMaterial unm)
        {
            this.unb = unb;
            this.unm = unm;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnloadMaterial()
        {
            return View();
        }

        #region Отчет о загрузке БЗУ
        /// <summary>
        /// Вызвать главную форму
        /// </summary>
        /// <returns></returns>
        public ActionResult UnloadBunker()
        {
            //string d = Thread.CurrentThread.CurrentCulture.Name;
            ViewBag.dt_start = Thread.CurrentThread.CurrentCulture.Name=="en-US" ?  DateTime.Now.Date.ToString("MM/dd/yyyy 00:00") : DateTime.Now.Date.ToString("dd.MM.yyyy 00:00");
            ViewBag.dt_stop = Thread.CurrentThread.CurrentCulture.Name=="en-US" ? DateTime.Now.AddDays(1).Date.AddSeconds(-1).ToString("MM/dd/yyyy 23:59"): DateTime.Now.AddDays(1).Date.AddSeconds(-1).ToString("dd.MM.yyyy 23:59");
            return View();
        }
        /// <summary>
        /// Сформировать ajax отчет
        /// </summary>
        /// <param name="date_start"></param>
        /// <param name="date_stop"></param>
        /// <returns></returns>
        public PartialViewResult ReportUnloadBunker(DateTime date_start, DateTime date_stop)
        {
            List<UnloadBunker> list = new List<UnloadBunker>();
            list = this.unb.GetBF9UnloadBunker(date_start, date_stop);
            return PartialView(list);
        }
        #endregion

        #region Отчет о выгрузке материалов
        /// <summary>
        /// Вызвать главную форму
        /// </summary>
        /// <returns></returns>
        public ActionResult UnloadMaterialSmena()
        {
            ViewBag.dt = DateTime.Now.Date.ToShortDateString();
            return View();
        }

        public PartialViewResult ReportUnloadMaterialSmena(DateTime date)
        {
            List<UnloadMaterialSmena> list = new List<UnloadMaterialSmena>();
            list = this.unm.GetBF9UnloadMaterialSmena(date);
            if (list == null) return null;
            List<IGrouping<string, UnloadMaterialSmena>> group = list.GroupBy(l => l.Type).ToList();
            return PartialView(group);
        }
        #endregion
    }
}