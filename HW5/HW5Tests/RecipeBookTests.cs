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
    public class RecipeBookTests
    {
        static string bookTitle = "bookTitleTest";
        static int capacity = 2;
        static RecipeBook recipeBookTest = new RecipeBook(bookTitle, capacity);
        static string title = "titleTest";
        static string instructions = "instructionsTest";
        const int ingredientCount = 1;
        static int servingCount = 4;
        static string cuisine = "cuisineTest";
        static string keywordTest1 = "keywordTest1";
        static string keywordTest2 = "keywordTest2";
        static List<string> keywords = new List<string> { keywordTest1, keywordTest2 };
        static string name = "nameTest";
        static string description = "descriptionTest";
        static double quantity = 3;
        static string unit = "unitTest";
        static Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
        static List<Ingredient> ingredientArrayTest = new List<Ingredient>(ingredientCount) { ingredientTest };
        static Recipe recipeTest = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
        static List<Recipe> searchArray = new List<Recipe>(capacity);
        [TestMethod()]
        public void RecipeBookTest()
        {
            Assert.AreEqual(bookTitle, recipeBookTest.Title);
            Assert.AreEqual(capacity, recipeBookTest.Capacity);
            recipeBookTest.Capacity = -1;
            Assert.AreEqual(0, recipeBookTest.Capacity);
            recipeBookTest.Capacity = 1;
            Assert.AreEqual(1, recipeBookTest.Capacity);
        }

        [TestMethod()]
        public void AddTest()
        {
            for (int i = 0; i < capacity; i++)
                Assert.IsTrue(recipeBookTest.Add(recipeTest));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            recipeBookTest.Add(recipeTest);
            for (int i = 0; i < capacity; i++)
                Assert.IsTrue(recipeBookTest.Remove(recipeTest.Title));
            Assert.IsFalse(recipeBookTest.Remove("another title"));
        }

        [TestMethod()]
        public void LookupByTitleTest()
        {
            while (recipeBookTest.RecipeList.Count != 0)
                recipeBookTest.Remove(recipeTest.Title);
            recipeBookTest.Add(recipeTest);
            Assert.AreEqual(recipeTest, recipeBookTest.LookupByTitle(title));
            Assert.IsNull(recipeBookTest.LookupByTitle("another title"));
        }

        [TestMethod()]
        public void LookupByKeywordTest()
        {
            while (recipeBookTest.RecipeList.Count != 0)
                recipeBookTest.Remove(recipeTest.Title);
            while (searchArray.Count != 0)
                searchArray.Remove(recipeTest);
            for (int i = 0; i < capacity; i++)
            {
                recipeBookTest.Add(recipeTest);
                searchArray.Add(recipeTest);
            }
            CollectionAssert.AreEqual(searchArray.ToArray(), recipeBookTest.LookupByKeyword(keywordTest1).ToArray());
            Assert.IsNull(recipeBookTest.LookupByKeyword("another keyword"));
        }

        [TestMethod()]
        public void LookupByCuisineTest()
        {
            while (recipeBookTest.RecipeList.Count != 0)
                recipeBookTest.Remove(recipeTest.Title);
            for (int i = 0; i < capacity; i++)
            {
                recipeBookTest.Add(recipeTest);
                searchArray.Add(recipeTest);
            }
            Assert.IsNotNull(recipeBookTest.LookupByCuisine(cuisine));
            Assert.IsNull(recipeBookTest.LookupByCuisine("another cuisine"));
        }

        [TestMethod()]
        public void SearchResultTest()
        {

            string expectedResult = $"\nTitle: {title}\n" +
                $"Ingredients: {recipeTest.IngredientsJoin()}\n" +
                $"Serving count: {servingCount}\n" +
                $"Cuisine: {cuisine}\n" +
                $"Instructions: {instructions}";
            Assert.AreEqual(expectedResult, recipeBookTest.SearchResult(recipeTest));
        }

        [TestMethod()]
        public void SaveTest()
        {
            string recFilePath = @"recipesTest.txt";
            recipeBookTest.Save(recFilePath);
            Assert.IsTrue(File.Exists(recFilePath));
        }

        [TestMethod()]
        public void LoadTest()
        {
            string recFilePath = @"recipesTest.txt";
            recipeBookTest.Save(recFilePath);
            Assert.IsTrue(recipeBookTest.Load(recFilePath));
            Assert.IsFalse(recipeBookTest.Load("another file path"));
        }

        [TestMethod()]
        public void ListShowTest()
        {
            string filePath = "listShow.txt";
            while (recipeBookTest.RecipeList.Count > 0)
                recipeBookTest.Remove(recipeTest.Title);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Console.SetOut(writer);
                recipeBookTest.ListShow();
                Console.SetOut(Console.Out);
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.SetIn(reader);
                Assert.AreEqual("Empty!", Console.ReadLine());
                Console.SetIn(Console.In);

            }
            recipeBookTest.Add(recipeTest);
            recipeBookTest.Add(recipeTest);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Console.SetOut(writer);
                recipeBookTest.ListShow();
                Console.SetOut(Console.Out);
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.SetIn(reader);
                for (int i = 0; i < recipeBookTest.RecipeList.Count && recipeBookTest.RecipeList[i] != null; i++)
                {
                    Assert.AreEqual($"{i + 1}.{recipeBookTest.RecipeList[i].Title}", Console.ReadLine());
                }
                //Assert.AreEqual("\n", Console.ReadLine());
                Console.SetIn(Console.In);

            }
        }
    }
}