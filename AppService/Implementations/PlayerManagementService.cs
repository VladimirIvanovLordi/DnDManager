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
    public class PlayerManagementService
    {
        public List<PlayerDTO> GetAll()
        {
            List<PlayerDTO> playersDTO = new List<PlayerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.PlayerRepository.Get())
                {
                    PlayerDTO playerDTO = new PlayerDTO();

                    playerDTO.Id = item.Id;
                    playerDTO.PlayerName = item.PlayerName;
                    playerDTO.ActiveCharacterName = item.ActiveCharacterName;

                    playerDTO.Strength = item.Strength;
                    playerDTO.Dexterity = item.Dexterity;
                    playerDTO.Constitution = item.Constitution;
                    playerDTO.Intelligence = item.Intelligence;
                    playerDTO.Wisdom = item.Wisdom;
                    playerDTO.Charisma = item.Charisma;

                    playerDTO.Inventory = new List<ItemDTO>();

                    playerDTO.AdditionalMechanicsInformation = item.AdditionalMechanicsInformation;

                    playerDTO.CampaignsWhereParicipating = new List<CampaignDTO>();

                    playerDTO.ImageURL = item.ImageURL;

                    if (item.Inventory != null)
                    {
                        foreach (var inventoryItem in item.Inventory)
                        {
                            ItemDTO itemDTO = new ItemDTO();

                            itemDTO.Id = inventoryItem.Id;
                            itemDTO.ItemName = inventoryItem.ItemName;
                            itemDTO.IsMagic = inventoryItem.IsMagic;
                            itemDTO.RequiresAttunement = inventoryItem.RequiresAttunement;
                            itemDTO.Description = inventoryItem.Description;
                            itemDTO.ImageURL = inventoryItem.ImageURL;

                            itemDTO.Owners = (ICollection<PlayerDTO>)inventoryItem.Owners;

                            playerDTO.Inventory.Add(itemDTO);
                        }
                    }

                    if (item.CampaignsWhereParicipating != null)
                    {
                        foreach (var campaign in item.CampaignsWhereParicipating)
                        {
                            CampaignDTO campaignDTO = new CampaignDTO();

                            campaignDTO.Id = campaign.Id;
                            campaignDTO.DungeonMasterName = campaign.DungeonMasterName;
                            campaignDTO.CurrentPlayers = (ICollection<PlayerDTO>)campaign.CurrentPlayers;
                            campaignDTO.Description = campaign.Description;

                            playerDTO.CampaignsWhereParicipating.Add(campaignDTO);
                        }
                    }

                    playersDTO.Add(playerDTO);
                }
            }

            return playersDTO;
        }

        public PlayerDTO GetById(int id)
        {
            PlayerDTO playerDTO = new PlayerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Player player = unitOfWork.PlayerRepository.GetByID(id);

                if (player != null)
                {
                    playerDTO.PlayerName = player.PlayerName;
                    playerDTO.ActiveCharacterName = player.ActiveCharacterName;

                    playerDTO.Strength = player.Strength;
                    playerDTO.Dexterity = player.Dexterity;
                    playerDTO.Constitution = player.Constitution;
                    playerDTO.Intelligence = player.Intelligence;
                    playerDTO.Wisdom = player.Wisdom;
                    playerDTO.Charisma = player.Charisma;

                    if (player.Inventory != null)
                    {
                        foreach (var inventoryItem in player.Inventory)
                        {
                            ItemDTO itemDTO = new ItemDTO();

                            itemDTO.Id = inventoryItem.Id;
                            itemDTO.ItemName = inventoryItem.ItemName;
                            itemDTO.IsMagic = inventoryItem.IsMagic;
                            itemDTO.RequiresAttunement = inventoryItem.RequiresAttunement;
                            itemDTO.Description = inventoryItem.Description;
                            itemDTO.ImageURL = inventoryItem.ImageURL;

                            playerDTO.Inventory.Add(itemDTO);
                        }
                    }

                    playerDTO.AdditionalMechanicsInformation = player.AdditionalMechanicsInformation;

                    if (player.CampaignsWhereParicipating != null)
                    {
                        foreach (var campaign in player.CampaignsWhereParicipating)
                        {
                            CampaignDTO campaignDTO = new CampaignDTO();

                            campaignDTO.Id = campaign.Id;
                            campaignDTO.DungeonMasterName = campaign.DungeonMasterName;
                            campaignDTO.CurrentPlayers = (ICollection<PlayerDTO>)campaign.CurrentPlayers;
                            campaignDTO.Description = campaign.Description;

                            playerDTO.CampaignsWhereParicipating.Add(campaignDTO);
                        }
                    }

                    playerDTO.ImageURL = player.ImageURL;
                }

                return playerDTO;
            }
        }

        public bool Save(PlayerDTO playerDTO)
        {
            ICollection<Item> items = new List<Item>();

            if (playerDTO.Inventory != null)
            {
                foreach (var inventoryItem in playerDTO.Inventory)
                {
                    Item ownedItem = new Item();

                    ownedItem.Id = inventoryItem.Id;
                    ownedItem.ItemName = inventoryItem.ItemName;
                    ownedItem.IsMagic = inventoryItem.IsMagic;
                    ownedItem.RequiresAttunement = inventoryItem.RequiresAttunement;
                    ownedItem.Description = inventoryItem.Description;

                    ownedItem.Owners = (ICollection<Player>)inventoryItem.Owners;

                    ownedItem.ImageURL = inventoryItem.ImageURL;

                   items.Add(ownedItem);
                }
            }

            ICollection<Campaign> campaigns = new List<Campaign>();

            if (playerDTO.CampaignsWhereParicipating != null)
            {
                foreach (var campaign in playerDTO.CampaignsWhereParicipating)
                {
                    Campaign participatedCampaign = new Campaign();

                    participatedCampaign.Id = campaign.Id;
                    participatedCampaign.DungeonMasterName = campaign.DungeonMasterName;
                    participatedCampaign.CurrentPlayers = (ICollection<Player>)campaign.CurrentPlayers;
                    participatedCampaign.Description = campaign.Description;

                    campaigns.Add(participatedCampaign);
                }
            }


            Player player = new Player
            {
                PlayerName = playerDTO.PlayerName,
                ActiveCharacterName = playerDTO.ActiveCharacterName,

                Strength = playerDTO.Strength,
                Dexterity = playerDTO.Dexterity,
                Constitution = playerDTO.Constitution,
                Intelligence = playerDTO.Intelligence,
                Wisdom = playerDTO.Wisdom,
                Charisma = playerDTO.Charisma,

                //TODO Maybe needs fixing !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Inventory = items,

                AdditionalMechanicsInformation = playerDTO.AdditionalMechanicsInformation,

                CampaignsWhereParicipating = campaigns,

                ImageURL = playerDTO.ImageURL
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {

                    if (playerDTO.Id == 0)
                    {
                        unitOfWork.PlayerRepository.Insert(player);
                    }
                    else
                    {
                        unitOfWork.PlayerRepository.Update(player);
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
                    unitOfWork.PlayerRepository.Delete(id);
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
