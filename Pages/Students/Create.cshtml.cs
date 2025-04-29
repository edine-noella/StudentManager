using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManager.Data;
using StudentManager.Models;

namespace StudentManager.Pages.Students;

public class Create : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<Create> _logger;
    public Create(AppDbContext context, ILogger<Create> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    [BindProperty]
    public Student Student { get; set; }

    public IActionResult OnGet() => Page();
    
    public async Task<IActionResult> OnPostAsync()
    {
        
        _logger.LogInformation("OnPostAsync called with Student: {@Student}", Student);

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("ModelState is invalid.");
            return Page();
        }
        
        
        try
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Student added successfully: {@Student}", Student);
            return RedirectToPage("./Students");
        }
        catch (Exception ex)
        {
            // Log the error if something goes wrong
            _logger.LogError(ex, "Error occurred while saving the student.");
            ModelState.AddModelError(string.Empty, "An error occurred while saving the student.");
            return Page();
        }
   
    }
    
}