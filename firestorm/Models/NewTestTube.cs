using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firestorm.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace firestorm.Models
{
    public class NewTestTube
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TTID { get; set; }
        public String AssayID { get; set; }
        public String TestID { get; set; }
        [DisplayName("Assay Name")]
        public String Name { get; set; }
        public String LT { get; set; }
        [DisplayName("Sequence Code")]
        public String SequenceCode { get; set; }
        [DisplayName("Desired Completion Date")]
        public String DateDue { get; set; }
    }
}