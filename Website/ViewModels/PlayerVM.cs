using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AppService.DTOs;

namespace Website.ViewModels
{
    public class PlayerVM : BaseVM
    {
        [Required]
        public string PlayerName { get; set; }
        [Required]
        public string ActiveCharacterName { get; set; }

        #region AbilityScores
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int Charisma { get; set; }
        #endregion

        public virtual ICollection<ItemVM> Inventory { get; set; }

        public string AdditionalMechanicsInformation { get; set; }

        public virtual ICollection<CampaignVM> CampaignsWhereParicipating { get; set; }

        public string ImageURL { get; set; }


        public PlayerVM() { }

        public PlayerVM(PlayerDTO playerDTO)
        {
            Id = playerDTO.Id;
            PlayerName = playerDTO.PlayerName;
            ActiveCharacterName = playerDTO.ActiveCharacterName;

            Strength = playerDTO.Strength;
            Dexterity = playerDTO.Dexterity;
            Constitution = playerDTO.Constitution;
            Intelligence = playerDTO.Intelligence;
            Wisdom = playerDTO.Wisdom;
            Charisma = playerDTO.Charisma;

            foreach (var item in playerDTO.Inventory)
            {
                ItemVM itemVM = new ItemVM(item);
                Inventory.Add(itemVM);
            }

            AdditionalMechanicsInformation = playerDTO.AdditionalMechanicsInformation;

            ImageURL = playerDTO.ImageURL;
        }
    }
}