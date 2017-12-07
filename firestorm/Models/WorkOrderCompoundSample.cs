using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace firestorm.Models
{
    public class WorkOrderCompoundSample
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public WorkOrder workOrder { get; set; }
        public List<Assay> assays = new List<Assay>();
        public List<CompoundSample> compoundSamples = new List<CompoundSample>();

    }
}