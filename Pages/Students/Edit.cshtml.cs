using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using StudentManager.Models;
using System.Threading.Tasks;

namespace StudentManager.Pages.Students;

public class Edit : PageModel
{
    private readonly AppDbContext _context;

    public Edit(AppDbContext context) => _context = context;

    [BindProperty]
    public Student Student { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Student = await _context.Students.FindAsync(id);

        if (Student == null)
        {
            return NotFound();
        }

        return Page();
    }

    // public async Task<IActionResult> OnPostAsync()
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return Page();
    //     }
    //
    //     _context.Attach(Student).State = EntityState.Modified;
    //
    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!_context.Students.Any(e => e.Id == Student.Id))
    //         {
    //             return NotFound();
    //         }
    //
    //         throw;
    //     }
    //
    //     return RedirectToPage("./Students");
    // }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var studentToUpdate = await _context.Students.FindAsync(Student.Id);
    
        if (studentToUpdate == null)
        {
            return NotFound();
        }

        studentToUpdate.FullName = Student.FullName;
        studentToUpdate.Age = Student.Age;
        studentToUpdate.City = Student.City;
        studentToUpdate.EnrollmentDate = Student.EnrollmentDate;

        await _context.SaveChangesAsync();
        return RedirectToPage("./Students");
    }
    
}