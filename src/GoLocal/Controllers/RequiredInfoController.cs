using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoLocal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GoLocal.Controllers
{
    public class RequiredInfoController : Controller
    {
        private OurDBContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;        

        public RequiredInfoController(IHostingEnvironment hostingEnvironment)
        {
            // _context = dbCon;
            _context = OurDBContextFactory.Create();
            _hostingEnvironment = hostingEnvironment;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RequiredInfo()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AdditionalInfo()
        {
            try
            {
                FillStaffTypes();                
                return View(new StaffAdditionalInfo());
            }
            catch (Exception) { return View(); }
            
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequiredInfo([Bind("FirstName,MiddleInitial,LastName,Address,City,ZipCode,State,Phone,DateOfBirth,Gender, Image")] StaffRequiredInfo info)
        {
            if (info.Phone != null && info.Phone.Length < 10)
            {
                ModelState.AddModelError("Phone", "Invalid phone number.");

            }
            var validImageTypes = new string[]
            {                   
                    "image/pjpeg",
                    "image/jpeg",
                    "image/tiff",
                    "image/gif",
                    "image/png",

            };

            if (info.Image == null || info.Image.Length == 0)
            {
                return View(info);
            }
            if (!validImageTypes.Contains(info.Image.ContentType))
            {
                ModelState.AddModelError("Image", "Please choose either a JPG, TIF,  GIF or PNG image.");
            }
            if (info.DateOfBirth == null)
            {
                return View(info);
            }else
            {
                DateTime dt = Convert.ToDateTime(info.DateOfBirth);
                if (dt > DateTime.Today)
                {
                    ModelState.AddModelError("DateOfBirth", "Date of birth must be before today's date ");
                }

            }
            
            if (ModelState.IsValid)
            {
                if (_context.registered_staff.Count() > 0)
                {
                    try
                    {
                        registered_staff staff = _context.registered_staff.Last();
                        staff.MiddleInitial = info.MiddleInitial;
                        staff.LastName = info.LastName;
                        staff.Address = info.Address;
                        staff.City = info.City;
                        staff.ZipCode = info.ZipCode;
                        staff.State = info.State;
                        staff.Phone = info.Phone;
                        staff.DateOfBirth = info.DateOfBirth;
                        staff.Gender = info.Gender;
                        staff.ImageName = info.Image.FileName;

                        var uploadDir = "uploads/images/" + staff.StaffID + "/";
                        var folderPath = Path.Combine(_hostingEnvironment.ContentRootPath,uploadDir);

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        var imagePath = Path.Combine(_hostingEnvironment.ContentRootPath, folderPath, info.Image.FileName);
                        await info.Image.CopyToAsync(new FileStream(imagePath,FileMode.Create, FileAccess.ReadWrite));                       

                        await _context.SaveChanges<registered_staff>();     

                        FillStaffTypes();

                        return RedirectToAction("AdditionalInfo");
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
