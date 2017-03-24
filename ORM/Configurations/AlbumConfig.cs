using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class AlbumConfig : EntityTypeConfiguration<AlbumEntity>
    {
        public AlbumConfig()
        {
            HasKey(a => a.Id);

            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}