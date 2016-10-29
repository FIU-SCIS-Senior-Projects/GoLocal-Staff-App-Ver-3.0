using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoLocal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GoLocal.Controllers
{
    public class AdditionalInfoController : Controller
    {
        private OurDBContext _context;


        public AdditionalInfoController(OurDBContext dbCon)
        {

            _context = dbCon;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdditionalInfo()
        {
            ViewBag.StaffTypes = Enum.GetValues(typeof(StaffTypes)).Cast<StaffTypes>().Select(v => new SelectListItem { Text = v.ToString(), Value = v.ToString() });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdditionalInfo([Bind("StaffType,NativeLanguage,SecondLanguage,ThirdLanguage,TypeDL,Ethnicity,Height,Weight,HairColor,EyeColor,ShirtSize,PantSize,ChestSize,WaistSize,HipSize, DressSize,ShoeSize,Tattoos,Piercings,DesiredHourlyRate,DesiredWeeklyRate,SsnOrEin, BusinessName,Travel,Insurance, BankRouting, AccountNumber")] StaffAdditionalInfo info)
        {
            if (ModelState.IsValid)
            {
                if (_context.registered_staff.Count() > 0)
                {
                    try
                    {
                        registered_staff staff = _context.registered_staff.Last();
                        staff.StaffType = info.StaffType;
                        staff.NativeLanguage = info.NativeLanguage;
                        staff.SecondLanguage = info.SecondLanguage;
                        staff.ThirdLanguage = info.ThirdLanguage;
                        staff.TypeDL = info.TypeDL;
                        staff.Ethnicity = info.Ethnicity;
                        staff.Height = info.Height;
                        staff.Weight = info.Weight;
                        staff.HairColor = info.HairColor;
                        staff.EyeColor = info.EyeColor;
                        staff.ShirtSize = info.ShirtSize;
                        staff.PantSize = info.PantSize;
                        staff.ChestSize = info.ChestSize;
                        staff.NickName = info.NickName;
                        staff.WaistSize = info.WaistSize;
                        staff.HipSize = info.HipSize;
                        staff.DressSize = info.DressSize;
                        staff.ShoeSize = info.ShoeSize;
                        staff.Tattoos = info.Tattoos;
                        staff.Piercings = info.Piercings;
                        staff.DesiredHourlyRate = info.DesiredHourlyRate;
                        staff.DesiredWeeklyRate = info.DesiredWeeklyRate;
                        staff.SsnOrEin = info.SsnOrEin;
                        staff.BusinessName = info.BusinessName;
                        staff.Travel = info.Travel;
                        staff.Insurance = info.Insurance;
                        staff.BankRouting = info.BankRouting;
                        staff.AccountNumber = info.AccountNumber;
                        
                        await _context.SaveChangesAsync();
                        ViewBag.ConfirmationMessage = "Your account has been created!";
                        ViewData["staffID"] = "Staff ID: " + staff.StaffID;
                        
                        return View("AccountCreated");
                    }
                    catch (Exception e)
                    {
                        ViewBag.ConfirmationMessage = Enum.GetValues(typeof(StaffTypes)).Cast<StaffTypes>().Select(v => new SelectListItem { Text = v.ToString(), Value = v.ToString() });
                        return View(info);

                    }
                }
            }

            ViewBag.StaffTypes = Enum.GetValues(typeof(StaffTypes)).Cast<StaffTypes>().Select(v => new SelectListItem { Text = v.ToString(), Value = v.ToString() });
            return View(info);
        }
    }
}
