using System;
using System.Collections.Generic;
using DDD_Demo.Domain;

namespace DDD_Demo.Db
{
    
    
    public static class DbRepository<T> where T : Entity , IAggregateRoot
    {
        public static List<T> _db = new List<T>();

        public static void Save(T obj)
        {
            //Ignore this its a massive hack because of the way 
            //C# does equality by default 
            if (_db.Exists(x => x.Id == obj.Id))
            {
                _db.Remove(_db.Find(x => x.Id == obj.Id));
            }

            _db.Add(obj);
        }

        public static T Get(Guid id)
        {
            return _db.Find(x => x.Id == id);
        }
    }
}
