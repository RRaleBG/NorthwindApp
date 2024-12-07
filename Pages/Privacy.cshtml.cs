using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;


        public PrivacyModel(ILogger<PrivacyModel> logger)
        {     
            _logger = logger;
        }


        [BindProperty]
        public IList<String> Message { get; set; }

        public ILogger<PrivacyModel> Get_logger()
        {
            _logger.LogError("Error", _logger.ToString());

            _logger.LogInformation("Information", _logger.ToString());

            _logger.LogCritical("Critical", _logger.ToString());

            _logger.LogDebug("Debug", _logger.ToString());

            _logger.LogTrace("Debug", _logger.ToString());

            _logger.LogWarning("Warning", _logger.ToString());

      
            return _logger;
        }
        
    }
}
