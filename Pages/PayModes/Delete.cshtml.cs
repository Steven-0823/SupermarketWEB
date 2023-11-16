using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class DeleteModel : PageModel
    {
		private readonly SupermarketContext _context;

		public DeleteModel(SupermarketContext context)
		{

			_context = context;
		}
		[BindProperty]

		public PayMode PayMode { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.payModes == null)
			{
				return NotFound();

			}
			var paymode = await _context.payModes.FirstOrDefaultAsync(m => m.Id == id);

			if (paymode == null)
			{
				return NotFound();
			}
			else
			{
				PayMode = paymode;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.payModes == null)
			{
				return NotFound();
			}
			var paymode = await _context.payModes.FindAsync(id);

			if (paymode != null)
			{
				PayMode = paymode;
				_context.payModes.Remove(PayMode);
				await _context.SaveChangesAsync();

			}
			return RedirectToPage("./Index");
		}
	}
}
