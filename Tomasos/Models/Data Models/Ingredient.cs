using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tomasos.Models
{
    public partial class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

    }
}
