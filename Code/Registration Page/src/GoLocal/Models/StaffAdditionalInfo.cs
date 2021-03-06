﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GoLocal.Models
{
    public class StaffAdditionalInfo
    {
        

        public string NickName { get; set; }
        public string StaffType { get; set; }
        public string OtherDescription { get; set; }
        public string NativeLanguage { get; set; }
        public string SecondLanguage { get; set; }
        public string ThirdLanguage { get; set; }
        public string TypeDL { get; set; }
        public string Ethnicity { get; set; }
        [RegularExpression(@"^[2-7]'(1[0-1]|\d)""$", ErrorMessage = "Please enter height in feet'inches\" format")]
        public string Height { get; set; }
        [RegularExpression(@"^([4-9]\d|[1-5]\d\d)(.\d)?$", ErrorMessage = "Please enter weight in lbs")]
        public string Weight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string ShirtSize { get; set; }
        public string PantSize { get; set; }
        [RegularExpression(@"^([1-6]\d)(.\d)?$", ErrorMessage = "Please enter chest size in inches")]
        public string ChestSize { get; set; }
        [RegularExpression(@"^([1-6]\d)(.\d)?$", ErrorMessage = "Please enter waist size in inches")]
        public string WaistSize { get; set; }
        [RegularExpression(@"^([1-6]\d)(.\d)?$", ErrorMessage = "Please enter hip size in inches")]
        public string HipSize { get; set; }
        public string DressSize { get; set; }
        public string ShoeSize { get; set; }
        public string Tattoos { get; set; }
        public string Piercings { get; set; }
        public string DesiredHourlyRate { get; set; }
        public string DesiredWeeklyRate { get; set; }
        public string SsnOrEin { get; set; }
        public string BusinessName { get; set; }
        public string Travel { get; set; }
        public string Insurance { get; set; }
        public string BankRouting { get; set; }
        public string AccountNumber { get; set; }
        public IFormFile Video { get; set; }
        public IFormFile Resume { get; set; }
    }
}