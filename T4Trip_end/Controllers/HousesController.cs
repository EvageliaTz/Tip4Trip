﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T4Trip_end.Models;
using T4Trip_end.ViewModels;


namespace T4Trip_end.Controllers
{
    public class HousesController : Controller
    {
        private T4TContext db = new T4TContext();

        // GET: Houses
        public ActionResult Index()
        {
            var houses = db.Houses.Include(h => h.Location).Include(xxx=>xxx.Reservations);
            return View(houses.ToList());
        }

        public ActionResult mazi(int idilicious)
        {
        
            //List<House> housesList = db.Houses.ToList();
            // var housesViewModelList = housesList.Select(x => new HouseReservationViewModel { House = x, Reservations1 = x.Reservations }).ToList();
            var housesList = db.Houses.Include(c => c.Location).Include(y => y.Reservations).Where(xs=>xs.Id.Equals(idilicious)).ToList();
            var ReservationsList = db.Reservations.ToList();
            if (idilicious > 0 && idilicious <= ReservationsList.Count())
            {
                HouseReservationViewModel ViewModel = new HouseReservationViewModel
            {
                House = housesList.Last(),
                Reservations1 = ReservationsList


            };
            
                return View(ViewModel);
            }
            else
            { return Content("Wrong Id , Try again"); }
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "NameCity");
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Owner,Address,Description,LocationId,MaxOccupancy,PriceperNight")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "NameCity", house.LocationId);
            return View(house);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "NameCity", house.LocationId);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Owner,Address,Description,LocationId,MaxOccupancy,PriceperNight")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "NameCity", house.LocationId);
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
