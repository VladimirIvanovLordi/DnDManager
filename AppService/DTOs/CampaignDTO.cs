using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class CampaignDTO : BaseDTO
    {
        public string CampaignName { get; set; }
        public string DungeonMasterName { get; set; }
        public virtual ICollection<PlayerDTO> CurrentPlayers { get; set; }
        public string Description { get; set; }


        public bool Validate()
        {
            if (CampaignName == null || CampaignName == "" ||
                DungeonMasterName == null || DungeonMasterName == "" ||
                Description == null)
            {
                return false;
            }
            return true;
        }
    }
}
