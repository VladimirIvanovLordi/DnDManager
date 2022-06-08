using AppService.DTOs;
using AppService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ItemService.svc or ItemService.svc.cs at the Solution Explorer and start debugging.
    public class ItemService : IItemService
    {
        private ItemManagementService itemManagementService = new ItemManagementService();

        public List<ItemDTO> GetAllItems()
        {
            return itemManagementService.GetAll();
        }

        public ItemDTO GetItemById(int id)
        {
            return itemManagementService.GetById(id);
        }

        public string PostItem(ItemDTO itemDTO)
        {
            if (itemManagementService.Save(itemDTO))
            {
                return "Item added!";
            }
            else
            {
                return "Item was not added!";
            }
        }

        public string PutItem(ItemDTO itemDTO)
        {
            if (itemManagementService.Save(itemDTO))
            {
                return "Item updated!";
            }
            else
            {
                return "Item was not updated!";
            }
        }

        public string DeleteItem(int id)
        {
            PlayerManagementService players = new PlayerManagementService();
            foreach (var player in players.GetAll())
            {
                foreach (var item in player.Inventory)
                {
                    if (item.Id == id)
                    {
                        player.Inventory.Remove(item);
                    }
                }
            }

            if (itemManagementService.Delete(id))
            {
                return "Item deleted!";
            }
            else
            {
                return "Item was not deleted!";
            }
        }
    }
}
