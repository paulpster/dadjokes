//using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using JokeAccess;

namespace webapp.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ILogger<SearchModel> _logger;
        public List<string> jokes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string term { get; set; }
        public SearchModel(ILogger<SearchModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            term = "sell";
            OnPostClick();
        }
        public PageResult OnPostClick() {
            _logger.LogDebug("SearchModel::OnPostClick");
            jokes = WebStuff.SearchJoke(term);
            return Page();
        }
        public string ReplaceTerm(string phrase) {
            MatchEvaluator mtch = new MatchEvaluator(MakeItBold);
            return Regex.Replace(phrase, term, mtch, RegexOptions.IgnoreCase);
        }
        public string MakeItBold(Match match) {
            return $"<b>{match.Value}</b>";
        }
    }
}
