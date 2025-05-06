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
      // StudentsList = await _context.Students.ToListAsync(); 
      
      //get students whose age is greater than 20 and give them in alphabetial order of fullname
      StudentsList = await _context.Students
         .Where(s => s.Age > 20)
         .OrderBy(s => s.FullName)
         .ToListAsync();
      
      
   }
}