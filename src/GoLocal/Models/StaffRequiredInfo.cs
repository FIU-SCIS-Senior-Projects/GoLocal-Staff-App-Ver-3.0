using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoLocal.Models
{
    public class StaffRequiredInfo
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string City { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Invalid Zip Code format")]

        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string State { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}
