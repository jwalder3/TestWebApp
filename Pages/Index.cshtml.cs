using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppWithForm.Data;
using WebAppWithForm.Models;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Contact Contact { get; set; }

    public bool FormSubmitted { get; private set; }

    public void OnGet()
    {
        FormSubmitted = false;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Contacts.Add(Contact);
        _context.SaveChanges();
        FormSubmitted = true;

        return Page();
    }
}
