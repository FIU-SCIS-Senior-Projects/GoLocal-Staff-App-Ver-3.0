using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoLocal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.IO;
using System.Web;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GoLocal.Controllers
{

    public class RequiredInfoController : Controller
    {
        private OurDBContext _context;
        

        public RequiredInfoController(OurDBContext dbCon)
        {

            _context = dbCon;
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
            catch (Exception e) { return View(); }
            
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
            var validImageTypes = new string[]
            {
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
            };

            if(info.Image == null || info.Image.Length == 0)
            {
                return View(info);
            }
            if (!validImageTypes.Contains(info.Image.ContentType))
            {
                ModelState.AddModelError("Image", "Please choose either a GIF, JPG or PNG image.");
            }


            if (ModelState.IsValid)
            {
                if (_context.registered_staff.Count() > 0)
                {
                    try
                    {
                        //var modifiedSourceInfo = _context.ChangeTracker.Entries<registered_staff>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
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

                        var uploadDir = "~/uploads";
                        var imagePath = Path.Combine(HttpContext.current)


                        await _context.SaveChanges<registered_staff>();                        


                        FillStaffTypes();

                        return RedirectToAction("AdditionalInfo");
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
