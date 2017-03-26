using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class ImageConfig : EntityTypeConfiguration<ImageEntity>
    {
        public ImageConfig()
        {
            HasKey(i => i.Id);

            Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(i => i.Src)
                .IsRequired()
                .HasMaxLength(50);

            Property(i => i.Extension)
                .IsRequired()
                .HasMaxLength(5);

            Property(i => i.RatersCount)
                .IsRequired();
            Property(i => i.RatingSum)
                .IsRequired();
            Property(i => i.PublicationDate)
                .IsRequired();

            Property(i => i.IsApproved)
                .IsRequired();

            HasRequired(i => i.Album)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.AlbumId)
                .WillCascadeOnDelete(false);
        }
    }
}