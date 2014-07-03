using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FLine.Models
{
    public interface IPhotoRepository
    {
        List<Photo> getAllPhotos();
        Photo getPhoto(int id);

        int addPhoto(Photo photo);
        bool updatePhoto(Photo photo);
    }
}