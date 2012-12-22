using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautySalonManagement.Domain.Contracts.Tasks;
using BeautySalonManagement.Web.Mvc.Base;
using SharpArch.Domain.Commands;

namespace BeautySalonManagement.Web.Mvc.Controllers
{
    public class ReservationController : CustomControllerBase
    {
        //
        // GET: /Reservation/
        public ReservationController()
        {
            
        }
  

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Reservation/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Reservation/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Reservation/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Reservation/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Reservation/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Reservation/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Reservation/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
