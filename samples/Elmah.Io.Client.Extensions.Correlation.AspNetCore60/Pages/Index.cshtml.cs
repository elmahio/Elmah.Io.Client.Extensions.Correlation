using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Elmah.Io.Client.Extensions.Correlation.AspNetCore60.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogWarning("An error is about to happen");
            throw new ApplicationException("The error happens");
        }
    }
}