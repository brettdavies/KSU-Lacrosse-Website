using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;
using KSULax.Models;
using KSULax.Controllers;
using System.Data.Objects.DataClasses;

namespace KSULax.Logic
{
    public class MediaBL
    {
        KSULaxEntities _entities;

        public MediaBL(KSULaxEntities entitity) { _entities = entitity; }

        public List<PhotoGalleryBE> PhotoGalleriesBySeason(int season_id)
        {
            var photogalleries = new List<PhotoGalleryEntity>(_entities.PhotoGallerySet
                      .Include("Photographers")
                      .Include("Games")
                      .Where("it.Games.game_season_id = " + season_id)
                      .OrderBy("it.Games.game_date")
                      .OrderBy("it.url")
                      .ToList());

            var result = new List<PhotoGalleryBE>();

            foreach (PhotoGalleryEntity photoE in photogalleries)
            {
                result.Add(GetEntity(photoE));
            }
            return result;
        }

        /// <summary>
        /// Converts a PhotoGalleryEntity object to a PhotoGallery object
        /// </summary>
        /// <param name="photoE">PhotoGalleryEntity to convert</param>
        /// <returns></returns>
        private PhotoGalleryBE GetEntity(PhotoGalleryEntity photoGalleryE)
        {
            if (null == photoGalleryE)
            {
                return null;
            }

            var result = new PhotoGalleryBE
            {
                GameID = photoGalleryE.Game.id,
                Name = photoGalleryE.text,
                photographer = GetEntity(photoGalleryE.Photographer),
                URL = photoGalleryE.url
            };
            return result;
        }

        /// <summary>
        /// Converts a PhotographerEntity object to a Photographer object
        /// </summary>
        /// <param name="photoE">PhotoGalleryEntity to convert</param>
        /// <returns></returns>
        private PhotographerBE GetEntity(PhotographerEntity photographerE)
        {
            if (null == photographerE)
            {
                return null;
            }

            var result = new PhotographerBE
            {
               Company = photographerE.company,
               Galleries = GetEntity(photographerE.PhotoGalleries),
               Name = photographerE.name,
               PhotographerID = photographerE.photographer_id,
               Photos = GetEntity(photographerE.Photos),
               URL = photographerE.url
            };
            return result;
        }

        /// <summary>
        /// Converts a PhotoEntity object to a Photo object
        /// </summary>
        /// <param name="photoE">PhotoEntity to convert</param>
        /// <returns></returns>
        private PhotoBE GetEntity(PhotoEntity photoE)
        {
            if (null == photoE)
            {
                return null;
            }

            var result = new PhotoBE
            {
                GameID = photoE.Game.id,
                LocalURL = photoE.local_url,
                photographer = GetEntity(photoE.Photographer),
                URL = photoE.url
            };
            return result;
        }

        /// <summary>
        /// Converts a Collection of PhotoEntity objects to a List of Photo objects
        /// </summary>
        /// <param name="photoEntityColl">PhotoEntityCollection to convert</param>
        /// <returns></returns>
        private List<PhotoBE> GetEntity(EntityCollection<PhotoEntity> photoEntityColl)
        {
            if (null == photoEntityColl)
            {
                return null;
            }

            var result = new List<PhotoBE>();

            foreach (PhotoEntity pe in photoEntityColl)
            {
                result.Add(GetEntity(pe));
            }
            
            return result;
        }

        /// <summary>
        /// Converts a Collection of PhotoEntity objects to a List of PhotoGallery objects
        /// </summary>
        /// <param name="photoGalleryEntityColl">PhotoGalleryEntityCollection to convert</param>
        /// <returns></returns>
        private List<PhotoGalleryBE> GetEntity(EntityCollection<PhotoGalleryEntity> photoGalleryEntityColl)
        {
            if (null == photoGalleryEntityColl)
            {
                return null;
            }

            var result = new List<PhotoGalleryBE>();

            foreach (PhotoGalleryEntity pge in photoGalleryEntityColl)
            {
                result.Add(GetEntity(pge));
            }

            return result;
        }
    }
}