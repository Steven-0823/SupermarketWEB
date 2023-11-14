using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayMode
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Pay_Mode> pay_Modes { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.payModes != null)
            {
                pay_Modes = await _context.payModes.ToListAsync();

            }
        }
    }
}
