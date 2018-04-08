using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// یک جزء از ترکیبات دستور غذا
    /// </summary>
    public class Ingredient
    {
        private static string ingFilePath = @"ingredients.txt";
        private string name;
        private string description;
        private double quantity;
        private string unit;
        /// <summary>
        /// ایجاد شئ مشخصات یکی از مواد اولیه دستور غذا
        /// </summary>
        /// <param name="name">نام</param>
        /// <param name="description">توضیح</param>
        /// <param name="quantity">مقدار</param>
        /// <param name="unit">واحد مقدار</param>
        public Ingredient(string name, string description, double quantity, string unit)
        {
            this.name = name;
            this.description = description;
            this.quantity = quantity;
            this.unit = unit;
            // بر عهده دانشجو
        }

        public void Serialize(StreamWriter writer)
        {
            writer.WriteLine(Name);
            writer.WriteLine(Description);
            writer.WriteLine(Quantity);
            writer.WriteLine(Unit);
        }

        public static Ingredient Deserialize(StreamReader reader)
        {
            string name = reader.ReadLine();
            string des = reader.ReadLine();
            double quantity = double.Parse(reader.ReadLine());
            string unit = reader.ReadLine();
            Ingredient ing = new Ingredient(name, des, quantity, unit);
            return ing;
        }

        public static string IngFilePath
        {
            get
            {
                return ingFilePath;
            }
            set
            {
                return;
            }
        }

        /// <summary>
        /// نام ماده اولیه
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// توضیح: از کجا پیدا کنیم یا اگر نداشتیم جایگزین چه چیزی استفاده کنیم
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// مقدار
        /// </summary>
        public double Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value > 0)
                    quantity = value;
                else
                    quantity = 0;
            }
        }

        /// <summary>
        /// واحد مقدار: مثلا گرم، کیلوگرم، عدد
        /// </summary>
        public string Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
            }
        }

        /// <summary>
        /// تبدیل به متن
        /// </summary>
        /// <returns>متن معادل برای این ماده اولیه - قابل استفاده برای چاپ در خروجی</returns>
        public override string ToString()
        {
            return $"{Name}:\t{Quantity} {Unit} - {Description}";
        }
    }
}
