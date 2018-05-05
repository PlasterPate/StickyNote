using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// کتابچه دستور غذا
    /// </summary>
    public class RecipeBook
    {
        public string Title { get; set; }
        private int capacity;
        public List<Recipe> RecipeList { get; set; }
        /// <summary>
        /// ایجاد شیء کتابچه دستور غذا
        /// </summary>
        /// <param name="title">عنوان کتابچه غذا</param>
        /// <param name="capacity">ظرفیت کتابچه</param>
        public RecipeBook(string title, int capacity)
        {
            Title = title;
            this.capacity = capacity;
            RecipeList = new List<Recipe>(Capacity);
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            RecipeList.Add(recipe);
            return true;
        }

        /// <summary>
        /// حذف دستور پخت
        /// </summary>
        /// <param name="recipeTitle">عنوان دستور پخت</param>
        /// <returns>آیا حذف دستور پخت درست انجام شد؟</returns>
        public bool Remove(string recipeTitle)
        {
            if (LookupByTitle(recipeTitle) != null)
            {
                RecipeList.Remove(LookupByTitle(recipeTitle));
                Console.WriteLine("Recipe Deleted Successfully");
                return true;
            }
            Console.WriteLine("No Recipes Found!");
            return false;
        }

        /// <summary>
        /// پیدا کردن دستور پخت با عنوان
        /// </summary>
        /// <param name="title">عنوان دستور پخت</param>
        /// <returns>شیء دستور پخت</returns>
        public Recipe LookupByTitle(string title)
        {
            for (int i = 0; i < RecipeList.Count && RecipeList[i] != null; i++)
            {
                if (RecipeList[i].Title == title)
                    return RecipeList[i];
            }
            Console.WriteLine("No Recipes Found!");
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public List<Recipe> LookupByKeyword(string keyword)
        {
            List<Recipe> keywordResult = new List<Recipe>();
            for (int i = 0; i < RecipeList.Count && RecipeList[i] != null; i++)
            {
                foreach (string _keyword in RecipeList[i].Keywords)
                {
                    if (_keyword == keyword)
                        keywordResult.Add(RecipeList[i]);
                }
            }
            if (keywordResult.Count != 0)
                return keywordResult;
            Console.WriteLine("No Recipes Found!");
            return null;

        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public List<Recipe> LookupByCuisine(string cuisine)
        {
            List<Recipe> cuisineResult = new List<Recipe>();
            for (int i = 0; i < RecipeList.Count && RecipeList[i] != null; i++)
            {
                if (RecipeList[i].Cuisine == cuisine)
                {
                    cuisineResult.Add(RecipeList[i]);
                }
            }
            if (cuisineResult.Count != 0)
                return cuisineResult;
            Console.WriteLine("No Recipes Found!");
            return null;
        }
        /// <summary>
        /// ذخیره لیست دستور پخت غذاها در فایل
        /// </summary>
        /// <param name="recipeFilePath">آدرس فایل</param>
        public void Save(string recipeFilePath)
        {
            if (recipeFilePath != string.Empty)
            {
                using (StreamWriter writer = new StreamWriter(recipeFilePath, false, Encoding.UTF8))
                {
                    writer.WriteLine(RecipeList.Count);
                    foreach (var r in RecipeList)
                    {
                        if (r != null)
                        {
                            r.Serialize(writer);
                        }
                    }
                }
                Console.WriteLine("\nChanges have been saved!\n");
            }
        }


        /// <summary>
        /// بارگزاری اطلاعات از فایل ذخیره شده
        /// </summary>
        /// <param name="recipeFilePath">آدرس فایل</param>
        /// <returns>آیا بارگزاری با موفقیت انجام شد؟</returns>
        public bool Load(string recipeFilePath)
        {
            if (!File.Exists(recipeFilePath) || new FileInfo(recipeFilePath).Length == 0)
            {
                Console.WriteLine("\nThere is nothing to load!\n");
                return false;
            }

            using (StreamReader reader = new StreamReader(recipeFilePath))
            {
                int recipeCount = int.Parse(reader.ReadLine());
                RecipeList = new List<Recipe>(recipeCount);

                for (int i = 0; i < recipeCount; i++)
                {
                    Recipe r = Recipe.Deserialize(reader);
                    this.RecipeList.Add(r);
                }
            }
            Console.WriteLine("\nRecipes loaded successfuly!\n");
            return true;
        }

        /// <summary>
        /// show a summary of a recipe's specifications
        /// </summary>
        /// <param name="recipe">recipe object</param>
        /// <returns>specifications of the recipe</returns>
        public string SearchResult(Recipe recipe)
        {
            return $"\nTitle: {recipe.Title}\n" +
                $"Ingredients: {recipe.IngredientsJoin()}\n" +
                $"Serving count: {recipe.ServingCount}\n" +
                $"Cuisine: {recipe.Cuisine}\n" +
                $"Instructions: {recipe.Instructions}";
        }

        public void ListShow()
        {
            for (int i = 0; i< RecipeList.Count && RecipeList[i] != null; i++)
            {
                Console.WriteLine($"{i + 1}.{RecipeList[i].Title}");
            }
            if (RecipeList.Count == 0)
                Console.WriteLine("Empty!");
            Console.WriteLine();
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value > 0)
                    capacity = value;
                else
                    capacity = 0;
            }
        }
    }
}
