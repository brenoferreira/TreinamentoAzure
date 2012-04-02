using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebRole1.Azure;

namespace MvcWebRole1.Controllers
{
    public class PhotosController : Controller
    {
        private BlobStorage blobStorage;

        public PhotosController()
        {
            this.blobStorage = new BlobStorage();
        }

        public ActionResult Index()
        {
            var blobs = this.blobStorage.GetPhotos();

            return View(blobs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(String Description)
        {
            var file = Request.Files["photo"];

            var photoInfo = new
            {
                Name = file.FileName,
                Description = Description
            };

            blobStorage.AddPhoto(photoInfo, file.InputStream);

            return View();
        }
    }
}
