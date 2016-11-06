using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoLocal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.IO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GoLocal.Controllers
{
    public class AdditionalInfoController : Controller
    {
        private OurDBContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;



        public AdditionalInfoController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {

            _context = OurDBContextFactory.Create();
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdditionalInfo()
        {
            FillStaffTypes();

            return View();
        }

        private void FillStaffTypes()
        {
            var names = typeof(staff_type).GetProperties()
                               .Select(property => property.Name)
                               .ToList();

            ViewBag.StaffTypes = names.Select(v => new SelectListItem { Text = v.ToString().Replace('_', ' '), Value = v.ToString() })
                .Where(v => v.Value != "StaffID" && !v.Value.Contains("Description") && !v.Value.Contains("Website") && !v.Value.Contains("Social_Media"))
                .ToList();
        }

        public IActionResult Error()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdditionalInfo([Bind("StaffType,OtherDescription,NativeLanguage,SecondLanguage,ThirdLanguage,TypeDL,Ethnicity,Height,Weight,HairColor,EyeColor,ShirtSize,PantSize,ChestSize,WaistSize,HipSize, DressSize,ShoeSize,Tattoos,Piercings,DesiredHourlyRate,DesiredWeeklyRate,SsnOrEin, BusinessName,Travel,Insurance, BankRouting, AccountNumber, Video, Resume")] StaffAdditionalInfo info)
        {
            var validVideoTypes = new string[]
            {
                    "video/avi",
                    "video/flv",
                    "video/wmv",
                    "video/mov",
                    "video/mp4",
                    "video/quicktime"
            };
            if (info.Video != null)
            {
                if (!validVideoTypes.Contains(info.Video.ContentType))
                {
                    ModelState.AddModelError("Video", "Please choose either a AVI, FLV, WMV, MOV, QUICKTIME or MP4 video.");
                }
            }


            FillStaffTypes();
            

            if (ModelState.IsValid)
            {
                if (_context.registered_staff.Count() > 0)
                {
                    try
                    {
                        registered_staff staff = _context.registered_staff.Last();

                        if (info.StaffType != "Other")
                        {
                            staff.StaffType = info.StaffType;
                        }else
                        {
                            if (info.OtherDescription != null && info.OtherDescription != "")
                            {
                                staff.StaffType = info.OtherDescription;
                            }else
                            {
                                staff.StaffType = info.StaffType;

                            }

                        }
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
                        staff.Resume = info.Resume;

                        if (info.Video != null)
                        {
                            staff.VideoName = info.Video.FileName;
                            
                            var uploadDir = "uploads/videos";
                            var videoPath = Path.Combine(_hostingEnvironment.ContentRootPath, uploadDir, info.Video.FileName);
                            await info.Video.CopyToAsync(new FileStream(videoPath, FileMode.Create, FileAccess.ReadWrite));
                        }

                        await _context.SaveChanges<registered_staff>();
                        ViewBag.ConfirmationMessage = "Your account has been created!";
                        ViewData["staffID"] = "Staff ID: " + staff.StaffID;
                        
                        return View("AccountCreated");
                    }
                    catch (Exception)
                    {
                        return Error();

                    }
                }
            }

            return View(info);
        }
    }
}
