using System;
using System.Collections.Generic;
using System.Text;
using RealEstateWeb.Models.ViewModels.Bookmark;

namespace RealEstateWeb.Services.Contract
{
    public interface IBookmarkService
    {
        bool Create(int id, string username);

        void Remove(int id);
    }
}
