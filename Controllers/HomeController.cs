using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private TasksContext TcContext { get; set; }
        public HomeController(TasksContext tasks)
        {
            TcContext = tasks;
        }
        public IActionResult Index()
        {
            return View();
        }
     
        [HttpGet]
        public IActionResult TaskEntry()
        {
            ViewBag.Categories = TcContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult TaskEntry(TaskEntry te)
        {
            if (ModelState.IsValid)
            {
                TcContext.Add(te);
                TcContext.SaveChanges();
                return View("Index", te);
            }
            else
            {
                ViewBag.Categories = TcContext.Categories.ToList();
                return View(te);
            }
        }
        public IActionResult Quadrants()
        {
            var tasks = TcContext.Tasks
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Edit (int taskid)
        {
            ViewBag.Categories = TcContext.Categories.ToList();

            var tasks = TcContext.Tasks.Single(x => x.TaskId == taskid);
            return View("TaskEntry", tasks);
        }
        [HttpPost]
        public IActionResult Edit (TaskEntry te)
        {
            TcContext.Update(te);
            TcContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }

        //delete functions
        [HttpGet]
        public IActionResult Delete (int taskid)
        {
            var task = TcContext.Tasks.Single(x => x.TaskId == taskid);
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete (TaskEntry te)
        {
            TcContext.Tasks.Remove(te);
            TcContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
