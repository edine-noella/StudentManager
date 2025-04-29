using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManager.Data;
using StudentManager.Models;

namespace StudentManager.Pages.Students;

public class Create : PageModel
{
    private readonly AppDbContext _context;
    public Create(AppDbContext context) => _context = context;
    
    [BindProperty]
    public Student Student { get; set; }

    public IActionResult OnGet() => Page();
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        
        
        _context.Students.Add(Student);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Students");
    }
    
}