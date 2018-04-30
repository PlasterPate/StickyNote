using System;
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
        public static string RecipeFilePath = @"recipes.txt";
        public string Title { get; set; }
        public string Instructions { get; set; }
        private int ingredientCount;
        private int servingCount;
        public string Cuisine { get; set; }
        public List<string> Keywords { get; set; }
        public List<Ingredient> IngredientsList { get; set; }
        /// <summary>
        /// ایجاد دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredients">لیست مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, List<Ingredient> ingredients, int servingCount, string cuisine, List<string> keywords)
        {
            Title = title;
            Instructions = instructions;
            IngredientsList = new List<Ingredient>();
            IngredientsList.AddRange(ingredients);
            this.servingCount = servingCount;
            Cuisine = cuisine;
            Keywords = new List<string>(keywords);
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
        public Recipe(string title, string instructions, int ingredientCount, int servingCount, string cuisine, List<string> keywords)
        {
            Title = title;
            Instructions = instructions;
            this.ingredientCount = ingredientCount;
            IngredientsList = new List<Ingredient>();
            this.servingCount = servingCount;
            Cuisine = cuisine;
            Keywords = new List<string>(keywords);
        }

        /// <summary>
        /// ایجاد شئ دستور پخت جدید
        /// </summary>
        public Recipe()
        {
            IngredientsList = new List<Ingredient>();
            Keywords = new List<string>();
        }

        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient(Ingredient ingredient)
        {
            IngredientsList.Add(ingredient);
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
                IngredientsList.Remove(LookupByName(name));
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
            for (int i = 0; i < IngredientsList.Count; i++)
            {
                IngredientsList[i].Quantity *= newServingCount / ServingCount;
            }
            ServingCount = newServingCount;
        }

        /// <summary>
        /// lists ingredients in a line
        /// </summary>
        /// <returns>joined titles in a string</returns>
        public string IngredientsJoin()
        {
            List<string> ingredientsNames = new List<string>(IngredientsList.Count);
            for (int i = 0; i < IngredientsList.Count && IngredientsList[i] != null ; i++)
            {
                ingredientsNames.Add(IngredientsList[i].Name);
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
                $"ingredients: {IngredientsJoin()}\n" +
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
            writer.WriteLine(IngredientsList.Count);
            foreach(Ingredient ing in IngredientsList)
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
            string title ;
            if ((title = reader.ReadLine()) == null)
                return null;
            string inst = reader.ReadLine();
            int ingCount = int.Parse(reader.ReadLine());
            List<Ingredient> ings = new List<Ingredient>(ingCount);
            
                for(int i = 0; i < ingCount; i++)
                {
                    ings.Add(Ingredient.Deserialize(reader));
                }
            int servCount = int.Parse(reader.ReadLine());
            string cuis = reader.ReadLine();
            List<string> keywords = new List<string>();
            keywords.AddRange(reader.ReadLine().Split());
            
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
            for(int i = 0; i< IngredientsList.Count && IngredientsList[i] != null; i++)
            {
                if (IngredientsList[i].Name == name)
                    return IngredientsList[i];
            }
            return null;
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
    }
}
