using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firestorm.Models
{
    [Table("SampleTest")]
    public class SampleTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestTubeID { get; set; }
        public float Concentration { get; set; }
 
        [ForeignKey("CompoundSample"), Column(Order = 0)]
        public virtual int? LT { get; set; }

        [ForeignKey("CompoundSample"), Column(Order = 1)]
        public virtual int? SequenceCode { get; set; }
        public virtual CompoundSample CompoundSample { get; set; }

        [ForeignKey("AssayTest"), Column(Order = 2)]
        public virtual string AssayID { get; set; }

        [ForeignKey("AssayTest"), Column(Order = 3)]
        public virtual string TestID { get; set; }
        public virtual AssayTest AssayTest { get; set; }
    }
}