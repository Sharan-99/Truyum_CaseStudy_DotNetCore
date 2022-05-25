using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Truyum_CaseStudy_DotNetCore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; } 
        public MenuItem MenuItem { get; set; }

    }
}
