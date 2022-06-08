using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.DTOs
{
    public class ItemDTO : BaseDTO
    {
        public string ItemName { get; set; }

        public bool IsMagic { get; set; }
        public bool RequiresAttunement { get; set; }

        public string Description { get; set; }

        public ICollection<PlayerDTO> Owners { get; set; }

        public string ImageURL { get; set; }

        public bool Validate()
        {
            if (ItemName == null || ItemName == "" ||
                Description == null || ImageURL == null ||
                (IsMagic == false && RequiresAttunement == true))
            {
                return false;
            }
            return true;
        }
    }
}
