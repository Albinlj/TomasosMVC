using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models.AccountViewModels
{
    public class EditUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(20)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        //only allow numbers
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        //only allow numbers and plus
        public string PhoneNumber { get; set; }
    }
}
