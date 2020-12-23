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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace famcook.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private ServerRepository context;

        private readonly IWebHostEnvironment hostingEnvironment;

        public bool RecipeWasSubmitted;

        [BindProperty]
        public string Instruction { get; set; }

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public CreateModel(ServerRepository _context, IWebHostEnvironment environment)
        {
            this.hostingEnvironment = environment;
            context = _context;
        }

        public async void OnPostSaveRecipe()
        {
            string FileName = Guid.NewGuid().ToString() + ".jpg";
            var filePath = Path.Combine(hostingEnvironment.WebRootPath, FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.CopyToAsync(stream);
                Recipe.ImageName = filePath;
            }
            Recipe.Instructions = Instruction.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            context.Insert(Recipe);
            RecipeWasSubmitted = true;
        }
    }
}
