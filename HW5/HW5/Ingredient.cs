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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        private double quantity;
        /// <summary>
        /// ایجاد شئ مشخصات یکی از مواد اولیه دستور غذا
        /// </summary>
        /// <param name="name">نام</param>
        /// <param name="description">توضیح</param>
        /// <param name="quantity">مقدار</param>
        /// <param name="unit">واحد مقدار</param>
        public Ingredient(string name, string description, double quantity, string unit)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Unit = unit;
        }

        /// <summary>
        /// ایجاد شئ مشخصات یکی از مواد اولیه دستور غذا
        /// </summary>
        public Ingredient()
        {

        }

        /// <summary>
        /// write ingredient specifications on file
        /// </summary>
        /// <param name="writer"></param>
        public void Serialize(StreamWriter writer)
        {
            writer.WriteLine(Name);
            writer.WriteLine(Description);
            writer.WriteLine(Quantity);
            writer.WriteLine(Unit);
        }

        /// <summary>
        /// read ingredient specifications from a file
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Ingredient Deserialize(StreamReader reader)
        {
            string name = reader.ReadLine();
            string des = reader.ReadLine();
            double quantity = double.Parse(reader.ReadLine());
            string unit = reader.ReadLine();
            Ingredient ing = new Ingredient(name, des, quantity, unit);
            return ing;
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
        /// تبدیل به متن
        /// </summary>
        /// <returns>متن معادل برای این ماده اولیه - قابل استفاده برای چاپ در خروجی</returns>
        public override string ToString()
        {
            return $"{Name}: {Quantity} {Unit} - {Description}";
        }
    }
}
