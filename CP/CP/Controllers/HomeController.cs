﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;
using CP.Data;
using CP.Data.Models;
using  CP.Storage;
using CP.Web.Models;

namespace CP.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "user,admin")]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult IndexPost(string name)
        {
            using (IRepository<Data.Models.Image> imageRepository = new EfRepository<Data.Models.Image>())
            {
                imageRepository.Insert(new Data.Models.Image {NameImage = name,DateLoad = DateTime.Now});
            }
            /*IFileManager fileManager = new LocalFileManager(this.Server.MapPath(Path.Combine("~/Images/")));
            fileManager.SaveFile(fileBase.FileName, fileBase.InputStream);
            ImageModel img = new ImageModel
            {
                FileName = fileBase.FileName,
                FilePath = this.Server.MapPath(Path.Combine("~/Images/", fileBase.FileName))
            };*/
            return this.View("Index");
        }
    }
}