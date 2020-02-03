using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webapp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            _logger.LogDebug("PrivacyModel::PrivacyModel");
        }
        ~PrivacyModel(){
            _logger.LogDebug("PrivacyModel::~PrivacyModel");
        }

        public void OnGet()
        {
            _logger.LogDebug("PrivacyModel::OnGet");
        }
    }
}
