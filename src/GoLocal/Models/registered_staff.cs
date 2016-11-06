using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoLocal.Models
{
    public class registered_staff
    {
        [Key]
        public int StaffID { get; set; }

        
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "Password must contain at least 7 characters")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        public string State { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ImageName { get; set; }




        public string StaffType { get; set; }
        public string NickName { get; set; }
        public string NativeLanguage { get; set; }
        public string SecondLanguage { get; set; }
        public string ThirdLanguage { get; set; }
        public string TypeDL { get; set; }
        public string Ethnicity { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string ShirtSize { get; set; }
        public string PantSize { get; set; }
        public string ChestSize { get; set; }
        public string WaistSize { get; set; }
        public string HipSize { get; set; }
        public string DressSize { get; set; }
        public string ShoeSize { get; set; }
        public string Tattoos { get; set; }
        public string Piercings { get; set; }
        [DataType(DataType.Currency)]
        public string DesiredHourlyRate { get; set; }
        [DataType(DataType.Currency)]
        public string DesiredWeeklyRate { get; set; }
        public string SsnOrEin { get; set; }
        public string BusinessName { get; set; }
        public string Travel { get; set; }
        public string Insurance { get; set; }
        public string BankRouting { get; set; }
        public string AccountNumber { get; set; }
        public string VideoName { get; set; }
        public string Resume { get; set; }


        public int EthnicityCode { get; set; }
        public string InsuranceDocuments { get; set; }
        
        public string AccountLocked { get; set; }
        public string ForgotPasswordCode { get; set; }
        public int ForgotPasswordRequests { get; set; }
        public int LoginRequests { get; set; }
        public int Status { get; set; }
        public string Hash { get; set; }
        public int Profile { get; set; }
        public string HashEmail { get; set; }
        public int EmailValidated { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneValidated { get; set; }

        public registered_staff()
        {

        }
    }
}
