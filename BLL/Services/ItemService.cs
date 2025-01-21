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
            var repo = DataAccess.ItemFeatures(); // Use the correct interface to access SearchByName
            var data = repo.SearchByName(name);  // Get filtered data directly from the repo
            return GetMapper().Map<List<ItemDTO>>(data); // Map the filtered data to DTOs
        }

        public static List<ItemDTO> SearchByCategory(string category)
        {
            var repo = DataAccess.ItemFeatures(); // Use the correct interface to access SearchByCategory
            var data = repo.SearchByCategory(category); // Get filtered data directly from the repo
            return GetMapper().Map<List<ItemDTO>>(data); // Map the filtered data to DTOs
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
        public static ItemDTO GetDetails(int id)
        {
            var repo = DataAccess.ItemData(); // Access the repository
            var item = repo.Get(id); // Fetch the item by ID
            if (item == null)
            {
                throw new Exception("Item not found"); // Handle item not found
            }
            // Map the item to an ItemDTO and return only relevant fields
            return new ItemDTO
            {
                ItemId = item.ItemId,
                Name = item.Name,
                SellingPrice = item.SellingPrice,
                Description = item.Description,
                Quantity = item.Quantity,
                Category = item.Category,
                AddedDate = item.AddedDate
            };
        }


    }
}
