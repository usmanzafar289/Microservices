using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Mvc.Ui.Models
{
    [Table("Point")]
    public class Points
    {
        [Key]
        [Required]
        public int id { get; set; }
        [StringLength(50)]
        public String name { get; set; }
        public Int64 timespan { get; set; }

        public float value { get; set; }



    }
}
