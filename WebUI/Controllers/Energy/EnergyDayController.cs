using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TReport.TData;
using TReport.TREntities;
using WebUI.Infrastructure;

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

        public ActionResult BFS2(string HierarchyMenu)
        {
            ViewBag.HierarchyMenu = "HOME:ADD;HOME:BFS2;HOME:BFS2Energy";
            if (!String.IsNullOrWhiteSpace(HierarchyMenu)) {
                ViewBag.HierarchyMenu = HierarchyMenu;
            } 
            ViewBag.dt = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            return View();
        }

        public ActionResult ADD(string HierarchyMenu)
        {
            ViewBag.HierarchyMenu = "HOME:ADD;HOME:BFS2;HOME:BFS2Energy";
            if (!String.IsNullOrWhiteSpace(HierarchyMenu)) {
                ViewBag.HierarchyMenu = HierarchyMenu;
            } 
             ViewBag.dt = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            return View();
        }

        [ViewAuthorize(Roles = @"EUROPE\KRR-LG-PA-TR_ADD_Leaders, EUROPE\KRR-LG-PA-TR_BFS2_Leaders, EUROPE\KRR-LG-PA-TR_BF9_Technolog, EUROPE\KRR-LG-PA-TR_DATP_Leaders , EUROPE\KRR-LG-PA-TR_DATP_BFS2_Engineer , EUROPE\KRR-LG-PA-TR_Developers")]
        public RedirectToRouteResult EnergySutkiADDForBFS2()
        {
            string HierarchyMenu = "HOME:ADD;HOME:BFS2;HOME:BFS2Energy";
            return RedirectToAction("BFS2", "EnergyDay", new { HierarchyMenu });
        }        
        
        [ViewAuthorize(Roles = @"EUROPE\KRR-LG-PA-TR_ADD_Leaders, EUROPE\KRR-LG-PA-TR_DATP_Leaders , EUROPE\KRR-LG-PA-TR_Developers")]
        public RedirectToRouteResult EnergySutkiADDForADD()
        {
            string HierarchyMenu = "HOME:ADD;HOME:BFS2;HOME:BFS2Energy";
            return RedirectToAction("ADD", "EnergyDay", new { HierarchyMenu });
        }
        [ViewAuthorize(Roles = @"EUROPE\KRR-LG-PA-TR_ED_EEM, EUROPE\KRR-LG-PA-TR_DATP_Leaders , EUROPE\KRR-LG-PA-TR_Developers")]
        public RedirectToRouteResult EnergySutkiADDForUPEE()
        {
            string HierarchyMenu = "HOME:CTO;HOME:UPEE;HOME:UPEEEnergy";
            return RedirectToAction("ADD", "EnergyDay", new { HierarchyMenu });
        }

        [ViewAuthorize(Roles = @"EUROPE\KRR-LG-PA-TR_DATP_AG, EUROPE\KRR-LG-PA-TR_DATP_Leaders , EUROPE\KRR-LG-PA-TR_Developers")]
        public RedirectToRouteResult EnergySutkiADDForDATPUG()
        {
            string HierarchyMenu = "HOME:CTO;HOME:DATP;HOME:DATPUG;HOME:UGEnergy";
            return RedirectToAction("ADD", "EnergyDay", new { HierarchyMenu });
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