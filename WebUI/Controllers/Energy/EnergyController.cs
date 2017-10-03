using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TReport.TData;
using TReport.TREntities;

namespace WebUI.Controllers.Energy
{
    public class EnergyDayController : Controller
    {
        // GET: Energy
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult EnergyDay(string title, DateTime date, trObj[] obj)
        {
            ViewBag.Title = title;
            ViewBag.dt = date.Date.ToShortDateString();
            ViewBag.obj = obj;
            return PartialView();
        }

        public PartialViewResult ReportEnergyDay(DateTime date, trObj[] obj)
        {

            TREnergy tre = new TREnergy(obj);
            tre.GetEnergySutki(date);
            return PartialView(tre.ListGroupEnergyValue);
        }

        public ActionResult BFS2()
        {
            ViewBag.dt = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            return View();
        }

        public ActionResult ADD()
        {
            ViewBag.dt = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            return View();
        }



        //public PartialViewResult EnergySutki(string title, DateTime date, string obj)
        //{
        //    ViewBag.Title = title;
        //    ViewBag.dt = date.Date.ToShortDateString();

        //    string[] arrobj = obj.Split(';');
        //    List<trObj> list = new List<trObj>();
        //    foreach (string sobj in arrobj)
        //    {
        //        if (!String.IsNullOrWhiteSpace(sobj))
        //        {
        //            list.Add((trObj)Enum.Parse(typeof(trObj), sobj));
        //        }
        //    }
        //    ViewBag.obj = obj;
        //    return PartialView();
        //}    
     

    }
}