using System;

namespace ImageBase.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Src { get; set; }
        public string Extension { get; set; }

        public int Rating { get; set; }
        public string PublicationDate { get; set; }

        public bool IsApproved { get; set; }

        public int AlbumId { get; set; }
    }
}
