using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firestorm.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public decimal Balance { get; set; }
    }
}