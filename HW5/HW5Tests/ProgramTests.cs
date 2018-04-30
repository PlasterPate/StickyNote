using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MessageShowTest()
        {
            string testMessage = "test message";
            string filePath = "message.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Console.SetOut(writer);
                Program.MessageShow(testMessage);
                Console.SetOut(Console.Out);
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.SetIn(reader);
                Assert.AreEqual(testMessage, Console.ReadLine());
                Console.SetIn(Console.In);
            }
        }

        [TestMethod()]
        public void TryReadIngredientsCountTest()
        {
            int ingCount = 0;
            string ingCountTest1 = "5";
            string ingCountTest2 = "-1";
            string ingCountTest3 = "string";
            using (StringReader reader = new StringReader(ingCountTest1))
            {
                Console.SetIn(reader);
                Program.TryReadIngredientsCount(ref ingCount, true);
                Assert.AreEqual(int.Parse(ingCountTest1), ingCount);
                Console.SetIn(Console.In);
            }
            ingCount = 0;
            using (StringReader reader = new StringReader(ingCountTest2))
            {
                Console.SetIn(reader);
                Program.TryReadIngredientsCount(ref ingCount, true);
                Assert.AreEqual(int.Parse(ingCountTest2), ingCount);
                Console.SetIn(Console.In);
            }
            ingCount = 0;
            using (StringReader reader = new StringReader(ingCountTest3))
            {
                Console.SetIn(reader);
                Program.TryReadIngredientsCount(ref ingCount, true);
                Assert.AreEqual(ingCount, ingCount);
                Console.SetIn(Console.In);
            }
        }

        [TestMethod()]
        public void TryReadServingCountTest()
        {
            int serveCount = 0;
            string serveCountTest1 = "4";
            string serveCountTest2 = "-2";
            string serveCountTest3 = "string";
            using (StringReader reader = new StringReader(serveCountTest1))
            {
                Console.SetIn(reader);
                Program.TryReadServingCount(ref serveCount, true);
                Assert.AreEqual(int.Parse(serveCountTest1), serveCount);
                Console.SetIn(Console.In);
            }
            serveCount = 0;
            using (StringReader reader = new StringReader(serveCountTest2))
            {
                Console.SetIn(reader);
                Program.TryReadServingCount(ref serveCount, true);
                Assert.AreEqual(int.Parse(serveCountTest2), serveCount);
                Console.SetIn(Console.In);
            }
            serveCount = 0;
            using (StringReader reader = new StringReader(serveCountTest3))
            {
                Console.SetIn(reader);
                Program.TryReadServingCount(ref serveCount, true);
                Assert.AreEqual(serveCount, serveCount);
                Console.SetIn(Console.In);
            }
        }

        [TestMethod()]
        public void TryReadIngredientQuantityTest()
        {
            string name = "nameTest";
            string description = "descriptionTest";
            double quantity = 0;
            string unit = "unitTest";
            Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
            string quantityTest1 = "4";
            string quantityTest2 = "string";
            using (StringReader reader = new StringReader(quantityTest1))
            {
                Console.SetIn(reader);
                Program.TryReadIngredientQuantity(ingredientTest, true);
                Assert.AreEqual(int.Parse(quantityTest1), ingredientTest.Quantity);
                Console.SetIn(Console.In);
            }
            ingredientTest.Quantity = 0;
            using (StringReader reader = new StringReader(quantityTest2))
            {
                Console.SetIn(reader);
                Program.TryReadIngredientQuantity(ingredientTest, true);
                Assert.AreEqual(ingredientTest.Quantity, ingredientTest.Quantity);
                Console.SetIn(Console.In);
            }
        }

        [TestMethod()]
        public void TryReadEditNumTest()
        {
            string bookTitle = "bookTitleTest";
            int capacity = 2;
            RecipeBook recipeBookTest = new RecipeBook(bookTitle, capacity);
            string title = "titleTest";
            string instructions = "instructionsTest";
            int ingredientCount = 1;
            int servingCount = 4;
            string cuisine = "cuisineTest";
            string keywordTest1 = "keywordTest1";
            string keywordTest2 = "keywordTest2";
            List<string> keywords = new List<string> { keywordTest1, keywordTest2 };
            string name = "nameTest";
            string description = "descriptionTest";
            double quantity = 3;
            string unit = "unitTest";
            Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
            List<Ingredient> ingredientArrayTest = new List<Ingredient>(ingredientCount) { ingredientTest };
            Recipe recipeTest = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
            int recipeCount = 5;
            int recNum = 0;
            string recNumTest1 = $"{recipeCount / 2 + 1}";
            string recNumTest2 = $"{recipeCount + 1}";
            string recNumTest3 = "string";
            for (int i = 0; i < recipeCount; i++)
                recipeBookTest.Add(recipeTest);
            using (StringReader reader = new StringReader(recNumTest1))
            {
                Console.SetIn(reader);
                Program.TryReadRecNum(recipeBookTest, ref recNum, true);
                Assert.AreEqual(int.Parse(recNumTest1), recNum);
                Console.SetIn(Console.In);
            }
            recNum = 0;
            using (StringReader reader = new StringReader(recNumTest2))
            {
                Console.SetIn(reader);
                Program.TryReadRecNum(recipeBookTest, ref recNum, true);
                Assert.AreEqual(int.Parse(recNumTest2), recNum);
                Console.SetIn(Console.In);
            }
            recNum = 0;
            using (StringReader reader = new StringReader(recNumTest3))
            {
                Console.SetIn(reader);
                Program.TryReadRecNum(recipeBookTest, ref recNum, true);
                Assert.AreEqual(recNum, recNum);
                Console.SetIn(Console.In);
            }
        }

        [TestMethod()]
        public void TryUpdateServingCountTest()
        {
            string bookTitle = "bookTitleTest";
            int capacity = 2;
            RecipeBook recipeBookTest = new RecipeBook(bookTitle, capacity);
            string title = "titleTest";
            string instructions = "instructionsTest";
            int ingredientCount = 1;
            int servingCount = 4;
            string cuisine = "cuisineTest";
            string keywordTest1 = "keywordTest1";
            string keywordTest2 = "keywordTest2";
            List<string> keywords = new List<string> { keywordTest1, keywordTest2 };
            string name = "nameTest";
            string description = "descriptionTest";
            double quantity = 3;
            string unit = "unitTest";
            Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
            List<Ingredient> ingredientArrayTest = new List<Ingredient>(ingredientCount) { ingredientTest };
            Recipe recipeTest = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
            recipeBookTest.Add(recipeTest);
            int editNum = 1;
            string editNumTest1 = $"3";
            string editNumTest2 = $"-3";
            string editNumTest3 = "string";
            using (StringReader reader = new StringReader(editNumTest1))
            {
                Console.SetIn(reader);
                Program.TryUpdateServingCount(recipeBookTest, ref editNum, true);
                Assert.AreEqual(int.Parse(editNumTest1), recipeBookTest.RecipeList[editNum - 1].ServingCount);
                Console.SetIn(Console.In);
            }
            recipeBookTest.RecipeList[editNum - 1].ServingCount = servingCount;
            using (StringReader reader = new StringReader(editNumTest2))
            {
                Console.SetIn(reader);
                Program.TryUpdateServingCount(recipeBookTest, ref editNum, true);
                Assert.AreEqual(0, recipeBookTest.RecipeList[editNum - 1].ServingCount);
                Console.SetIn(Console.In);
            }
            recipeBookTest.RecipeList[editNum - 1].ServingCount = servingCount;
            using (StringReader reader = new StringReader(editNumTest3))
            {
                Console.SetIn(reader);
                Program.TryUpdateServingCount(recipeBookTest, ref editNum, true);
                Assert.AreEqual(servingCount, recipeBookTest.RecipeList[editNum - 1].ServingCount);
                Console.SetIn(Console.In);
            }
        }

        [TestMethod()]
        public void GetIngredientTest()
        {
            ConsoleKeyInfo cki;
            string title = "titleTest";
            string instructions = "instructionsTest";
            int ingredientCount = 1;
            int servingCount = 4;
            string cuisine = "cuisineTest";
            string keywordTest1 = "keywordTest1";
            string keywordTest2 = "keywordTest2";
            List<string> keywords = new List<string> { keywordTest1, keywordTest2 };
            //string ckiString = ConsoleKey.A.ToString();
            string name = "nameTest";
            string description = "descriptionTest";
            string quantity = "3";
            string unit = "unitTest";
            string input = $"{name}\n{description}\n{quantity}\n{unit}";
            Ingredient ingredientTest = new Ingredient("nothing", "nothing", 0, "nothing");
            List<Ingredient> ingredientArrayTest = new List<Ingredient>(ingredientCount) { ingredientTest };
            Recipe recipeTest = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
            using (StringReader reader = new StringReader(input))
            {
                Console.SetIn(reader);
                cki = new ConsoleKeyInfo();
                Program.GetIngredient(recipeTest, ingredientTest, cki, ingredientCount, true);
                Assert.AreEqual(name, recipeTest.IngredientsList[1].Name);
                Assert.AreEqual(description, recipeTest.IngredientsList[1].Description);
                Assert.AreEqual(int.Parse(quantity), recipeTest.IngredientsList[1].Quantity);
                Assert.AreEqual(unit, recipeTest.IngredientsList[1].Unit);
                Console.SetIn(Console.In);
            }
        }

        [TestMethod()]
        public void GetRecipeTest()
        {
            string bookTitle = "bookTitleTest";
            int capacity = 2;
            RecipeBook recipeBookTest = new RecipeBook(bookTitle, capacity);
            string title = "titleTest";
            string instructions = "instructionsTest";
            int ingredientCount = 1;
            int servingCount = 4;
            string cuisine = "cuisineTest";
            string keywordTest1 = "keywordTest1";
            string keywordTest2 = "keywordTest2";
            List<string> keywords = new List<string> { keywordTest1, keywordTest2 };
            string input = $"{title}\n{cuisine}\n{keywordTest1} {keywordTest2}\n{instructions}";
            string name = "nameTest";
            string description = "descriptionTest";
            double quantity = 3;
            string unit = "unitTest";
            Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
            List<Ingredient> ingredientArrayTest = new List<Ingredient>(ingredientCount) { ingredientTest };
            Recipe recipeTest = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
            recipeBookTest.Add(recipeTest);
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            using(StringReader reader = new StringReader(input))
            {
                Console.SetIn(reader);
                Program.GetRecipe(recipeBookTest, recipeTest, ingredientTest, ingredientCount, servingCount, cki, true);
                Assert.AreEqual(title, recipeTest.Title);
                Assert.AreEqual(cuisine, recipeTest.Cuisine);
                Assert.AreEqual(instructions, recipeTest.Instructions);
                CollectionAssert.AreEqual(keywords, recipeTest.Keywords);
                Console.SetIn(Console.In);
            }
        }
    }
}