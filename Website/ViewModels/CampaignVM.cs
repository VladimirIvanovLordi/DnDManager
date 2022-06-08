using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AppService.DTOs;

namespace Website.ViewModels
{
    public class CampaignVM : BaseVM
    {
        [Required]
        public string CampaignName { get; set; }
        [Required]
        public string DungeonMasterName { get; set; }
        public virtual ICollection<PlayerVM> CurrentPlayers { get; set; }
        public string Description { get; set; }


        public CampaignVM() { }

        public CampaignVM(CampaignDTO campaignDTO)
        {
            CampaignName = campaignDTO.CampaignName;
            DungeonMasterName = campaignDTO.DungeonMasterName;

            foreach (var player in campaignDTO.CurrentPlayers)
            {
                PlayerVM playerVM = new PlayerVM(player);
                CurrentPlayers.Add(playerVM);
            }

            Description = campaignDTO.Description;
        }
    }
}