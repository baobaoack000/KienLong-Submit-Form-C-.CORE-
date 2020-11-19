using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Threading.Tasks;
using KienLongC.Areas.Identity.Data;
using KienLongC.Data;
using KienLongC.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Authorization;

namespace KienLongC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly tblKienLongF _db;
        


        public HomeController(ILogger<HomeController> logger, tblKienLongF db)
        {
            
            _logger = logger;
            _db = db;
           
        }

        public IActionResult Home()
        {
            
            return View();

        }

        public IActionResult Index()
        {
           
            return View();
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult Form()
        {
            return View();
        }

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     

        [HttpPost]
        public async Task<IActionResult> Index(Form model)
        {
            using (tblKienLongF dataBase = new tblKienLongF())
            {
                
                Form m = new Form {
                    RegisDate = DateTime.Now,
                    EmailInput = model.EmailInput,
                    Rating = model.Rating, 
                    ContactType = model.ContactType,
                    StaffName = model.StaffName,
                    

                    
                };
                dataBase.Form.Add(m);
                dataBase.SaveChanges();
            }

         
            return View();
        }

        //[System.ComponentModel.DisplayName("!01")]
        //public IEnumerable<Form> form { get; set; }
        //Get:Form
        
        [HttpGet]
        public async Task<IActionResult> Form(int ? Id )
        {
            
            //if (id == null)
            //{
            //   return NotFound();
            //}
            var Forms = await _db.Form.ToListAsync();
            var count = Forms.Count();

            var list = new List<DateTime>();
            var hour = Forms.Select(a => a.RegisDate.Hour);
            ViewData["hour"] = hour; 
            ViewBag.Count = count;
            var TopEmply = Forms.Where(a => a.StaffName.Count()==1).ToString();
            ViewData["Emplyee"] = TopEmply;
           

            var vhappy = Forms.Where(a => a.Rating == "Rất hài lòng").Count();
            var ok = Forms.Where(a => a.Rating == "Tốt").Count();
            var normal = Forms.Where(a => a.Rating == "Bình thường, chấp nhận được").Count();
            var no = Forms.Where(a => a.Rating == "Chưa tốt").Count();
            var bad = Forms.Where(a => a.Rating == "Quá tệ").Count();
            ViewData["Happy"] = vhappy;
            ViewData["Ok"] = ok;
            ViewData["normal"] = normal;
            ViewData["no"] = no;
            ViewData["bad"] = bad;



            //Forms = (IList<Form>)(m => m.ID == id);


            return View(Forms);


        }


        //[HttpPost]
        //public ActionResult Form([Bind("EmailInput")] Form model)
        //{
        //    var content = new tblKienLongF();
        //    var form = new Form
        //    {

        //        EmailInput = model.EmailInput


        //};

        //    content.Database.CanConnect();
        //    content.Add(form);
        //    content.SaveChanges();

        //    return View();
        //}



       
     
     
    }
}
