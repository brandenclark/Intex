using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace firestorm.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        
        [ForeignKey("Role")]
        public virtual int? RoleID { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("Company")]
        public virtual int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}