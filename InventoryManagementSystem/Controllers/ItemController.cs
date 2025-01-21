using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementSystem.Controllers
{
    public class ItemController : ApiController
    {
        [HttpGet]
        [Route("api/item/all")]
        public HttpResponseMessage Get()
        {
            var data = ItemService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

      

        [HttpPost]
        [Route("api/item/create")]
        public HttpResponseMessage Create(ItemDTO itemDTO)
        {
            if (itemDTO == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid item data.");
            }

            var createdItem = ItemService.Create(itemDTO);
            var responseMessage = new
            {
                message = "Item created successfully",
                item = createdItem
            };

            return Request.CreateResponse(HttpStatusCode.Created, responseMessage);

            //return Request.CreateResponse(HttpStatusCode.Created, createdItem);
        }
        [HttpDelete]
        [Route("api/item/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var isDeleted = ItemService.Delete(id);

            if (isDeleted)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Item deleted successfully" });
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found.");
        }

        [HttpPut]
        [Route("api/item/update/{id}")]
        public HttpResponseMessage Update(int id, ItemDTO itemDTO)
        {
            if (itemDTO == null || id != itemDTO.ItemId)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid item data or mismatched item ID.");
            }

            var updatedItem = ItemService.Update(itemDTO);

            // Return success message with updated item details
            var responseMessage = new
            {
                message = "Item updated successfully",
                item = updatedItem
            };

            return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
        }
      

        [HttpGet]
        [Route("api/item/category/{category}")]
        public HttpResponseMessage SearchByCategory(string category)
        {
            var data = ItemService.SearchByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpGet]
        [Route("api/item/search/{name}")]
        public HttpResponseMessage SearchByName(string name)
        {
            var data = ItemService.SearchByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


    }
}
