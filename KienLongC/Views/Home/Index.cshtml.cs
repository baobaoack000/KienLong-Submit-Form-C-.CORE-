using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KienLongC.Data;
using KienLongC.Models;

namespace KienLongC.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly KienLongC.Data.tblKienLongF _context;

        public IndexModel(KienLongC.Data.tblKienLongF context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult OnGet() { return Page(); }
        [BindProperty]
        public Form Form { get;set; }

        [HttpGet]
        public async Task<IActionResult> OnGetAsync()
        {
            _context.Form.Add(Form);
            await _context.Form.ToListAsync();
            return RedirectToPage("./Form");
        }
    }
}
