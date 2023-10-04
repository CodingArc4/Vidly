using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Plz enter customer's name")] this will override the default validation error message
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        // we avoid membership type because it couples dto with the domain object
        public byte MembershipTypeID { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YrsIfMember]
        public DateTime? DateOfBirth { get; set; }
    }
}