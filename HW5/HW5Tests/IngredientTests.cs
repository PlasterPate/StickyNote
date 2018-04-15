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
    public class IngredientTests
    {
        static string name = "nameTest";
        static string description = "descriptionTest";
        static double quantity = 3;
        static string unit = "unitTest";
        static Ingredient ingredientTest = new Ingredient(name, description, quantity, unit);
        [TestMethod()]
        public void IngredientTest()
        {
            Assert.AreEqual(name, ingredientTest.Name);
            Assert.AreEqual(description, ingredientTest.Description);
            Assert.AreEqual(quantity, ingredientTest.Quantity);
            Assert.AreEqual(unit, ingredientTest.Unit);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string expectedResult = $"{name}: {quantity} {unit} - {description}";
            Assert.AreEqual(expectedResult, ingredientTest.ToString());
        }

        [TestMethod()]
        public void SerializeAndDeserilalizeTest()
        {
            string ingFilePath = @"ingredientsTest.txt";
            Ingredient ingDeserialized;
            using(StreamWriter writer = new StreamWriter(ingFilePath))
            {
                ingredientTest.Serialize(writer);
            }
            using(StreamReader reader = new StreamReader(ingFilePath))
            {
                ingDeserialized = Ingredient.Deserialize(reader);
            }
            Assert.AreEqual(name, ingDeserialized.Name);
            Assert.AreEqual(description, ingDeserialized.Description);
            Assert.AreEqual(quantity, ingDeserialized.Quantity);
            Assert.AreEqual(unit, ingDeserialized.Unit);
        }
    }
}