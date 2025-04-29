using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using StudentManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManager.Pages.Students;

public class Students : PageModel
{
   
   private readonly AppDbContext _context;
   public Students(AppDbContext context) => _context = context;
   
   public IList<Student> StudentsList { get; set; }
   
   public async Task OnGetAsync()
   {
      StudentsList = await _context.Students.ToListAsync();
   }
}