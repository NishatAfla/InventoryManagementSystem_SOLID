using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IItemFeatures
    {
        List<Item> SearchByName(string name);
    }
}
