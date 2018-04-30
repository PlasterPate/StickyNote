using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Program
    {
        static void Main(string[] args)
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);
            Ingredient ingredientTemp = new Ingredient();
            int ingredientsCountTemp = 0;
            int servingCountTemp = 0;
            int editNum = 0;
            ConsoleKeyInfo cki;
            do
            {
                MessageShow($"Press (N)ew, (D)el, (S)earch, (L)ist, sa(V)e or l(O)ad");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    // New Recipe
                    case ConsoleKey.N:
                        Console.Clear();
                        Recipe recipeTemp = new Recipe();
                        GetRecipe(fromMom, recipeTemp, ingredientTemp, ingredientsCountTemp, servingCountTemp, cki);
                        break;
                    // Delete recipe by name
                    case ConsoleKey.D:
                        Console.Clear();
                        MessageShow("Delete Recipe");
                        MessageShow("Enter Recipe Title to delete");
                        string deletedTitle = Console.ReadLine();
                        Console.Clear();
                        fromMom.Remove(deletedTitle);
                        break;
                    // Search
                    case ConsoleKey.S:
                        Console.Clear();
                        MessageShow("Search Recipe");
                        MessageShow("Search by T(itle), K(eyword) or C(uisine)");
                        cki = Console.ReadKey();
                        Console.Clear();
                        switch (cki.Key)
                        {
                            // Search by title
                            case ConsoleKey.T:
                                MessageShow("Enter the Title");
                                Recipe recipeSearchTitle = fromMom.LookupByTitle(Console.ReadLine());
                                if (recipeSearchTitle != null)
                                    Console.WriteLine(fromMom.SearchResult(recipeSearchTitle));
                                break;
                            // Search by keywords
                            case ConsoleKey.K:
                                MessageShow("Enter the Keyword");
                                List<Recipe> recipeSearchKeyword = fromMom.LookupByKeyword(Console.ReadLine());
                                if (recipeSearchKeyword != null)
                                    foreach (Recipe recipe in recipeSearchKeyword)
                                    {
                                        if (recipe == null)
                                            break;
                                        Console.WriteLine(fromMom.SearchResult(recipe));
                                    }
                                break;
                            // search by cuisine
                            case ConsoleKey.C:
                                MessageShow("Enter the Cuisine");
                                List<Recipe> recipeSearchCuisine = fromMom.LookupByCuisine(Console.ReadLine());
                                if (recipeSearchCuisine != null)
                                    foreach (Recipe recipe in recipeSearchCuisine)
                                    {
                                        if (recipe == null)
                                            break;
                                        Console.WriteLine(fromMom.SearchResult(recipe));
                                    }
                                break;
                            default:
                                MessageShow($"Invalid Key: {cki.KeyChar}");
                                break;
                        }
                        break;
                    // Show list of recipes
                    case ConsoleKey.L:
                        Console.Clear();
                        MessageShow("List of Recipes\n");
                        fromMom.ListShow();
                        MessageShow("Press E(dit) or another ke to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.E)
                        {
                            TryReadRecNum(fromMom, ref editNum);
                            Console.Clear();
                            MessageShow(fromMom.SearchResult(fromMom.RecipeList[editNum - 1]));
                            TryUpdateServingCount(fromMom, ref editNum);
                        }
                        else
                            Console.Clear();
                        break;
                    // Exit
                    case ConsoleKey.V:
                        fromMom.Save(Recipe.RecipeFilePath);
                        break;
                    case ConsoleKey.O:
                        fromMom.Load(Recipe.RecipeFilePath);
                        break;
                    case ConsoleKey.Escape:
                        MessageShow("Esc");
                        break;
                    default:
                        MessageShow($"Invalid Key: {cki.KeyChar}");
                        break;
                }

                MessageShow("Press any key to continue, Esc to exit");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Writes a message on console
        /// </summary>
        /// <param name="message">message string</param>
        public static void MessageShow(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// tries to read a valid number for ingredient count
        /// </summary>
        /// <param name="ingCount"></param>
        /// <param name="isTest"></param>
        public static void TryReadIngredientsCount(ref int ingCount ,bool isTest = false)
        {
            MessageShow("How many ingredients will you need?");
            
            // A flag to check if user has enterd a valid number
            bool isValid = false;
            // gets an input until user enters a valid number
            do
            {
                try
                {
                    ingCount = int.Parse(Console.ReadLine());
                    if (!isTest) Console.Clear();
                    // Make sure that user enters a positive number
                    if (ingCount > 0)
                        isValid = true;
                    else
                        MessageShow("The Recipe needs at least 1 ingredient");
                }
                catch
                {
                    if (!isTest) Console.Clear();
                    MessageShow("Please enter a valid number!");
                }
            } while (isValid == false && isTest == false);
        }

        /// <summary>
        /// tries to get a valid number for serving count
        /// </summary>
        /// <param name="serveCount"></param>
        /// <param name="isTest"></param>
        public static void TryReadServingCount(ref int serveCount ,bool isTest = false)
        {
            MessageShow("How many people is this recipe going to serve?");
            bool isValid = false;
            // gets an input until user enters a valid number
            do
            {
                try
                {
                    serveCount = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch
                {
                    if (!isTest) Console.Clear();
                    MessageShow("Please enter a valid number!");
                }
            } while (isValid == false && isTest == false);

        }

        /// <summary>
        /// tries to get a valid number for ingredient quantity
        /// </summary>
        /// <param name="ing"></param>
        /// <param name="isTest"></param>
        public static void TryReadIngredientQuantity(Ingredient ing ,bool isTest = false)
        {
            MessageShow("Enter the Quantity");
            bool isValid = false;
            // gets an input until user enters a valid number
            do
            {
                try
                {
                    ing.Quantity = double.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch
                {
                    if (!isTest) Console.Clear();
                    MessageShow("Please enter a valid number!");
                }
            } while (isValid == false && isTest == false);
        }

        /// <summary>
        /// tries to get a valid number for recipe in list
        /// </summary>
        /// <param name="recBook"></param>
        /// <param name="recNum"></param>
        /// <param name="isTest"></param>
        public static void TryReadRecNum(RecipeBook recBook, ref int recNum, bool isTest = false)
        {
            MessageShow("Enter the recipe number");
            bool isValid = false;
            // gets an input until user enters a valid number
            do
            {
                try
                {
                    recNum = int.Parse(Console.ReadLine());
                    if (!isTest) Console.Clear();
                    if (recNum > 0 && recNum <= recBook.RecipeList.Count)
                        isValid = true;
                    else
                    {
                        recBook.ListShow();
                        MessageShow("\nPlease select a number from list above");
                    }
                }
                catch
                {
                    if (!isTest) Console.Clear();
                    MessageShow("Please enter a valid number!");
                }
            } while (isValid == false && isTest == false);
        }

        /// <summary>
        /// tries to get a valid number for new srving count
        /// </summary>
        /// <param name="recBook"></param>
        /// <param name="editNum"></param>
        /// <param name="isTest"></param>
        public static void TryUpdateServingCount(RecipeBook recBook, ref int editNum, bool isTest = false)
        {
            MessageShow("\nTo update the serving count enter a new one");
            bool isValid = false;
            // gets an input until user enters a valid number
            do
            {
                try
                {
                    recBook.RecipeList[editNum - 1].UpdateServingCount(int.Parse(Console.ReadLine()));
                    isValid = true;
                }
                catch
                {
                    if (!isTest) Console.Clear();
                    MessageShow("Please enter a valid number!");
                }
            } while (isValid == false && isTest == false);
            //fromMom.RecipeList[editNum - 1].UpdateServingCount(int.Parse(Console.ReadLine()));
            MessageShow("Recipe edited successfully!");
        }

        /// <summary>
        /// gets fields of an ingredient and make one then add it to recipe
        /// </summary>
        /// <param name="recTemp"></param>
        /// <param name="ingTemp"></param>
        /// <param name="cki"></param>
        /// <param name="ingredientsCountTemp"></param>
        /// <param name="isTest"></param>
        public static void GetIngredient(Recipe recTemp ,Ingredient ingTemp ,ConsoleKeyInfo cki , int ingredientsCountTemp, bool isTest = false)
        {
            int ingCounter = ingredientsCountTemp;
            do
            {
                if (!isTest) Console.Clear();
                ingTemp = new Ingredient();
                MessageShow("Make New Ingredient \nEnter a Name");
                ingTemp.Name = Console.ReadLine();
                if (!isTest) Console.Clear();
                MessageShow("Enter the Description, please!");
                ingTemp.Description = Console.ReadLine();
                if (!isTest) Console.Clear();
                TryReadIngredientQuantity(ingTemp);
                if (!isTest) Console.Clear();
                MessageShow("Enter the Unit");
                ingTemp.Unit = Console.ReadLine();
                if (!isTest) Console.Clear();
                recTemp.AddIngredient(ingTemp);
                MessageShow($"{ingTemp.Name} has been added to your ingredients list");
                ingCounter--;
                MessageShow($"{ingCounter} Remaining \n");
                MessageShow("Press any key to continue");
                if (!isTest) cki = Console.ReadKey();
            } while (ingCounter > 0);
        }

        /// <summary>
        /// gets fields of a recipe and make one then adds it to recipe book
        /// </summary>
        /// <param name="fromMom"></param>
        /// <param name="recipeTemp"></param>
        /// <param name="ingTemp"></param>
        /// <param name="ingCountTemp"></param>
        /// <param name="servCountTemp"></param>
        /// <param name="cki"></param>
        /// <param name="isTest"></param>
        public static void GetRecipe(RecipeBook fromMom, Recipe recipeTemp,Ingredient ingTemp,
            int ingCountTemp, int servCountTemp, ConsoleKeyInfo cki, bool isTest = false )
        {
            MessageShow("New Recipe");
            MessageShow("Enter a Title");
            string titleTemp = Console.ReadLine();
            if (!isTest) Console.Clear();
            if (!isTest) TryReadIngredientsCount(ref ingCountTemp, isTest);
            if (!isTest) TryReadServingCount(ref servCountTemp, isTest);
            if (!isTest) Console.Clear();
            MessageShow("Enter the Cuisine");
            string cuisineTemp = Console.ReadLine();
            if (!isTest) Console.Clear();
            MessageShow("Enter Keywords in a line \nPress enter when you are finished");
            List<string> keywordsTemp = new List<string>();
            keywordsTemp.AddRange(Console.ReadLine().Split());
            recipeTemp = new Recipe(titleTemp, null, new List<Ingredient>(ingCountTemp), servCountTemp, cuisineTemp, keywordsTemp);
            if (!isTest) GetIngredient(recipeTemp, ingTemp, cki, ingCountTemp, isTest);
            if (!isTest) Console.Clear();
            MessageShow("Enter the Instructions, please!");
            recipeTemp.Instructions = Console.ReadLine();
            if (!isTest) Console.Clear();
            MessageShow("Recipe Added Successfully");
            fromMom.Add(recipeTemp);
            MessageShow(recipeTemp.ToString());
        }
    }
}
