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
            Ingredient ingredientTemp;
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
                        MessageShow("New Recipe");
                        Recipe recipeTemp;
                        MessageShow("Enter a Title");
                        string titleTemp = Console.ReadLine();
                        Console.Clear();
                        TryReadIngredientsCount(ref ingredientsCountTemp);
                        TryReadServingCount(ref servingCountTemp);
                        Console.Clear();
                        MessageShow("Enter the Cuisine");
                        string cuisineTemp = Console.ReadLine();
                        Console.Clear();
                        MessageShow("Enter Keywords in a line \nPress enter when you are finished");
                        List<string> keywordsTemp = new List<string>();
                        keywordsTemp.AddRange(Console.ReadLine().Split());
                        recipeTemp = new Recipe(titleTemp, null, new List<Ingredient>(ingredientsCountTemp), servingCountTemp, cuisineTemp, keywordsTemp);
                        int ingCounter = ingredientsCountTemp;
                        do
                        {
                            Console.Clear();
                            ingredientTemp = new Ingredient(null, null, 0, null);
                            MessageShow("Make New Ingredient \nEnter a Name");
                            ingredientTemp.Name = Console.ReadLine();
                            Console.Clear();
                            MessageShow("Enter the Description, please!");
                            ingredientTemp.Description = Console.ReadLine();
                            Console.Clear();
                            TryReadIngredientQuantity(ingredientTemp);
                            Console.Clear();
                            MessageShow("Enter the Unit");
                            ingredientTemp.Unit = Console.ReadLine();
                            Console.Clear();
                            recipeTemp.AddIngredient(ingredientTemp);
                            MessageShow($"{ingredientTemp.Name} has been added to your ingredients list");
                            ingCounter--;
                            MessageShow($"{ingCounter} Remaining \n");
                            MessageShow("Press any key to continue");
                            cki = Console.ReadKey();
                        } while (ingCounter > 0);
                        Console.Clear();
                        MessageShow("Enter the Instructions, please!");
                        recipeTemp.Instructions = Console.ReadLine();
                        Console.Clear();
                        MessageShow("Recipe Added Successfully");
                        fromMom.Add(recipeTemp);
                        MessageShow(recipeTemp.ToString());
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

        public static void MessageShow(string message)
        {
            Console.WriteLine(message);
        }

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
    }
}
