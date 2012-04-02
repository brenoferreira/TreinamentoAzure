using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using System.ServiceModel;

namespace MvcWebRole1.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            var serviceChannelFactory = new ChannelFactory<IProductServiceChannel>("products");

            try
            {
                using (var serviceChannel = serviceChannelFactory.CreateChannel())
                {
                    serviceChannel.AddProduct(product);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
