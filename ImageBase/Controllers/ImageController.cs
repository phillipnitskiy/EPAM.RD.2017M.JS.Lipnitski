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

        public JsonResult GetAll()
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

        public JsonResult AddImageAjax(string name, string src, int albumId, int rating, string extension)
        {
            var dataIndex = src.IndexOf("base64", StringComparison.Ordinal) + 7;
            var cleareData = src.Substring(dataIndex);
            var fileData = Convert.FromBase64String(cleareData);
            var bytes = fileData.ToArray();

            var path = GetPathToImg($"{name}.{extension}");
            using (var fileStream = System.IO.File.Create(path))
            {
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();
            }
            var album = db.Albums.First(a => a.Id == albumId);

            var newImage = new ImageEntity
            {
                Album = album,
                Name = name,
                Src = $"{name}.{extension}",
                Extension = extension,
                IsApproved = true,
                PublicationDate = DateTime.Now,
                RatingSum = rating,
                RatersCount = 1
            };

            db.Images.Add(newImage);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private string GetPathToImg(string fileName)
        {
            var serverPath = Server.MapPath("~");
            return Path.Combine(serverPath, "Content", "img", fileName);
        }

        public JsonResult Delete(int imageId)
        {
            var imageToRemove = db.Images.FirstOrDefault(i => i.Id == imageId);

            if (imageToRemove != null)
            {
                db.Images.Remove(imageToRemove);
                db.SaveChanges();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Rate(int imageId, int rating)
        {
            var imageToUpdate = db.Images.FirstOrDefault(i => i.Id == imageId);

            if (imageToUpdate == null)
                return Json(true, JsonRequestBehavior.AllowGet);

            imageToUpdate.RatingSum += rating;
            imageToUpdate.RatersCount += 1;
            db.SaveChanges();

            var newRating = ((double)imageToUpdate.RatingSum / imageToUpdate.RatersCount).ToString("N1");

            return Json(new {Rating = newRating}, JsonRequestBehavior.AllowGet);
        }
    }
}