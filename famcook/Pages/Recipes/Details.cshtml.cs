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
using MongoDB.Bson;

namespace famcook.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly ServerRepository context;

        public Recipe Recipe { get; set; }

        public DetailsModel(ServerRepository _context)
        {
            context = _context;
        }

        public void OnGet(string? id)
        {
            Recipe = context.FindRecipeByID(id);

            Console.WriteLine("HI");
        }
    }
}
