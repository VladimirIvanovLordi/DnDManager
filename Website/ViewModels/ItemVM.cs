using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AppService.DTOs;

namespace Website.ViewModels
{
    public class ItemVM : BaseVM
    {
        [Required]
        [Display(Name = "Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Is magical")]
        public bool IsMagic { get; set; }

        [Required]
        [Display(Name = "Requires attunement")]
        public bool RequiresAttunement { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        

        public virtual ICollection<PlayerVM> Owners { get; set; }

        [Display(Name = "ImageURL")]
        public string ImageURL { get; set; }


        public ItemVM() { }

        public ItemVM(ItemDTO itemDTO)
        {
            Id = itemDTO.Id;
            ItemName = itemDTO.ItemName;
            IsMagic = itemDTO.IsMagic;
            RequiresAttunement = itemDTO.RequiresAttunement;
            Description = itemDTO.Description;
            ImageURL = itemDTO.ImageURL;
        }

    }
}