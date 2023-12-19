using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsis.Data.Entity
{
    public class Movies
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Rating { get; set; }
        public string Image { get;set; }
        [Column(TypeName = "timestamp(6) without time zone")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "timestamp(6) without time zone")]
        public DateTime UpdatedAt { get; set; }

    }
}
