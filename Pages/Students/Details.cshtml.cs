using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using StudentManager.Models;
using System.Threading.Tasks;

namespace StudentManager.Pages.Students;

public class Details : PageModel
{
    private readonly AppDbContext _context;

    public Details(AppDbContext context) => _context = context;

    public Student Student { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

        if (Student == null)
        {
            return NotFound();
        }

        return Page();
    }
}