using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]  // having "Required" here, Name becomes non-nullable in the database.
        [StringLength(255)]
        public string Name { get; set; }  // string will be nullable and max length in the database on default; using the [] to re-write it.

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } // foreign key to the MembershipType; *byte is not nullable, so it's required*

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }
    }
}