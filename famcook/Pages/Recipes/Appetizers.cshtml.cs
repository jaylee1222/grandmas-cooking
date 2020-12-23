using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using famcook.Logic;
using famcook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace famcook.Pages.Recipes
{
    public class AppetizersModel : PageModel
    {
        private readonly ServerRepository ServerRepository;

        public List<Recipe> Recipes;

        public AppetizersModel(ServerRepository serverRepository)
        {
            ServerRepository = serverRepository;
        }
        public void OnGet()
        {
            Recipes = ServerRepository.FindRecipeByCat("Appetizers");
        }
    }
}
