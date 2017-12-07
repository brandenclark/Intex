using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firestorm.Models
{
    [Table("AssayTest")]
    public class AssayTest
    {
      
        [ForeignKey("Assay"), Column(Order = 0)]
        [Key]
        public virtual string AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        [ForeignKey("Test"), Column(Order = 1)]
        [Key]
        public virtual int TestID { get; set; }
        public virtual Test Test { get; set; }

    }
}