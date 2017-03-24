using ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Initializers;

namespace ORM
{
    public class GalleryContext : DbContext
    {
        static GalleryContext()
        {
            Database.SetInitializer(new GalleryDbInitializer());
        }

        public GalleryContext()
            :base()
        {

        }

        public virtual DbSet<AlbumEntity> Albums { get; set; }
        public virtual DbSet<ImageEntity> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Configurations.AlbumConfig());
            modelBuilder.Configurations.Add(new Configurations.ImageConfig());
        }

    }

}
