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
                Console.WriteLine($"Press N(ew), D(el), S(earch)or L(ist)");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.N:
                        Console.Clear();
                        Console.WriteLine("New Recipe");
                        Recipe recipeTemp;
                        Console.WriteLine("Enter a Title");
                        string titleTemp = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Enter the Instructions, please!");
                        string instructionsTemp = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("How many ingredients will you need?");
                        int ingredientsCountTemp = 0;
                        bool isValid = false;
                        do
                        {
                            try
                            {
                                ingredientsCountTemp = int.Parse(Console.ReadLine());
                                Console.Clear();
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
                        Console.WriteLine("How many people is this recipe going to serve for?");
                        int servingCountTemp = 0;
                        isValid = false;
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
                        Console.WriteLine("Enter Keywords");
                        string[] keywordsTemp = Console.ReadLine().Split();
                        recipeTemp = new Recipe(titleTemp, instructionsTemp, new Ingredient[ingredientsCountTemp], servingCountTemp, cuisineTemp, keywordsTemp);
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
                            Console.WriteLine("Press any key to continue");
                            cki = Console.ReadKey();
                            ingCounter--;
                        } while (ingCounter > 0);
                        Console.Clear();
                        Console.WriteLine("Recipe Added Successfully");
                        fromMom.Add(recipeTemp);
                        Console.WriteLine(recipeTemp.ToString());
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        Console.WriteLine("Delete Recipe");
                        Console.WriteLine("Enter Recipe Title to delete");
                        string deletedTitle = Console.ReadLine();
                        Console.Clear();
                        fromMom.Remove(deletedTitle);
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        Console.WriteLine("Search Recipe");
                        Console.WriteLine("Search by T(itle), K(eyword) or C(uisine)");
                        cki = Console.ReadKey();
                        Console.Clear();
                        switch (cki.Key)
                        {
                            case ConsoleKey.T:
                                Console.WriteLine("Enter the Title");
                                Recipe recipeSearchTitle = fromMom.LookupByTitle(Console.ReadLine());
                                if (recipeSearchTitle != null)
                                    Console.WriteLine(fromMom.SearchResult(recipeSearchTitle));
                                break;
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
                    case ConsoleKey.L:
                        Console.Clear();
                        Console.WriteLine("List of Recipes\n");
                        for (int i = 0; fromMom.RecipeList[i] != null; i++)
                        {
                            Console.WriteLine($"{i + 1}.{fromMom.RecipeList[i].Title}");
                        }
                        Console.WriteLine();
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
