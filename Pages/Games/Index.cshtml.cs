#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_of_2022.Model;

namespace razor_of_2022.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly StoreGameContext _context;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true, Name = "Query")]
        public string Query { get; set; }

        [BindProperty(SupportsGet = true, Name = "PTime")]
        public string PTime { get; set; }

        [BindProperty(SupportsGet = true, Name = "IsBefore")]
        public bool IsBefore { get; set; }

        [BindProperty(SupportsGet = true, Name = "IsAfter")]
        public bool IsAfter { get; set; }

        [BindProperty(SupportsGet = true, Name = "IsFilterByDate")]
        public bool IsFilterByDate { get; set; }

        public IndexModel(StoreGameContext context, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Game> Games { get; set; }

        public async Task OnGetAsync()
        {
            var games = from g in _context.Game select g;

            if (!string.IsNullOrEmpty(Query) && !string.IsNullOrEmpty(PTime))
            {
                if (IsBefore && !IsFilterByDate && !IsAfter)
                {
                    games = games.Where(g => g.Title.ToLower().Contains(Query.ToLower()) &&
                                            g.DatePublished <= DateTime.Parse(PTime));
                    // _logger.Log(LogLevel.Information, PTime);
                    // _logger.Log(LogLevel.Information, Query);
                }

                else if (!IsBefore && IsAfter && !IsFilterByDate)
                {
                    games = games.Where(g => g.Title.ToLower().Contains(Query.ToLower()) &&
                                            g.DatePublished >= DateTime.Parse(PTime));
                }


                else if (IsFilterByDate)
                {
                    games = games.Where(g => g.Title.ToLower().Contains(Query.ToLower()));
                }
            }
            Games = await games.ToListAsync();
        }
    }
}
