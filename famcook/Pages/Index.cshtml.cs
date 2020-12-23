using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using famcook.Logic;
using famcook.Models;

namespace famcook.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        private readonly ServerRepository context;

        public List<Recipe> RecipeList;

        public List<Recipe> ViewBag;

        public IndexModel(ServerRepository _context)
        {
            context = _context;
        }

        public void OnGet()
        {
            RecipeList = context.FindAllRecipes();
            GetTimeRecipes();
        }

        public void GetTimeRecipes()
        {
            ViewBag = context.FindRecipesForCarousel();
        }
    }
}
