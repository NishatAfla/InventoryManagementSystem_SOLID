using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ItemRepo : Repo, IRepo<Item, int, Item>, IItemFeatures
    {
        public Item Create(Item obj)
        {
            db.Item.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Item.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Item Get(int id)
        {
            return db.Item.Find(id);
        }

        public List<Item> Get()
        {
            return db.Item.ToList();
        }

       public List<Item> SearchByName(string name)
        {
            return db.Item.Where(x => x.Name.Contains(name)).ToList();
        }

        public Item Update(Item obj)
        {
            var ex = Get(obj.ItemId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }
    }
}
