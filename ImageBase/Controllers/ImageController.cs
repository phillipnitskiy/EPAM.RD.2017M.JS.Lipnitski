using ImageBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageBase.Mappers;
using ORM;
using ORM.Entities;

namespace ImageBase.Controllers
{
    public class ImageController : Controller
    {
        private GalleryContext db = new GalleryContext();

        public JsonResult GetAllImages()
        {
            var images = db.Images.ToList().Select(i => i.ToImage()).ToList();
            images.ForEach(i => i.Src = Url.Content("~/Content/img/" + i.Src));
            
            return Json(images, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAlbumImages(int id)
        {
            List<Image> images;
            if (id == 0)
            { 
                images = db.Images
                    .ToList()
                    .Select(i => i.ToImage())
                    .ToList();
            }
            else
            {
                images = db.Albums
                    .FirstOrDefault(a => a.Id == id)
                    ?.Images
                    .ToList()
                    .Select(i => i.ToImage())
                    .ToList();
            }
            images?.ForEach(i => i.Src = Url.Content("~/Content/img/" + i.Src));

            return Json(images, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAlbumNames()
        {
            var albums = db.Albums
                .Select(a => new {Id = a.Id, Name = a.Name})
                .ToList();
            albums.Insert(0, new { Id = 0, Name = "All" });

            return Json(albums, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddImageAjax(string fileName, string data)
        {
            var dataIndex = data.IndexOf("base64", StringComparison.Ordinal) + 7;
            var cleareData = data.Substring(dataIndex);
            var fileData = Convert.FromBase64String(cleareData);
            var bytes = fileData.ToArray();

            var path = GetPathToImg(fileName);
            using (var fileStream = System.IO.File.Create(path))
            {
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private string GetPathToImg(string fileName)
        {
            var serverPath = Server.MapPath("~");
            return Path.Combine(serverPath, "Content", "img", fileName);
        }

        public JsonResult DeleteImage(int imageId)
        {
            var imageToRemove = db.Images.FirstOrDefault(i => i.Id == imageId);

            if (imageToRemove != null)
            {
                db.Images.Remove(imageToRemove);
                db.SaveChanges();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}