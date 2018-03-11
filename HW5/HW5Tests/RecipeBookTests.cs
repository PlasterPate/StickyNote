using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static string[] keywords = { keywordTest1, keywordTest2 };
        static string name = "nameTest";
        static string description = "descriptionTest";
        static double quantity = 3;
        static string unit = "unitTest";
        static Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
        static Ingredient[] ingredientArrayTest = new Ingredient[ingredientCount] { ingredientTest };
        //ingredientArrayTest[0] = ingredientTest;
        static Recipe recipeTest = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
        static Recipe[] searchArray = new Recipe[capacity];
        [TestMethod()]
        public void RecipeBookTest()
        {
            Assert.AreEqual(bookTitle, recipeBookTest.Title);
            Assert.AreEqual(capacity, recipeBookTest.Capacity);
        }

        [TestMethod()]
        public void AddTest()
        {
            for (int i = 0; i < capacity; i++)
                Assert.IsTrue(recipeBookTest.Add(recipeTest));
            Assert.IsFalse(recipeBookTest.Add(recipeTest));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            for (int i = 0; i < capacity; i++)
                recipeBookTest.Add(recipeTest);
            //for (int i = 0; i < capacity; i++)
            Assert.IsTrue(recipeBookTest.Remove(recipeTest.Title));
            Assert.IsTrue(recipeBookTest.Remove(recipeTest.Title));
            Assert.IsFalse(recipeBookTest.Remove(recipeTest.Title));
        }

        [TestMethod()]
        public void LookupByTitleTest()
        {
            recipeBookTest.Add(recipeTest);
            Assert.AreEqual(recipeTest, recipeBookTest.LookupByTitle(title));
            Assert.IsNull(recipeBookTest.LookupByTitle("another title"));
        }

        [TestMethod()]
        public void LookupByKeywordTest()
        {
            for (int i = 0; i < capacity; i++)
            {
                recipeBookTest.Add(recipeTest);
                searchArray[i] = recipeTest;
            }
            CollectionAssert.AreEqual(searchArray, recipeBookTest.LookupByKeyword(keywordTest1));
            Assert.IsNull(recipeBookTest.LookupByKeyword("another keyword"));
        }

        [TestMethod()]
        public void LookupByCuisineTest()
        {
            for (int i = 0; i < capacity; i++)
            {
                recipeBookTest.Add(recipeTest);
                searchArray[i] = recipeTest;
            }
            CollectionAssert.AreEqual(searchArray, recipeBookTest.LookupByCuisine(cuisine));
            Assert.IsNull(recipeBookTest.LookupByCuisine("another cuisine"));
        }

        [TestMethod()]
        public void SearchResultTest()
        {

            string expectedResult = $"\nTitle: {title}\n" +
                $"Ingredients: {recipeTest.IngredientsList()}\n" +
                $"Serving count: {servingCount}\n" +
                $"Cuisine: {cuisine}\n" +
                $"Instructions: {instructions}";
            Assert.AreEqual(expectedResult, recipeBookTest.SearchResult(recipeTest));
        }
    }
}