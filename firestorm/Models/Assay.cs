using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firestorm.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String AssayID { get; set; }
        public String Name { get; set; }
        public String Procedure { get; set; }
    }
}