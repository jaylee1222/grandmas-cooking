using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using famcook.Data;
using famcook.Models;
using famcook.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace famcook.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly ServerRepository context;

        public List<Recipe> RecipeList;

        public IndexModel(ServerRepository _context)
        {
            context = _context;
        }

        public void OnGet()
        {
            RecipeList = context.FindAllRecipes();
        }
    }
}