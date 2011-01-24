using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSULax.Entities
{
    public class PhotographerBE
    {
        public int PhotographerID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string URL { get; set; }
        public List<PhotoGalleryBE> Galleries { get; set; }
        public List<PhotoBE> Photos { get; set; }
    }

    public class PhotoGalleryBE
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public PhotographerBE photographer { get; set; }
        public int GameID { get; set; }
    }

    public class PhotoBE
    {
        public string URL { get; set; }
        public string LocalURL { get; set; }
        public int GameID { get; set; }
        public PhotographerBE photographer { get; set; }
    }
}