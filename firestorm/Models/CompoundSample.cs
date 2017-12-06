using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firestorm.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firestorm.Models
{
    [Table("CompoundSample")]
    public class CompoundSample
    {
        [Key]
        [Column(Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[ForeignKey("Compound")]
        public int LT { get; set; }
        //public virtual Compound Compound { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SequenceCode { get; set; }

        public int QuantityMG { get; set; }
        public DateTime DateArrived { get; set; }
        public String ReceivedBy { get; set; }
        public DateTime DateDue { get; set; }
        public String Appearance { get; set; }
        public int Weight { get; set; }
        public float MolMass { get; set; }
        public bool AuthAddTest { get; set; }
        public DateTime ScheduledDate { get; set; }

        [ForeignKey("Assay")]
        public String AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        //Add WorkOrder
        [ForeignKey("WorkOrder")]
        public int OrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }



    }
}