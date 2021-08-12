using JwhH5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JwhH5.Areas.ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ToDoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ToDoController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void InsertData(ToDoModel toDoModel)
        {
            SqlConnection connectionString = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=ServersideH5;Trusted_Connection=True;MultipleActiveResultSets=true");
            SqlCommand cmd = new SqlCommand(null, connectionString);
            cmd.CommandType = CommandType.StoredProcedure;

            connectionString.Open();

            cmd.CommandText = "INSERT INTO ToDo(Userid, Titel, Beskrivelse) VALUES (@UserName, @Titel, @Beskrivelse)";

            cmd.Parameters.AddWithValue("@UserName", toDoModel.UserName);
            cmd.Parameters.AddWithValue("@Titel", toDoModel.Titel);
            cmd.Parameters.AddWithValue("@Beskrivelse", toDoModel.Beskrivelse);
            cmd.ExecuteNonQuery();
            connectionString.Close();
        }


        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ToDoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
