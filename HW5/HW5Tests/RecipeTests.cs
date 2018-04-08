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
    public class RecipeTests
    {
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
        Recipe recipeTest1 = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
        Recipe recipeTest2 = new Recipe(title, instructions, ingredientCount, servingCount, cuisine, keywords);
        [TestMethod()]
        public void RecipeTest()
        {
            Assert.AreEqual(title, recipeTest1.Title);
            Assert.AreEqual(instructions, recipeTest1.Instructions);
            CollectionAssert.AreEqual(ingredientArrayTest, recipeTest1.Ingredients);
            Assert.AreEqual(servingCount, recipeTest1.ServingCount);
            Assert.AreEqual(cuisine, recipeTest1.Cuisine);
            CollectionAssert.AreEqual(keywords, recipeTest1.Keywords);
        }

        [TestMethod()]
        public void RecipeTest1()
        {
            Assert.AreEqual(title, recipeTest2.Title);
            Assert.AreEqual(instructions, recipeTest2.Instructions);
            Assert.AreEqual(ingredientCount, recipeTest2.IngredientCount);
            Assert.AreEqual(servingCount, recipeTest2.ServingCount);
            Assert.AreEqual(cuisine, recipeTest2.Cuisine);
            CollectionAssert.AreEqual(keywords, recipeTest2.Keywords);
        }

        [TestMethod()]
        public void AddIngredientTest()
        {
            Assert.IsFalse(recipeTest1.AddIngredient(ingredientTest));
            Assert.IsTrue(recipeTest2.AddIngredient(ingredientTest));
        }

        [TestMethod()]
        public void RemoveIngredientTest()
        {
            Assert.IsTrue(recipeTest1.RemoveIngredient(ingredientTest.Name));
            Assert.IsFalse(recipeTest1.RemoveIngredient(ingredientTest.Name));
            Assert.IsFalse(recipeTest1.RemoveIngredient("another name"));
        }

        [TestMethod()]
        public void UpdateServingCountTest()
        {
            int newServingCount = 6;
            double expectedResult = newServingCount / servingCount * quantity;
            recipeTest1.UpdateServingCount(newServingCount);
            foreach (Ingredient ing in ingredientArrayTest)
                Assert.AreEqual(expectedResult, ing.Quantity);
        }

        [TestMethod()]
        public void IngredientsListTest()
        {
            string[] ingNames = new string[ingredientCount];
            for (int i = 0; i < ingNames.Length; i++)
                ingNames[i] = ingredientArrayTest[i].Name;
            string expectedResult = String.Join(", ", ingNames);
            Assert.AreEqual(expectedResult, recipeTest1.IngredientsList());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string expectedResult = $"{title}\n" +
                $"cuisine: {cuisine}\n" +
                $"ingredients: {recipeTest1.IngredientsList()}\n" +
                $"{instructions}";
            Assert.AreEqual(expectedResult, recipeTest1.ToString());
        }

        [TestMethod()]
        public void SerializeAndDeserilalizeTest()
        {
            string recFilePath = @"recipesTest.txt";
            Recipe recDeserialized;
            using (StreamWriter writer = new StreamWriter(recFilePath))
            {
                recipeTest1.Serialize(writer);
            }
            using (StreamReader reader = new StreamReader(recFilePath))
            {
                recDeserialized = Recipe.Deserialize(reader);
            }
            Assert.AreEqual(title, recDeserialized.Title);
            Assert.AreEqual(instructions, recDeserialized.Instructions);
            Assert.AreEqual(ingredientArrayTest.Length, recDeserialized.Ingredients.Length);
            Assert.AreEqual(servingCount, recDeserialized.ServingCount);
            Assert.AreEqual(cuisine, recDeserialized.Cuisine);
            CollectionAssert.AreEqual(keywords, recDeserialized.Keywords);
        }
    }
}