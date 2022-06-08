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
    public class CampaignManagementService
    {
        public List<CampaignDTO> GetAll()
        {
            List<CampaignDTO> campaignsDTO = new List<CampaignDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CampaignRepository.Get())
                {
                    CampaignDTO campaignDTO = new CampaignDTO();

                    campaignDTO.Id = item.Id;
                    campaignDTO.CampaignName = item.CampaignName;
                    campaignDTO.DungeonMasterName = item.DungeonMasterName;

                    if (item.CurrentPlayers != null)
                    {
                        foreach (var player in item.CurrentPlayers)
                        {
                            PlayerDTO playerDTO = new PlayerDTO();

                            playerDTO.Id = player.Id;
                            playerDTO.PlayerName = player.PlayerName;
                            playerDTO.ActiveCharacterName = player.ActiveCharacterName;

                            playerDTO.Strength = player.Strength;
                            playerDTO.Dexterity = player.Dexterity;
                            playerDTO.Constitution = player.Constitution;
                            playerDTO.Intelligence = player.Intelligence;
                            playerDTO.Wisdom = player.Wisdom;
                            playerDTO.Charisma = player.Charisma;

                            playerDTO.Inventory = (List<ItemDTO>)player.Inventory;

                            playerDTO.AdditionalMechanicsInformation = player.AdditionalMechanicsInformation;
                            playerDTO.ImageURL = player.ImageURL;

                            campaignDTO.CurrentPlayers.Add(playerDTO);

                        }
                    }

                    campaignDTO.Description = item.Description;

                    campaignsDTO.Add(campaignDTO);
                }
            }

            return campaignsDTO;
        }

        public CampaignDTO GetById(int id)
        {
            CampaignDTO campaignDTO = new CampaignDTO();

            using (UnitOfWork unitOfWork= new UnitOfWork())
            {
                Campaign campaign = unitOfWork.CampaignRepository.GetByID(id);

                if (campaign != null)
                {
                    campaignDTO.CampaignName = campaign.CampaignName;
                    campaignDTO.DungeonMasterName = campaign.DungeonMasterName;

                    if (campaign.CurrentPlayers != null)
                    {
                        foreach (var player in campaign.CurrentPlayers)
                        {
                            PlayerDTO playerDTO = new PlayerDTO();

                            playerDTO.Id = player.Id;
                            playerDTO.PlayerName = player.PlayerName;
                            playerDTO.ActiveCharacterName = player.ActiveCharacterName;

                            playerDTO.Strength = player.Strength;
                            playerDTO.Dexterity = player.Dexterity;
                            playerDTO.Constitution = player.Constitution;
                            playerDTO.Intelligence = player.Intelligence;
                            playerDTO.Wisdom = player.Wisdom;
                            playerDTO.Charisma = player.Charisma;

                            playerDTO.Inventory = (List<ItemDTO>)player.Inventory;

                            playerDTO.AdditionalMechanicsInformation = player.AdditionalMechanicsInformation;
                            playerDTO.ImageURL = player.ImageURL;

                            campaignDTO.CurrentPlayers.Add(playerDTO);

                        }
                    }

                    campaignDTO.Description = campaign.Description;
                }

                return campaignDTO;

            }
        }

        public bool Save(CampaignDTO campaignDTO)
        {
            ICollection<Player> players = new List<Player>();

            if (campaignDTO.CurrentPlayers != null)
            {
                foreach (var player in campaignDTO.CurrentPlayers)
                {
                    Player participantPlayer = new Player();

                    participantPlayer.Id = player.Id;
                    participantPlayer.PlayerName = player.PlayerName;
                    participantPlayer.ActiveCharacterName = player.ActiveCharacterName;

                    participantPlayer.Strength = player.Strength;
                    participantPlayer.Dexterity = player.Dexterity;
                    participantPlayer.Constitution = player.Constitution;
                    participantPlayer.Intelligence = player.Intelligence;
                    participantPlayer.Wisdom = player.Wisdom;
                    participantPlayer.Charisma = player.Charisma;

                    participantPlayer.Inventory = (ICollection<Item>)player.Inventory;

                    participantPlayer.AdditionalMechanicsInformation = player.AdditionalMechanicsInformation;

                    participantPlayer.CampaignsWhereParicipating = (ICollection<Campaign>)player.CampaignsWhereParicipating;

                    participantPlayer.ImageURL = player.ImageURL;

                    players.Add(participantPlayer);

                }
            }

            Campaign campaign = new Campaign
            {
                CampaignName = campaignDTO.CampaignName,
                DungeonMasterName = campaignDTO.DungeonMasterName,

                //TODO Maybe needs fixing !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                CurrentPlayers = players,

                Description = campaignDTO.Description
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (campaignDTO.Id == 0)
                    {
                        unitOfWork.CampaignRepository.Insert(campaign);
                    }
                    else
                    {
                        unitOfWork.CampaignRepository.Update(campaign);
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
                    unitOfWork.CampaignRepository.Delete(id);
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
