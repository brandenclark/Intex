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
    [Table("CompoundSample")]
    public class CompoundSample
    {
        [Key, Column(Order = 0), ForeignKey("Compound")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LT { get; set; }
        public virtual Compound Compound { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SequenceCode { get; set; }

        public int QuantityMG { get; set; }
        public DateTime DateArrived { get; set; }
        public String ReceivedBy { get; set; }

        [DisplayName("Desired Completion Date")]
        public DateTime DateDue { get; set; }
        public String Appearance { get; set; }

        [Required]
        [DisplayName("Weight of Compound")]
        public int Weight { get; set; }

        public float MolMass { get; set; }

        [Required]
        [DisplayName("Do you authroize any additional tests as needed?")]
        public bool AuthAddTest { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [ForeignKey("Assay")]
        public String AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        [ForeignKey("WorkOrder")]
        public int OrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }



    }
}