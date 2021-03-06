﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers.Metrics
{
    public class MetricController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /Metric/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            return View(db.Metrics.ToList());
        }

        // GET: /Metric/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // GET: /Metric/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Metric/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MetricID,Name,Type")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Metrics.Add(metric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metric);
        }

        // GET: /Metric/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // POST: /Metric/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MetricID,Name,Type")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // GET: /Metric/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // POST: /Metric/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Metric metric = db.Metrics.Find(id);
            db.Metrics.Remove(metric);
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