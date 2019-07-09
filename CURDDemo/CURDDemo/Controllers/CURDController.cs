using CURDDemo.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDDemo.Controllers {
    public class CURDController : Controller {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString);
        
        // GET: CURD
        [HttpGet]
        public ActionResult Index() {
            List<MyTableModel> myTableList = _db.Query<MyTableModel>("SELECT * FROM MyTable").ToList();
            return View(myTableList);
        }

        // GET: CURD/Create
        public ActionResult Create() {
            return View();
        }

        // POST: CURD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: CURD/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: CURD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: CURD/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: CURD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
