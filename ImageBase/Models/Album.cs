using System.Collections.Generic;

namespace ImageBase.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Image> Images { get; set; }

        public Album()
        {
            Images = new List<Image>();
        }
    }
}