using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interface;
using DAL.Repos;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ItemService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Item, ItemDTO>();
                cfg.CreateMap<ItemDTO, Item>();
             
            });
            return new Mapper(config);
        }

        public static List<ItemDTO> Get()
        {
            var repo = DataAccess.ItemData();
            return GetMapper().Map<List<ItemDTO>>(repo.Get());
        }
        public static ItemDTO Get(int id)
        {
            var repo = DataAccess.ItemData();
            return GetMapper().Map<ItemDTO>(repo.Get(id));
        }
        public static ItemDTO Create(ItemDTO newItemDTO)
        {
            var repo = DataAccess.ItemData();

            // Map DTO to Entity
            var newItem = GetMapper().Map<Item>(newItemDTO);

            // Save to database
            var createdItem = repo.Create(newItem);

            // Map Entity back to DTO
            return GetMapper().Map<ItemDTO>(createdItem);
        }
        public static bool Delete(int id)
        {
            var repo = DataAccess.ItemData();
            return repo.Delete(id);
        }

          public static List<ItemDTO> SearchByName(string name)
           {
              var repo = DataAccess.ItemData();
               var data = repo.Get();
               var filter = data.Where(x => x.Name.Contains(name)).ToList();
            return GetMapper().Map<List<ItemDTO>>(data);



        }

        public static ItemDTO Update(ItemDTO updatedItemDTO)
        {
            var repo = DataAccess.ItemData();

            // Map DTO to Entity
            var updatedItem = GetMapper().Map<Item>(updatedItemDTO);

            // Update the item in the database
            var updatedEntity = repo.Update(updatedItem);

            // Map Entity back to DTO for response
            return GetMapper().Map<ItemDTO>(updatedEntity);
        }
    }
}
