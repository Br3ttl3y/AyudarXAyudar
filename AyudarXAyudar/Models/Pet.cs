using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AyudarXAyudar.Models.Resources;
using System.Linq;
using System.Web;

namespace AyudarXAyudar.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Display(Order = 0, ResourceType = typeof(PetStrings),
            Name = "PetName")]
        public string Name { get; set; }

        [Display(Order = 0, ResourceType = typeof(PetStrings),
            Name = "PetPicture")]
        public string PictureUrl { get; set; }

        [Display(Order = 0, ResourceType = typeof(PetStrings),
            Name = "PetDescription")]
        public string Description { get; set; }
    }
}