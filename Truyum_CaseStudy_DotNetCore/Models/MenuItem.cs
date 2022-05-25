using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Truyum_CaseStudy_DotNetCore.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public bool Active { get; set; }

        [Display(Name="Free Delivery")]
        public bool DeliveryStatus { get; set; }

        [Display(Name="Date Of Launch")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime LaunchDate { get; set; }

        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }
        
    }
}
