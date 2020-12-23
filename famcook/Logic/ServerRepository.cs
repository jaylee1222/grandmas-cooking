using System;
using System.Collections.Generic;
using famcook.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace famcook.Logic
{
    public class ServerRepository
    {
        private readonly IDatabaseSettings Context;

        protected IMongoCollection<Recipe> Recipes;

        public GridFSBucket bucket;

        public ServerRepository(IDatabaseSettings context)
        {
            Context = context;

            Recipes = Context.GetCollection<Recipe>(typeof(Recipe).Name?.ToLower());
        }

        public List<Recipe> FindRecipes(string recipename)
        {
            var filter = new BsonDocument("RecipeName", recipename);
            var result = Recipes.Find(filter).ToList();

            return result;    
        }

        public List<Recipe> FindRecipeByCat(string category)
        {
            var filter = new BsonDocument("FoodCat", category);
            var result = Recipes.Find(filter).ToList();

            return result;
        }

        public void Insert(Recipe recipe)
        {
            Recipe document = new Recipe();

            document.RecipeName = recipe.RecipeName;
            document.PrepTime = recipe.PrepTime;
            document.FoodCat = recipe.FoodCat;
            document.Ingredients = recipe.Ingredients;
            document.Instructions = recipe.Instructions;
            document.ImageName = recipe.ImageName;
            document.TimeSubmitted = DateTime.UtcNow;


            Recipes.InsertOne(document);
        }

        public List<Recipe> FindAllRecipes()
        {
            var result = Recipes.Find(FilterDefinition<Recipe>.Empty).ToList();

            return result;
        }

        public Recipe FindRecipeByID(string id)
        {
            var filter = new BsonDocument("_id", ObjectId.Parse(id));
            var result = Recipes.Find(filter).FirstOrDefault();

            return result;
        }

        public List<Recipe> FindRecipesForCarousel()
        {
            var result = Recipes.Find(FilterDefinition<Recipe>.Empty).Limit(5).ToList();

            return result;
        }
    }
}
