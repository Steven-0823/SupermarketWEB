using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    public class CreateModel : PageModel
    {
		private readonly SupermarketContext _context;
		public CreateModel(SupermarketContext context)
		{

			_context = context;

		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public PayMode PayMode { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.payMode == null || PayMode == null)
			{
				return Page();

			}
			_context.payMode.Add(PayMode);
			await _context.SaveChangesAsync();
			return RedirectToPage("./Index");
		}
	}
}
