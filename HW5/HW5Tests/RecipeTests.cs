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
        static List<string> keywords = new List<string> { keywordTest1, keywordTest2 };
        static string name = "nameTest";
        static string description = "descriptionTest";
        static double quantity = 3;
        static string unit = "unitTest";
        static Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
        static List<Ingredient> ingredientArrayTest = new List<Ingredient>(ingredientCount) { ingredientTest };
        Recipe recipeTest1 = new Recipe(title, instructions, ingredientArrayTest, servingCount, cuisine, keywords);
        Recipe recipeTest2 = new Recipe(title, instructions, ingredientCount, servingCount, cuisine, keywords);
        [TestMethod()]
        public void RecipeTest()
        {
            Assert.AreEqual(title, recipeTest1.Title);
            Assert.AreEqual(instructions, recipeTest1.Instructions);
            CollectionAssert.AreEqual(ingredientArrayTest, recipeTest1.IngredientsList);
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
            Assert.AreEqual(expectedResult, recipeTest1.IngredientsJoin());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string expectedResult = $"{title}\n" +
                $"cuisine: {cuisine}\n" +
                $"ingredients: {recipeTest1.IngredientsJoin()}\n" +
                $"{instructions}";
            Assert.AreEqual(expectedResult, recipeTest1.ToString());
        }

        [TestMethod()]
        public void LookupByNameTest()
        {
            recipeTest2.AddIngredient(ingredientTest);
            Assert.AreEqual(ingredientTest ,recipeTest2.LookupByName(name));
            Assert.IsNull(recipeTest2.LookupByName("another name"));
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
                Assert.IsNull(Recipe.Deserialize(reader));
            }
            Assert.AreEqual(recipeTest1.Title, recDeserialized.Title);
            Assert.AreEqual(recipeTest1.Cuisine, recDeserialized.Cuisine);
            Assert.AreEqual(recipeTest1.Instructions, recDeserialized.Instructions);
            Assert.AreEqual(recipeTest1.ServingCount, recDeserialized.ServingCount);
            Assert.AreEqual(recipeTest1.IngredientsList[0].Name, recDeserialized.IngredientsList[0].Name);
            Assert.AreEqual(recipeTest1.IngredientsList[0].Description, recDeserialized.IngredientsList[0].Description);
            Assert.AreEqual(recipeTest1.IngredientsList[0].Unit, recDeserialized.IngredientsList[0].Unit);
            Assert.AreEqual(recipeTest1.IngredientsList[0].Quantity, recDeserialized.IngredientsList[0].Quantity);
            CollectionAssert.AreEqual(recipeTest1.Keywords, recDeserialized.Keywords);

        }

        [TestMethod()]
        public void RecipeTest2()
        {
            Recipe recNullConstructor = new Recipe();
            Assert.IsNull(recNullConstructor.Title);
            Assert.IsNull(recNullConstructor.Instructions);
            Assert.IsNull(recNullConstructor.Cuisine);
            Assert.AreEqual(0, recNullConstructor.IngredientCount);
            Assert.AreEqual(0, recNullConstructor.ServingCount);
            Assert.AreEqual(0, recNullConstructor.Keywords.Count);
            Assert.AreEqual(0, recNullConstructor.IngredientsList.Count);
            recNullConstructor.IngredientCount = 1;
            Assert.AreEqual(1, recNullConstructor.IngredientCount);
            recNullConstructor.IngredientCount = -1;
            Assert.AreEqual(0, recNullConstructor.IngredientCount);
            recNullConstructor.ServingCount = -1;
            Assert.AreEqual(0, recNullConstructor.ServingCount);
        }
    }
}