using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManager.Services;

namespace StudentManager.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITimeService _timeService;

    public IndexModel(ILogger<IndexModel> logger,  ITimeService timeService)
    {
        _logger = logger;
        _timeService = timeService; 
    }
    
    public string CurrentTime { get; set; }

    public void OnGet()
    {
        CurrentTime = _timeService.GetCurrentTime();
    }
}