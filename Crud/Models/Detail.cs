using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class Detail
    {
        [Key]
        public int PMId { get; set; }
        [Required]
        [Column(TypeName="nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string TaskName { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public int TaskId { get; set; }
        
    }
}
