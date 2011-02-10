using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;

namespace KSULax.Models.Photo
{
    public class PhotographerModel
    {
        public PhotographerModel(PhotoGalleryBE pgBE)
        {
            Company = pgBE.PhotographerCompany;
            Name = pgBE.PhotographerName;
            URL = pgBE.PhotographerURL;
            PhotoGalleries = new List<PhotoGalleryModel>();
            PhotoGalleries.Add(new PhotoGalleryModel(pgBE));
        }

        public PhotographerModel(List<PhotoGalleryBE> pgBElst)
        {
            PhotoGalleries = new List<PhotoGalleryModel>();

            foreach (PhotoGalleryBE pgBE in pgBElst)
            {
                Company = pgBE.PhotographerCompany;
                Name = pgBE.PhotographerName;
                URL = pgBE.PhotographerURL;
                PhotoGalleries.Add(new PhotoGalleryModel(pgBE));
            }
        }

        public string Company { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public List<PhotoGalleryModel> PhotoGalleries { get; set; }
    }

    public class PhotoGalleryModel
    {
        public int GameID { get; set; }
        public string GalleryURL { get; set; }
        public string GalleryName { get; set; }

        public PhotoGalleryModel(PhotoGalleryBE pgBE)
        {
            GameID = pgBE.GameID;
            GalleryURL = pgBE.GalleryURL;
            GalleryName = pgBE.GalleryName;
        }
    }
}