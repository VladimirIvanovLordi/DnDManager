using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Item : BaseEntity
    {
        public string ItemName { get; set; }

        public bool IsMagic { get; set; }
        public bool RequiresAttunement { get; set; }

        public string Description { get; set; }

        public ICollection<Player> Owners { get; set; }

        public string ImageURL { get; set; }
    }
}
