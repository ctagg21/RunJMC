using RunJMC.Data.Repositories;
using RunJMC.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunJMC1.Controllers
{
    public class EntriesController : Controller
    {
        // GET: Entries
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContent(Entry entry)
        {
            var repo = new EntriesRepository();
            
            entry.Title = "Test Blog Post";
            entry.CategoryId = 1;
            entry.UserId = "00000000-0000-0000-0000-000000000000";
            repo.AddEntry(entry);
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            var repo = new EntriesRepository();
            var entry = repo.GetEntryById(7);
            return View(entry);
        }
    }
}