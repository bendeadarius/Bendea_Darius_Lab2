using Bendea_Darius_Lab2.Data;
using Bendea_Darius_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bendea_Darius_Lab2.Pages.Members
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Bendea_Darius_Lab2.Data.Bendea_Darius_Lab2Context _context;

        public IndexModel(Bendea_Darius_Lab2.Data.Bendea_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Member> Members { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Members = await _context.Member.ToListAsync();
        }
    }
}
