using MVC_WebApp.db.Models;
using System.Collections.Generic;

namespace MVC_WebApp.db
{
    public interface IFavouriteDbRepository
    {
        List<Product> GetFavourites(string userid);
    }
}