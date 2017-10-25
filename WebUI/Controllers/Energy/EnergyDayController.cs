using EFTReports.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TReport.TData;
using TReport.TREntities;
using TReport.TRForms;
using WebUI.Infrastructure;

namespace WebUI.Controllers.Energy
{
    [Access(LogVisit = true)]
    public class EnergyDayController : Controller
    {
        // GET: Energy
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult EnergyDay(string title, DateTime date, trObj[] obj, TREnergy.Report[] reports)
        {
            ViewBag.Title = title;
            ViewBag.dt = date.Date.ToShortDateString();
            ViewBag.obj = obj;
            ViewBag.reports = reports;
            return PartialView();
        }
        /// <summary>
        /// Отчет потребления энергоресурсов АДД
        /// </summary>
        /// <param name="date"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PartialViewResult ReportEnergyDay(DateTime date, trObj[] obj, TREnergy.Report[] reports)
        {
            TREnergy tre = new TREnergy(obj,reports);
            tre.GetReports(date);
            return PartialView(tre.ReportForms);
        }
        /// <summary>
        /// Показать форму отчета расходы за сутки
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public PartialViewResult ViewFormEnergyFlowDay(Form form)
        {
            if (form == null) return null;
            return PartialView(form);
        }
        /// <summary>
        /// Показать форму отчета среднесуточные
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public PartialViewResult ViewFormEnergyAVGDay(Form form)
        {
            if (form == null) return null;
            return PartialView(form);
        }
        /// <summary>
        /// Показать форму отчета грануляция
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public PartialViewResult ViewFormEnergyGranulDay(Form form)
        {
            if (form == null) return null;
            return PartialView(form);
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

        public ActionResult BFS1(string HierarchyMenu)
        {
            ViewBag.HierarchyMenu = "HOME:ADD;HOME:BFS1;HOME:BFS1Energy";
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

        public RedirectToRouteResult EnergySutkiADDForBFS2()
        {
            string HierarchyMenu = "HOME:ADD;HOME:BFS2;HOME:BFS2Energy";
            return RedirectToAction("BFS2", "EnergyDay", new { HierarchyMenu });
        }

        public RedirectToRouteResult EnergySutkiADDForBFS1()
        {
            string HierarchyMenu = "HOME:ADD;HOME:BFS1;HOME:BFS1Energy";
            return RedirectToAction("BFS1", "EnergyDay", new { HierarchyMenu });
        } 
        
        public RedirectToRouteResult EnergySutkiADDForADD()
        {
            string HierarchyMenu = "HOME:ADD;HOME:BFS2;HOME:BFS2Energy";
            return RedirectToAction("ADD", "EnergyDay", new { HierarchyMenu });
        }

        public RedirectToRouteResult EnergySutkiADDForUPEE()
        {
            string HierarchyMenu = "HOME:CTO;HOME:UPEE;HOME:UPEEEnergy";
            return RedirectToAction("ADD", "EnergyDay", new { HierarchyMenu });
        }

        public RedirectToRouteResult EnergySutkiADDForDATPUG()
        {
            string HierarchyMenu = "HOME:CTO;HOME:DATP;HOME:DATPUG;HOME:UGEnergy";
            return RedirectToAction("ADD", "EnergyDay", new { HierarchyMenu });
        }

    }
}