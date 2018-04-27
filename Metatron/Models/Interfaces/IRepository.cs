using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metatron.Models.Interfaces
{
    interface IRepository<T>: IDisposable
        where T:class
    {
        IEnumerable<T> GetItemList();
        T GetItem(int id);
        void CreateItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id);
        void Save();
    }
}