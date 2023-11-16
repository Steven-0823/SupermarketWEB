using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class EditModel : PageModel
    {
			private readonly SupermarketContext _context;

			public EditModel(SupermarketContext context)
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
				var pamode = await _context.payModes.FirstOrDefaultAsync(m => m.Id == id);
				if (pamode == null)
				{
					return NotFound();
				}
				PayMode = pamode;
				return Page();

			}
			public async Task<IActionResult> OnPostAsync()
			{
				if (!ModelState.IsValid)
				{
					return Page();
				}
				_context.Attach(PayMode).State = EntityState.Modified;

				try
				{
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CategoryExists(PayMode.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}

				}
				return RedirectToPage("./Index");
			}
			private bool CategoryExists(int id)
			{
				return (_context.payModes?.Any(e => e.Id == id)).GetValueOrDefault();
			}
		}
}
