using System;
using System.Linq;

namespace Repository
{
    public interface IRepository<T> where T:new()
    {
        void AddItem(T item);
        void Delete(T item);
        void Delete(string uid);
        T Search(string uid);
        IQueryable<T> Search();
        void Update(string oldid, T newitem);
        

    }
}
