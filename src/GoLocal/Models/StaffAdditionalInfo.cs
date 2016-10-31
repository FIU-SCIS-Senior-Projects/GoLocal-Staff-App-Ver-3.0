using Microsoft.AspNetCore.Http;

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
        public string DesiredHourlyRate { get; set; }
        public string DesiredWeeklyRate { get; set; }
        public string SsnOrEin { get; set; }
        public string BusinessName { get; set; }
        public string Travel { get; set; }
        public string Insurance { get; set; }
        public string BankRouting { get; set; }
        public string AccountNumber { get; set; }
        public string VideoName { get; set; }
        public IFormFile Video { get; set; }
        public string Resume { get; set; }
    }
}