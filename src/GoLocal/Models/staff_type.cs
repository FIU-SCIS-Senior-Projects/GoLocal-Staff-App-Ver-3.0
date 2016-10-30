using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoLocal.Models
{
    public class staff_type
    {
        [Key]
        public int StaffID { get; set; }
        public int Brand_Ambassador { get; set; }
        public int Dancer { get; set; }
        public int Field_Marketing_Manager { get; set; }
        public int Flyer_Distributor { get; set; }
        public int Model { get; set; }
        public int Production_Assistant { get; set; }
        public int Sales_Executive { get; set; }
        public int Waiter_Waitress { get; set; }
        public int DJ { get; set; }
        public int DJ_Description { get; set; }
        public int DJ_Website { get; set; }
        public int DJ_Social_Media { get; set; }
        public int Catering_Company { get; set; }
        public int Catering_Company_Description { get; set; }
        public int Catering_Company_Website { get; set; }
        public int Catering_Company_Social_Media { get; set; }
        public int Live_Band { get; set; }
        public int Live_Band_Description { get; set; }
        public int Live_Band_Website { get; set; }
        public int Live_Band_Social_Media { get; set; }
        public int Other { get; set; }
        public int Other_Description { get; set; }
        public int Other_Website { get; set; }
        public int Other_Social_Media { get; set; }
        public int Senior_Marketing_Manager { get; set; }
        public int Bartender { get; set; }
        public int Photographer{ get; set; }
        public int Electrician { get; set; }
        public int Graphic_Designer { get; set; }
        public int Sound_Engineer{ get; set; }
      

    }
}
