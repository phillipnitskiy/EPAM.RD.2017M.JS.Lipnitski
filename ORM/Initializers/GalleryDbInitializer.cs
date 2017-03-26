using System;
using System.Collections.Generic;
using System.Data.Entity;
using ORM.Entities;

namespace ORM.Initializers
{
    //CreateDatabaseIfNotExists
    public class GalleryDbInitializer : DropCreateDatabaseAlways<GalleryContext>
    {
        protected override void Seed(GalleryContext context)
        {

            var albums = new List<AlbumEntity>
            {
                new AlbumEntity {Name = "Human"},
                new AlbumEntity {Name = "Animal"}
            };

            context.Albums.AddRange(albums);

            var images = new List<ImageEntity>
            {
                new ImageEntity {
                    Album  = albums[0],
                    Name = "White hum",
                    Src = @"placeHolder.png",
                    Extension = "png",
                    IsApproved = true,
                    PublicationDate = DateTime.Now,
                    RatingSum = 10,
                    RatersCount = 3
                },
                new ImageEntity {
                    Album  = albums[0],
                    Name = "White human",
                    Src = @"placeHolder.png",
                    Extension = "png",
                    IsApproved = true,
                    PublicationDate = DateTime.Now,
                    RatingSum = 9,
                    RatersCount = 3
                },
                new ImageEntity {
                    Album  = albums[1],
                    Name = "White man",
                    Src = @"placeHolder.png",
                    Extension = "png",
                    IsApproved = true,
                    PublicationDate = DateTime.Now,
                    RatingSum = 15,
                    RatersCount = 3
                },
                new ImageEntity {
                    Album  = albums[1],
                    Name = "Wolf",
                    Src = @"wolf.jpg",
                    Extension = "jpg",
                    IsApproved = true,
                    PublicationDate = DateTime.Now,
                    RatingSum = 5,
                    RatersCount = 5
                }
            };

            context.Images.AddRange(images);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}