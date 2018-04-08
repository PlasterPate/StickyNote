using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);
            Ingredient ingredientTemp;
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine($"Press (N)ew, (D)el, (S)earch, (L)ist, sa(V)e or l(O)ad");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    // New Recipe
                    case ConsoleKey.N:
                        Console.Clear();
                        Console.WriteLine("New Recipe");
                        Recipe recipeTemp;
                        Console.WriteLine("Enter a Title");
                        string titleTemp = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("How many ingredients will you need?");
                        int ingredientsCountTemp = 0;
                        // A flag to check if user has enterd a valid number
                        bool isValid = false;
                        // gets an input until user enters a valid number
                        do
                        {
                            try
                            {
                                ingredientsCountTemp = int.Parse(Console.ReadLine());
                                Console.Clear();
                                // Make sure that user enters a positive number
                                if (ingredientsCountTemp > 0)
                                    isValid = true;
                                else
                                    Console.WriteLine("The Recipe needs at least 1 ingredient");
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid number!");
                            }
                        } while (isValid == false);
                        Console.WriteLine("How many people is this recipe going to serve?");
                        int servingCountTemp = 0;
                        isValid = false;
                        // gets an input until user enters a valid number
                        do
                        {
                            try
                            {
                                servingCountTemp = int.Parse(Console.ReadLine());
                                isValid = true;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid number!");
                            }
                        } while (isValid == false);
                        Console.Clear();
                        Console.WriteLine("Enter the Cuisine");
                        string cuisineTemp = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Enter Keywords in a line \nPress enter when you are finished");
                        string[] keywordsTemp = Console.ReadLine().Split();
                        recipeTemp = new Recipe(titleTemp, null, new Ingredient[ingredientsCountTemp], servingCountTemp, cuisineTemp, keywordsTemp);
                        int ingCounter = ingredientsCountTemp;
                        do
                        {
                            Console.Clear();
                            ingredientTemp = new Ingredient(null, null, 0, null);
                            Console.WriteLine("Make New Ingredient \nEnter a Name");
                            ingredientTemp.Name = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Enter the Description, please!");
                            ingredientTemp.Description = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Enter the Quantity");
                            isValid = false;
                            // gets an input until user enters a valid number
                            do
                            {
                                try
                                {
                                    ingredientTemp.Quantity = double.Parse(Console.ReadLine());
                                    isValid = true;
                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid number!");
                                }
                            } while (isValid == false);
                            Console.Clear();
                            Console.WriteLine("Enter the Unit");
                            ingredientTemp.Unit = Console.ReadLine();
                            Console.Clear();
                            recipeTemp.AddIngredient(ingredientTemp);
                            Console.WriteLine($"{ingredientTemp.Name} has been added to your ingredients list");
                            ingCounter--;
                            Console.WriteLine($"{ingCounter} Remaining \n");
                            Console.WriteLine("Press any key to continue");
                            cki = Console.ReadKey();
                        } while (ingCounter > 0);
                        Console.Clear();
                        Console.WriteLine("Enter the Instructions, please!");
                        recipeTemp.Instructions = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Recipe Added Successfully");
                        fromMom.Add(recipeTemp);
                        Console.WriteLine(recipeTemp.ToString());
                        break;
                    // Delete recipe by name
                    case ConsoleKey.D:
                        Console.Clear();
                        Console.WriteLine("Delete Recipe");
                        Console.WriteLine("Enter Recipe Title to delete");
                        string deletedTitle = Console.ReadLine();
                        Console.Clear();
                        fromMom.Remove(deletedTitle);
                        break;
                    // Search
                    case ConsoleKey.S:
                        Console.Clear();
                        Console.WriteLine("Search Recipe");
                        Console.WriteLine("Search by T(itle), K(eyword) or C(uisine)");
                        cki = Console.ReadKey();
                        Console.Clear();
                        switch (cki.Key)
                        {
                            // Search by title
                            case ConsoleKey.T:
                                Console.WriteLine("Enter the Title");
                                Recipe recipeSearchTitle = fromMom.LookupByTitle(Console.ReadLine());
                                if (recipeSearchTitle != null)
                                    Console.WriteLine(fromMom.SearchResult(recipeSearchTitle));
                                break;
                            // Search by keywords
                            case ConsoleKey.K:
                                Console.WriteLine("Enter the Keyword");
                                Recipe[] recipeSearchKeyword = fromMom.LookupByKeyword(Console.ReadLine());
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
                                Console.WriteLine("Enter the Cuisine");
                                Recipe[] recipeSearchCuisine = fromMom.LookupByCuisine(Console.ReadLine());
                                if (recipeSearchCuisine != null)
                                    foreach (Recipe recipe in recipeSearchCuisine)
                                    {
                                        if (recipe == null)
                                            break;
                                        Console.WriteLine(fromMom.SearchResult(recipe));
                                    }
                                break;
                            default:
                                Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                                break;
                        }
                        break;
                    // Show list of recipes
                    case ConsoleKey.L:
                        Console.Clear();
                        Console.WriteLine("List of Recipes\n");
                        fromMom.ListShow();
                        Console.WriteLine("Press E(dit) or another ke to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.E)
                        {
                            Console.WriteLine("Enter the recipe number");
                            int editNum = 0;
                            isValid = false;
                            // gets an input until user enters a valid number
                            do
                            {
                                try
                                {
                                    editNum = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    if (editNum > 0 && editNum <= fromMom.RecipeCount())
                                        isValid = true;
                                    else
                                    {
                                        fromMom.ListShow();
                                        Console.WriteLine("\nPlease select a number from list above");
                                    }
                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid number!");
                                }
                            } while (isValid == false);
                            Console.Clear();
                            Console.WriteLine(fromMom.SearchResult(fromMom.RecipeList[editNum - 1]));
                            Console.WriteLine("\nTo update the serving count enter a new one");
                            isValid = false;
                            // gets an input until user enters a valid number
                            do
                            {
                                try
                                {
                                    fromMom.RecipeList[editNum - 1].UpdateServingCount(int.Parse(Console.ReadLine()));
                                    isValid = true;
                                }
                                catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid number!");
                                }
                            } while (isValid == false);
                            //fromMom.RecipeList[editNum - 1].UpdateServingCount(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Recipe edited successfully!");
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
                        Console.WriteLine("Esc");
                        break;
                    default:
                        Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                        break;
                }

                Console.WriteLine("Press any key to continue, Esc to exit");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }


    }
}
