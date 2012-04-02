using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebRole1.Models;
using MvcWebRole1.Azure;

namespace MvcWebRole1.Controllers
{   
    public class ProductController : Controller
    {
		private readonly ProductRepository productRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ProductController()
        {
            this.productRepository = new ProductRepository();
        }

        //
        // GET: /Product/

        public ViewResult Index()
        {
            return View(productRepository.GetAll().ToList());
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(string partitionKey, string rowKey)
        {
            return View(productRepository.GetByID(partitionKey, rowKey));
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid) {
                productRepository.Create(product);
                productRepository.SaveChanges();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Product/Edit/5

        public ActionResult Edit(string partitionKey, string rowKey)
        {
             return View(productRepository.GetByID(partitionKey, rowKey));
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid) {
                productRepository.Update(product);
                productRepository.SaveChanges();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(string partitionKey, string rowKey)
        {
            return View(productRepository.GetByID(partitionKey, rowKey));
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string partitionKey, string rowKey)
        {
            var product = this.productRepository.GetByID(partitionKey, rowKey);
            productRepository.Delete(product);
            productRepository.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

