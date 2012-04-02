using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebRole1.Azure;

namespace MvcWebRole1.Controllers
{
    public class MessagesController : Controller
    {
        //
        // GET: /Messages/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string message)
        {
            var queueClient = new QueueClient();

            queueClient.AddMessage(message);

            return View();
        }
    }
}
