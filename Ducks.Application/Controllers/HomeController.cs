using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ducks.Application.Controllers
{
    public class HomeController : Controller
    {
        private Models.DuckManager _manager;
        public HomeController()
        {

            _manager = new Models.DuckManager();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Feed()
        {
            return View(_manager.FeedLogEntry());
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Feed(Ducks.Application.Models.ViewModels.FeedingVM model)
        {
            // Run in serial
            return View("Complete", new Ducks.Application.Models.ViewModels.FeedingDetailsVM(await _manager.InsertFeedingRecord(model, User.Identity.Name)));
        }
         
    }
}