using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Src { get; set; }
        public string Extension { get; set; }

        public int Rating { get; set; }
        public DateTime PublicationDate { get; set; }

        public bool IsApproved { get; set; }

        public int AlbumId { get; set; }
        public virtual AlbumEntity Album { get; set; }
    }
}
