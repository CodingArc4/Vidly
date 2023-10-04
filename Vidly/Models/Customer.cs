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

        //[Required(ErrorMessage = "Plz enter customer's name")] this will override the default validation error message
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } //this is called navigation property

        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YrsIfMember]
        public DateTime? DateOfBirth { get; set; }
       
    }
}