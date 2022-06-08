using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class PlayerDTO : BaseDTO
    {
        public string PlayerName { get; set; }
        public string ActiveCharacterName { get; set; }

        #region AbilityScores
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        #endregion

        public virtual ICollection<ItemDTO> Inventory { get; set; }

        public string AdditionalMechanicsInformation { get; set; }

        public ICollection<CampaignDTO> CampaignsWhereParicipating { get; set; }

        public string ImageURL { get; set; }

        public bool Validate()
        {
            if (PlayerName == null || PlayerName == "" || ActiveCharacterName == null || ActiveCharacterName == "" || 
                Strength < 0 || Dexterity < 0 || Constitution < 0 || Intelligence < 0 || Wisdom < 0 || Charisma < 0 || 
                AdditionalMechanicsInformation == null || ImageURL == null)
            {
                return false;
            }

            return true;
        }
    }
}
