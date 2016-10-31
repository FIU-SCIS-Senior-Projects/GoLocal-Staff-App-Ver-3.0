using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoLocal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GoLocal.Controllers
{
    public class SignUpController : Controller
    {
        private OurDBContext _context;

        public SignUpController(OurDBContext context)
        {
            _context = context;
            //_context = OurDBContextFactory.Create();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("Email,Password,ConfirmPassword")] registered_staff staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_context.registered_staff.Any(info => info.Email == staff.Email))
                    {
                        ModelState.AddModelError("", "The email address you entered is already in use");
                        ViewData["Message"] = "Already a member? Log In";
                        return View(staff);

                    }else
                    {
                        _context.Add(staff);
                        await _context.SaveChanges<registered_staff>();

                        return View("RequiredInfo");
                    }
                }
                else
                {
                    ViewData["Message"] = "Already a member? Log In";
                    return View(staff);
                }
            }
            catch (Exception e)
            {

                return Error();
            }
        }


    }
}
