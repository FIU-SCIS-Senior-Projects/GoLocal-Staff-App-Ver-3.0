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

        public AdditionalInfoController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)        {

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
            if (info.SsnOrEin != null && info.SsnOrEin.Length < 9)
            {
                ModelState.AddModelError("SsnOrEin", "Invalid SSN.");

            }
            var validVideoTypes = new string[]
            {
                    "video/avi",
                    "video/msvideo",
                    "video/x-msvideo",
                    "video/x-flv",
                    "video/x-ms-wmv",
                    "video/mp4",
                    "video/quicktime"
            };
            var validResumeTypes = new string[]
            {
                    "application/msword",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    "text/plain",
                    "application/pdf",
                    "application/rtf"
                    
            };
            if (info.Video != null)
            {
                if (!validVideoTypes.Contains(info.Video.ContentType))
                {
                    ModelState.AddModelError("Video", "Please choose either a AVI, FLV, WMV, MOV, or MP4 video.");
                }
            }
            if (info.Resume != null)
            {
                if (!validResumeTypes.Contains(info.Resume.ContentType))
                {
                    ModelState.AddModelError("Resume", "Please choose either a DOC, DOCX, TXT, PDF, or RTF document.");
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
                        staff_type type = _context.staff_type.Last();

                        if (info.StaffType != "Other")
                        {
                            staff.StaffType = info.StaffType;
                            type.UpdateProperty(info.StaffType);
                        }
                        else
                        {
                            if (info.OtherDescription != null && info.OtherDescription != "")
                            {
                                staff.StaffType = info.OtherDescription;
                                type.UpdateProperty(info.StaffType);
                                type.UpdateProperty("Other_Description");
                            }
                            else
                            {
                                staff.StaffType = info.StaffType;
                                type.UpdateProperty(info.StaffType);
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

                        if (info.Resume != null)
                        {
                            staff.Resume = info.Resume.FileName;
                            var uploadDir = "uploads/resumes/" + staff.StaffID + "/";
                            var folderPath = Path.Combine(_hostingEnvironment.ContentRootPath, uploadDir);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            var resumePath = Path.Combine(_hostingEnvironment.ContentRootPath, folderPath, info.Resume.FileName);
                            await info.Resume.CopyToAsync(new FileStream(resumePath, FileMode.Create, FileAccess.ReadWrite));
                        }

                        if (info.Video != null)
                        {
                            staff.VideoName = info.Video.FileName;                            
                            var uploadDir = "uploads/videos/" + staff.StaffID + "/";
                            var folderPath = Path.Combine(_hostingEnvironment.ContentRootPath, uploadDir);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            var videoPath = Path.Combine(_hostingEnvironment.ContentRootPath, folderPath, info.Video.FileName);
                            await info.Video.CopyToAsync(new FileStream(videoPath, FileMode.Create, FileAccess.ReadWrite));
                        }

                        await _context.SaveChanges<registered_staff>();
                        await _context.SaveChanges<staff_type>();

                        ViewBag.ConfirmationMessage = "Your account has been created!";
                        ViewData["staffID"] = "Staff ID: " + staff.StaffID;
                        
                        return View("AccountCreated");
                    }
                    catch (Exception e)
                    {
                        return Error();
                    }
                }
            }

            return View(info);
        }
    }
}
