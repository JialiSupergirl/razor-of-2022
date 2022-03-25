using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_of_2022.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly StoreGameContext _dbContext;
    public IndexModel(ILogger<IndexModel> logger, StoreGameContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        _logger.Log(LogLevel.Information, "Index was get-ted");
    }
}
