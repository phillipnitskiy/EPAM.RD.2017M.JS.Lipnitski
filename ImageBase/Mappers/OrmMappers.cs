using System.Linq;
using ImageBase.Models;
using ORM.Entities;

namespace ImageBase.Mappers
{
    public static class OrmMappers
    {

        public static Image ToImage(this ImageEntity imageEntity)
        {

            var rating = ((double)imageEntity.RatingSum / imageEntity.RatersCount).ToString("N1");
            return new Image
            {
                Id = imageEntity.Id,
                Name = imageEntity.Name,
                Src = imageEntity.Src,
                Extension = imageEntity.Extension,
                Rating = rating,
                PublicationDate = imageEntity.PublicationDate.ToString(),
                IsApproved = imageEntity.IsApproved,
                AlbumId = imageEntity.AlbumId
            };
        }

        public static Album ToAlbum(this AlbumEntity albumEntity)
        {
            return new Album
            {
                Id = albumEntity.Id,
                Name = albumEntity.Name
            };
        }

    }
}