using System.Linq;
using ImageBase.Models;
using ORM.Entities;

namespace ImageBase.Mappers
{
    public static class OrmMappers
    {

        public static Image ToImage(this ImageEntity imageEntity)
        {
            return new Image
            {
                Id = imageEntity.Id,
                Name = imageEntity.Name,
                Src = imageEntity.Src,
                Extension = imageEntity.Extension,
                Rating = imageEntity.Rating,
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