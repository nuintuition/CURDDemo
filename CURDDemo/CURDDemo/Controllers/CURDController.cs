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
            return View(new MyTableModel());
        }

        // POST: CURD/Create
        [HttpPost]
        public ActionResult Create(MyTableModel item) {
            try {
                string query = "INSERT INTO MyTable VALUES(@Name,@Value)";
                _db.Execute(query, item);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: CURD/Edit/5
        public ActionResult Edit(int id) {
            string query = "SELECT * FROM MyTable Where Id = @Id";
            List<MyTableModel> myTableList = _db.Query<MyTableModel>(query, new { id }).ToList();
            if (myTableList.Any()) {
                return View(myTableList.First());
            } else {
                return RedirectToAction("Index");
            }
        }

        // POST: CURD/Edit/5
        [HttpPost]
        public ActionResult Edit(MyTableModel item) {
            try {
                string query = "UPDATE MyTable SET Name = @Name , Value= @Value WHere Id = @Id";
                _db.Execute(query, item);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: CURD/Delete/5
        public ActionResult Delete(int id) {
            try {
                string query = "DELETE FROM MyTable WHere Id = @Id";
                _db.Execute(query, new { id });
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
