using AppService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Implementations
{
    public class ItemManagementService
    {
        public List<ItemDTO> GetAll()
        {
            List<ItemDTO> itemsDTO = new List<ItemDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.ItemRepository.Get ())
                {
                    ItemDTO itemDTO = new ItemDTO();

                    itemDTO.Id = item.Id;
                    itemDTO.ItemName = item.ItemName;
                    itemDTO.IsMagic = item.IsMagic;
                    itemDTO.RequiresAttunement = item.RequiresAttunement;
                    itemDTO.Description = item.Description;
                    itemDTO.ImageURL = item.ImageURL;

                    if (item.Owners != null)
                    {
                        foreach (var playerOwner in item.Owners)
                        {
                            PlayerDTO playerDTO = new PlayerDTO();

                            playerDTO.Id = playerOwner.Id;
                            playerDTO.PlayerName = playerOwner.PlayerName;
                            playerDTO.ActiveCharacterName = playerOwner.ActiveCharacterName;

                            playerDTO.Strength = playerOwner.Strength;
                            playerDTO.Dexterity = playerOwner.Dexterity;
                            playerDTO.Constitution = playerOwner.Constitution;
                            playerDTO.Intelligence = playerOwner.Intelligence;
                            playerDTO.Wisdom = playerOwner.Wisdom;
                            playerDTO.Charisma = playerOwner.Charisma;

                            playerDTO.Inventory = (ICollection<ItemDTO>)playerOwner.Inventory;
                            playerDTO.AdditionalMechanicsInformation = playerOwner.AdditionalMechanicsInformation;
                            playerDTO.CampaignsWhereParicipating = (ICollection<CampaignDTO>)playerOwner.CampaignsWhereParicipating;

                            playerDTO.ImageURL = playerOwner.ImageURL;

                            itemDTO.Owners.Add(playerDTO);
                        }
                    }

                    itemsDTO.Add(itemDTO);
                }
            }

            return itemsDTO;
        }

        public ItemDTO GetById(int id)
        {
            ItemDTO itemDTO = new ItemDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Item item = unitOfWork.ItemRepository.GetByID(id);

                if (item != null)
                {
                    itemDTO.ItemName = item.ItemName;
                    itemDTO.IsMagic = item.IsMagic;
                    itemDTO.RequiresAttunement = item.RequiresAttunement;
                    itemDTO.Description = item.Description;
                    itemDTO.ImageURL = item.ImageURL;

                    if (item.Owners != null)
                    {
                        foreach (var playerOwner in item.Owners)
                        {
                            PlayerDTO playerDTO = new PlayerDTO();

                            playerDTO.Id = playerOwner.Id;
                            playerDTO.PlayerName = playerOwner.PlayerName;
                            playerDTO.ActiveCharacterName = playerOwner.ActiveCharacterName;

                            playerDTO.Strength = playerOwner.Strength;
                            playerDTO.Dexterity = playerOwner.Dexterity;
                            playerDTO.Constitution = playerOwner.Constitution;
                            playerDTO.Intelligence = playerOwner.Intelligence;
                            playerDTO.Wisdom = playerOwner.Wisdom;
                            playerDTO.Charisma = playerOwner.Charisma;

                            playerDTO.Inventory = (ICollection<ItemDTO>)playerOwner.Inventory;
                            playerDTO.AdditionalMechanicsInformation = playerOwner.AdditionalMechanicsInformation;
                            playerDTO.CampaignsWhereParicipating = (ICollection<CampaignDTO>)playerOwner.CampaignsWhereParicipating;

                            playerDTO.ImageURL = playerOwner.ImageURL;

                            itemDTO.Owners.Add(playerDTO);
                        }
                    }

                }

                return itemDTO;
            }
        }

        public bool Save(ItemDTO itemDTO)
        {
            ICollection<Player> players = new List<Player>();
            if (itemDTO.Owners != null)
            {
                foreach (var playerOwner in itemDTO.Owners)
                {
                    Player player = new Player();

                    player.Id = playerOwner.Id;
                    player.PlayerName = playerOwner.PlayerName;
                    player.ActiveCharacterName = playerOwner.ActiveCharacterName;

                    player.Strength = playerOwner.Strength;
                    player.Dexterity = playerOwner.Dexterity;
                    player.Constitution = playerOwner.Constitution;
                    player.Intelligence = playerOwner.Intelligence;
                    player.Wisdom = playerOwner.Wisdom;
                    player.Charisma = playerOwner.Charisma;

                    player.Inventory = (ICollection<Item>)playerOwner.Inventory;
                    player.AdditionalMechanicsInformation = playerOwner.AdditionalMechanicsInformation;
                    player.CampaignsWhereParicipating = (ICollection<Campaign>)playerOwner.CampaignsWhereParicipating;

                    player.ImageURL = playerOwner.ImageURL;

                    players.Add(player);
                }
            }

            Item item = new Item
            {
                ItemName = itemDTO.ItemName,
                IsMagic = itemDTO.IsMagic,
                RequiresAttunement = itemDTO.RequiresAttunement,
                Description = itemDTO.Description,

                Owners = players,

                ImageURL = itemDTO.ImageURL
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (itemDTO.Id == 0)
                    {
                        unitOfWork.ItemRepository.Insert(item);
                    }
                    else
                    {
                        unitOfWork.ItemRepository.Update(item);
                    }
                    
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {

                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.ItemRepository.Delete(id);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
