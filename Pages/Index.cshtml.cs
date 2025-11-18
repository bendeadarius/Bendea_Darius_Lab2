using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bendea_Darius_Lab2.Data;
using Bendea_Darius_Lab2.Models;

namespace Bendea_Darius_Lab2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Bendea_Darius_Lab2.Data.Bendea_Darius_Lab2Context _context;

        public IndexModel(Bendea_Darius_Lab2.Data.Bendea_Darius_Lab2Context context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
