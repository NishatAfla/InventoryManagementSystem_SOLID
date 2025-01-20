using DAL.EF;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   
        public class DataAccess 
        {
        public static IRepo<Item, int, Item> ItemData()
        {
            return new ItemRepo();
        }
        public static IItemFeatures ItemFeatures()
        {
            return new ItemRepo();
        }
    }
    

}
