using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Campaign : BaseEntity
    {
        public string CampaignName { get; set; }
        public string DungeonMasterName { get; set; }
        public ICollection<Player> CurrentPlayers { get; set; }
        public string Description { get; set; }
    }
}
