﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using PagedList;

namespace CalorieTracker.Controllers.Foods
{
    public class FoodController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /Food/
        /// <summary>
        ///     List Foods and Search Foods
        /// </summary>
        /// <param name="sortOrder">Sort Preference</param>
        /// <param name="currentFilter">Food Filter</param>
        /// <param name="searchString">Search String</param>
        /// <param name="page">Page Number</param>
        /// <returns>Pagnated List Of Search Results Or All Foods</returns>
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (String.IsNullOrEmpty(sortOrder)) ViewBag.NameSortParm = "Name_desc";
            else ViewBag.NameSortParm = "";
            if (sortOrder == "Description") ViewBag.DescSortParm = "Description_desc";
            else ViewBag.DescSortParm = "Description";
            if (sortOrder == "FoodGroup") ViewBag.FoodGroupSortParm = "FoodGroup_desc";
            else ViewBag.FoodGroupSortParm = "FoodGroup";

            if (searchString != null) //Lets search
            {
                page = 1;
                searchString = searchString.Trim();
            }
            else searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            IQueryable<Food> foodsCollection = db.Foods.Include(f => f.FoodGroup);
            if (!string.IsNullOrEmpty(searchString))
            {
                foodsCollection = foodsCollection.Where(
                    f =>
                        f.Name.ToUpper().Contains(searchString.ToUpper()) ||
                        f.Description.ToUpper().Contains(searchString.ToUpper()) ||
                        f.ManufactureName.ToUpper().Contains(searchString.ToUpper()));
            }
            if (string.IsNullOrEmpty(sortOrder)) foodsCollection = foodsCollection.OrderBy(f => f.Name);
            else if (sortOrder.Equals("Name_desc")) foodsCollection = foodsCollection.OrderByDescending(f => f.Name);
            else if (sortOrder.Equals("Description")) foodsCollection = foodsCollection.OrderBy(f => f.Description);
            else if (sortOrder.Equals("Description_desc")) foodsCollection = foodsCollection.OrderByDescending(f => f.Description);
            else if (sortOrder.Equals("FoodGroup")) foodsCollection = foodsCollection.OrderBy(f => f.FoodGroup.Name);
            else if (sortOrder.Equals("FoodGroup_desc")) foodsCollection = foodsCollection.OrderByDescending(f => f.FoodGroup.Name);

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(foodsCollection.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        ///     Search Food Partial
        ///     Used On FoodLog Page
        /// </summary>
        /// <param name="id">searchString</param>
        /// <param name="message">pageNumber</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchFood(string id, int? message)
        {
            string searchString = id;
            int? page = message;

            if (searchString != null)
            {
                if (page == null) page = 1;
                searchString = searchString.Trim();
            }

            IQueryable<Food> foods = db.Foods.Include(f => f.FoodGroup);

            if (!string.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(
                    f =>
                        f.Name.ToUpper().Contains(searchString.ToUpper()) ||
                        f.Description.ToUpper().Contains(searchString.ToUpper()) ||
                        f.ManufactureName.ToUpper().Contains(searchString.ToUpper()));
            }
            foods = foods.OrderBy(f => f.Name);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView("_SearchFood", foods.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // GET: /Food/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            ViewBag.GroupID = new SelectList(db.FoodGroups.OrderBy(item => item.Name), "FoodGroupID", "Name");
            return View();
        }

        // POST: /Food/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "FoodID,SourceID,ParentID,GroupID,Name,Description,ManufactureName")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.GroupID);
            return View(food);
        }

        // GET: /Food/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.GroupID);
            return View(food);
        }

        // POST: /Food/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "FoodID,SourceID,ParentID,GroupID,Name,Description,ManufactureName")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.GroupID);
            return View(food);
        }

        // GET: /Food/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // POST: /Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
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