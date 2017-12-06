using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firestorm.Models
{
    [Table("TestMaterial")]
    public class TestMaterial
    {
        [ForeignKey("Test")]
        public int TestID { get; set; }
        public virtual Test Test { get; set; }

        [ForeignKey("Material")]
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }
    }
}