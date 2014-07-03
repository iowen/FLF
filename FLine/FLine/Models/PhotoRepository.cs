using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public class PhotoRepository : IPhotoRepository
    {
        private FLDataDataContext db;

        public PhotoRepository(FLDataDataContext context)
        {
            db = context;
        }

        public List<Photo> getAllPhotos()
        {
            var photos = db.Photos.ToList();
            return photos;
        }

        public Photo getPhoto(int id)
        {
            try
            {
                var photo = db.Photos.Single(c => c.PhotoId == id);

                return photo;
            }
            catch
            {
                Photo p = new Photo();
                p.PhotoId = -1;
                return p;
            }
        }

        public int addPhoto(Photo photo)
        {
            db.Photos.InsertOnSubmit(photo);
            db.SubmitChanges();
            return photo.PhotoId;
        }

        public bool updatePhoto(Photo photo)
        {
            return true;
        }
    }
}