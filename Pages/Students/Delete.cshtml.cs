using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using StudentManager.Models;

namespace StudentManager.Pages.Students;

public class Delete : PageModel
{
    private readonly AppDbContext _context;

    public Delete(AppDbContext context) => _context = context;

    [BindProperty]
    public Student Student { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

        if (Student == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var student = await _context.Students.FindAsync(Student.Id);

        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Students");
    }
}