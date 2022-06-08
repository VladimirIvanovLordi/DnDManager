using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Player : BaseEntity
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

        public ICollection<Item> Inventory { get; set; }

        public string AdditionalMechanicsInformation { get; set; }

        public string Backstory { get; set; }

        public ICollection<Campaign> CampaignsWhereParicipating { get; set; }

        public string ImageURL { get; set; }
    }
}
