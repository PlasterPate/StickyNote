using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// کتابچه دستور غذا
    /// </summary>
    public class RecipeBook
    {
        private string title;
        private int capacity;
        private Recipe[] recipeList;
        /// <summary>
        /// ایجاد شیء کتابچه دستور غذا
        /// </summary>
        /// <param name="title">عنوان کتابچه غذا</param>
        /// <param name="capacity">ظرفیت کتابچه</param>
        public RecipeBook(string title, int capacity)
        {
            this.title = title;
            this.capacity = capacity;
            recipeList = new Recipe[Capacity];
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add(Recipe recipe)
        {
            for (int i = 0; i < recipeList.Length; i++)
            {
                if (recipeList[i] == null)
                {
                    recipeList[i] = recipe;
                    return true;
                }
            }
            return false;

        }


        /// <summary>
        /// حذف دستور پختs
        /// </summary>
        /// <param name="recipeTitle">عنوان دستور پخت</param>
        /// <returns>آیا حذف دستور پخت درست انجام شد؟</returns>
        public bool Remove(string recipeTitle)
        {
            //Console.Clear();
            for (int i = 0; i < recipeList.Length && recipeList[i] != null; i++)
            {
                if (recipeList[i].Title == recipeTitle)
                {
                    for (int j = i; j < recipeList.Length - 1; j++)
                    {
                        recipeList[j] = recipeList[j + 1];
                    }
                    recipeList[recipeList.Length - 1] = null;
                    Console.WriteLine("Recipe Deleted Successfully");
                    return true;
                }
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
            for (int i = 0; i < recipeList.Length && recipeList[i] != null; i++)
            {
                if (recipeList[i].Title == title)
                    return recipeList[i];
            }
            Console.WriteLine("No Recipes Found!");
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public Recipe[] LookupByKeyword(string keyword)
        {
            Recipe[] keywordResult = new Recipe[recipeList.Length];
            int counter = 0;
            for (int i = 0; i < recipeList.Length && recipeList[i] != null; i++)
            {
                foreach (string _keyword in recipeList[i].Keywords)
                {
                    if (_keyword == keyword)
                    {
                        keywordResult[counter] = recipeList[i];
                        counter++;
                    }
                }
            }
            if (counter > 0)
                return keywordResult;
            Console.WriteLine("No Recipes Found!");
            return null;

        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public Recipe[] LookupByCuisine(string cuisine)
        {
            Recipe[] cuisineResult = new Recipe[recipeList.Length];
            int counter = 0;
            for (int i = 0; i < recipeList.Length && recipeList[i] != null; i++)
            {
                if (recipeList[i].Cuisine == cuisine)
                {
                    cuisineResult[counter] = recipeList[i];
                    counter++;
                }
            }
            if (counter > 0)
                return cuisineResult;
            Console.WriteLine("No Recipes Found!");
            return null;
        }

        public Recipe[] RecipeList
        {
            get
            {
                return recipeList;
            }
            set
            {
                recipeList = value;
            }
        }
        /// <summary>
        /// show a summary of a recipe's specifications
        /// </summary>
        /// <param name="recipe">recipe object</param>
        /// <returns>specifications of the recipe</returns>
        public string SearchResult(Recipe recipe)
        {
            return $"\nTitle: {recipe.Title}\n" +
                $"Ingredients: {recipe.IngredientsList()}\n" +
                $"Serving count: {recipe.ServingCount}\n" +
                $"Cuisine: {recipe.Cuisine}\n" +
                $"Instructions: {recipe.Instructions}";
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
