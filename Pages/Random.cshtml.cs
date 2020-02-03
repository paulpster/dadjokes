using System;
using System.Timers;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using JokeAccess;

namespace webapp.Pages
{
    public class RandomModel : PageModel
    {
        private readonly ILogger<RandomModel> _logger;
        [BindProperty(SupportsGet = true)]
        public string recentJoke { get; set; }
        public RandomModel(ILogger<RandomModel> logger)
        {
            _logger = logger;
            _logger.LogDebug("RandomModel::RandomModel");
        }
        public void OnGet()
        {
            recentJoke = WebStuff.RandomJoke();
            _logger.LogDebug($"RandomModel::OnGet {recentJoke}");
        }
    }
}
