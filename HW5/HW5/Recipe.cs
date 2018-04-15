﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// دستور پخت 
    /// </summary>
    public class Recipe
    {
        private static string recipeFilePath = @"recipes.txt";
        private string title;
        private string instructions;
        private int ingredientCount;
        private int servingCount;
        private string cuisine;
        private string[] keywords;
        /// <summary>
        /// ایجاد دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredients">لیست مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, Ingredient[] ingredients, int servingCount, string cuisine, string[] keywords)
        {
            this.title = title;
            this.instructions = instructions;
            Ingredients = new List<Ingredient>();
            Ingredients.AddRange(ingredients);
            this.servingCount = servingCount;
            this.cuisine = cuisine;
            this.keywords = new string[keywords.Length];
            for (int i = 0; i < keywords.Length && keywords[i] != null; i++)
            {
                this.keywords[i] = keywords[i];
            }

        }

        /// <summary>
        /// ایجاد شئ دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredientCount">تعداد مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, int ingredientCount, int servingCount, string cuisine, string[] keywords)
        {
            this.title = title;
            this.instructions = instructions;
            this.ingredientCount = ingredientCount;
            Ingredients = new List<Ingredient>();
            this.servingCount = servingCount;
            this.cuisine = cuisine;
            this.keywords = new string[keywords.Length];
            for (int i = 0; i < keywords.Length; i++)
            {
                this.keywords[i] = keywords[i];
            }
        }

        /// <summary>
        /// ایجاد شئ دستور پخت جدید
        /// </summary>
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Keywords = new string[0];
        }

        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            return true;
        }

        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            if (LookupByName(name) != null)
            {
                Ingredients.Remove(LookupByName(name));
                return true;
            }
            return false;
        }

        /// <summary>
        /// بروز کردن تعداد افرادی که این دستور غذا برای آن تعداد مناسب است
        /// مقادیر مواد اولیه به نسبت لازم اضافه میشود
        /// </summary>
        /// <param name="newServingCount">تعداد افراد جدید</param>
        public void UpdateServingCount(int newServingCount)
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity *= newServingCount / ServingCount;
            }
            ServingCount = newServingCount;
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
        private List<Ingredient> ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public List<Ingredient> Ingredients
        {
            get
            {
                return ingredients;
            }
            private set
            {
                ingredients = value;
            }
        }

        /// <summary>
        /// lists ingredients in a line
        /// </summary>
        /// <returns>joined titles in a string</returns>
        public string IngredientsList()
        {
            string[] ingredientsNames = new string[Ingredients.Count];
            for (int i = 0; i < Ingredients.Count && Ingredients[i] != null ; i++)
            {
                ingredientsNames[i] = Ingredients[i].Name;
            }
            return String.Join(", ", ingredientsNames);
        }

        /// <summary>
        /// a summary of recipe specifications 
        /// </summary>
        /// <returns>string of informations</returns>
        public override string ToString()
        {
            return $"{Title}\n" +
                $"cuisine: {Cuisine}\n" +
                $"ingredients: {IngredientsList()}\n" +
                $"{Instructions}";
        }

        /// <summary>
        /// write recipe specifications on file
        /// </summary>
        /// <param name="writer"></param>
        public void Serialize(StreamWriter writer)
        {
            writer.WriteLine(Title);
            writer.WriteLine(Instructions);
            writer.WriteLine(Ingredients.Count);
            
                foreach(Ingredient ing in Ingredients)
                {
                    if (ing != null)
                        ing.Serialize(writer);
                }
            writer.WriteLine(ServingCount);
            writer.WriteLine(Cuisine);
            writer.WriteLine(String.Join(" ", Keywords));
        }

        /// <summary>
        /// read recipe specifications from a file
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Recipe Deserialize(StreamReader reader)
        {
            string title = reader.ReadLine();
            if (title == null)
                return null;
            string inst = reader.ReadLine();
            int ingCount = int.Parse(reader.ReadLine());
            Ingredient[] ings = new Ingredient[ingCount];
            
                for(int i = 0; i < ingCount; i++)
                {
                    ings[i] = Ingredient.Deserialize(reader);
                }
            int servCount = int.Parse(reader.ReadLine());
            string cuis = reader.ReadLine();
            string[] keywords = reader.ReadLine().Split();
            Recipe rec = new Recipe(title, inst, ings, servCount, cuis, keywords);
            return rec;
        }

        /// <summary>
        /// finding ingredient by name
        /// </summary>
        /// <param name="name">ingredient's name</param>
        /// <returns>ingredient object</returns>
        public Ingredient LookupByName(string name)
        {
            for(int i = 0; i< Ingredients.Count && Ingredients[i] != null; i++)
            {
                if (Ingredients[i].Name == name)
                    return Ingredients[i];
            }
            return null;
        }

        public static string RecipeFilePath
        {
            get
            {
                return recipeFilePath;
            }
            set
            {
                return;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Instructions
        {
            get
            {
                return instructions;
            }
            set
            {
                instructions = value;
            }
        }
        public int IngredientCount
        {
            get
            {
                return ingredientCount;
            }
            set
            {
                if (value > 0)
                    ingredientCount = value;
                else
                    ingredientCount = 0;
            }
        }
        public int ServingCount
        {
            get
            {
                return servingCount;
            }
            set
            {
                if (value > 0)
                    servingCount = value;
                else
                    servingCount = 0;
            }
        }

        public string Cuisine
        {
            get
            {
                return cuisine;
            }
            set
            {
                cuisine = value;
            }
        }
        public string[] Keywords
        {
            get
            {
                return keywords;
            }
            set
            {
                keywords = value;
            }
        }

    }
}
