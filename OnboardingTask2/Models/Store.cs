using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnboardingTask2.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Store Name")]
        [Required(ErrorMessage = "Store Name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Store Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}