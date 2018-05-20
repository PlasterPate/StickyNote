using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"..\..\Titanic.csv")
                .Skip(1)
                .Select(line => new TitanicData(line));

            Console.WriteLine($"Paid the highest fare: {data.GetMostExpensiveFare().Name}");

            // If necessary, you can use more than one extension method to calculate these answers.
            Console.WriteLine($"Oldest person's name: {data.GetEldestPerson().Name}");
            Console.WriteLine($"Oldest female's name: {data.GetEldestFemale().Name}");
            Console.WriteLine($"Total passengers: {data.GetTotalPassengers()}");
            Console.WriteLine($"Total Female passengers: {data.GetTotalFemales()}");
            Console.WriteLine($"Total number of survivors: {data.GetTotalSurvivors()}");
            Console.WriteLine($"Percent of passengers who survived: {data.GetSurvivedPercent()}");
            Console.WriteLine($"Number of female Survivors: {data.GetTotalFemaleSurvivors()}");
            Console.WriteLine($"Percent of females who survived: {data.GetFemalesSurvivedPercent()}");
            Console.WriteLine($"Percent of survivors who were female: {data.GetSurvivedFemalesPercent()}");
            Console.WriteLine($"Percent of kids under 10 who survived: {data.GetKidsUnderTenSurvivedPercent()}");
            Console.WriteLine($"Port of boarding with most survivors: {data.GetPortOfMostSurvivors().BoardingPort}");
            Console.WriteLine($"Port of boarding with most survivors percent: {data.GetPortOfMostSurvivorsPercent()}");
            Console.WriteLine($"The age group (age/10) with most passengers: {data.GetMostAgeGroupPassengers()}");
            Console.WriteLine($"The age group (age/10) with most survivors: {data.GetMostAgeGroupSurvivors()}");
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// parse string to int if it wasn't null or empty
        /// else make it null
        /// </summary>
        /// <param name="str">a nullable int or null</param>
        /// <returns></returns>
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;
        /// <summary>
        /// parse string to double if it wasn't null or empty
        /// else make it null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Nullable<double> ParseDoubleOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? double.Parse(str) as Nullable<double> : null;

        /// <summary>
        /// find the person who paid the most
        /// </summary>
        /// <param name="data">person who paid the most</param>
        /// <returns></returns>
        public static TitanicData GetMostExpensiveFare(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Fare).First();

        /// <summary>
        /// find eldest passenger of ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns>eldest person</returns>
        public static TitanicData GetEldestPerson(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Age).First();

        /// <summary>
        /// find eldest female passenger of ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns>eldest female</returns>
        public static TitanicData GetEldestFemale(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale).OrderByDescending(x => x.Age).First();

        /// <summary>
        /// find total number of passengers on the ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns>integer of total passengers</returns>
        public static int GetTotalPassengers(this IEnumerable<TitanicData> data)
            => data.Count();

        /// <summary>
        /// find total number of female passengers on the ship
        /// </summary>
        /// <param name="data"></param>
        /// <returns>integer of total females</returns>
        public static int GetTotalFemales(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale).Count();

        /// <summary>
        /// find total number of people who survived
        /// </summary>
        /// <param name="data"></param>
        /// <returns>integer of total survived people</returns>
        public static int GetTotalSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Survived).Count();

        /// <summary>
        /// find percent of survived people
        /// </summary>
        /// <param name="data"></param>
        /// <returns>double of survived people percent</returns>
        public static double GetSurvivedPercent(this IEnumerable<TitanicData> data)
           => (double)data.GetTotalSurvivors() / data.GetTotalPassengers() * 100;

        /// <summary>
        /// find number of females who were survived
        /// </summary>
        /// <param name="data"></param>
        /// <returns>integer of female survivors</returns>
        public static int GetTotalFemaleSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale && x.Survived).Count();

        /// <summary>
        /// find percent of females who were survived
        /// </summary>
        /// <param name="data"></param>
        /// <returns>double of female survivors percent</returns>
        public static double GetFemalesSurvivedPercent(this IEnumerable<TitanicData> data)
           => (double)data.GetTotalFemaleSurvivors() / data.GetTotalFemales() * 100;

        /// <summary>
        /// find percent of survivors who were female
        /// </summary>
        /// <param name="data"></param>
        /// <returns>double of survived females percent</returns>
        public static double GetSurvivedFemalesPercent(this IEnumerable<TitanicData> data)
           => (double)data.GetTotalFemaleSurvivors() / data.GetTotalSurvivors() * 100;

        /// <summary>
        /// find percent of kids who were under 10 years old
        /// </summary>
        /// <param name="data"></param>
        /// <returns>double of under 10 kids percent</returns>
        public static double GetKidsUnderTenSurvivedPercent(this IEnumerable<TitanicData> data)
            => (double)data.Where(x => x.Age < 10 && x.Survived).Count() / data.Where(x => x.Age < 10).Count() * 100;

        /// <summary>
        /// find the port which had the most survivors
        /// </summary>
        /// <param name="data"></param>
        /// <returns>port with most survivors</returns>
        public static TitanicData GetPortOfMostSurvivors(this IEnumerable<TitanicData> data)
           => data.Where(x => x.Survived).GroupBy(x => x.BoardingPort).OrderByDescending(x => x.Count()).First().First();

        /// <summary>
        /// find the port which had the most survivors percent
        /// </summary>
        /// <param name="data"></param>
        /// <returns>string of port name</returns>
        public static string GetPortOfMostSurvivorsPercent(this IEnumerable<TitanicData> data)
        
            => data.Where(x => x.BoardingPort != "").GroupBy(x => x.BoardingPort).Select(x => new
               {
                   percent = (double)x.Where(p => p.Survived ).Count() / x.Count(),
                   port = x.Key.ToString()
               }).OrderByDescending(x => x.percent).First().port;

        /// <summary>
        /// find the age group which most passengers were from it
        /// </summary>
        /// <param name="data">string of age group</param>
        /// <returns></returns>
        public static string GetMostAgeGroupPassengers(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Age != null).GroupBy(x => (int)x.Age / 10).OrderByDescending(x => x.Count()).Select(x => new
            {
                AgeGroup = $"{x.Key * 10}/{x.Key * 10 + 9}"
            }).First().AgeGroup;

        /// <summary>
        /// find the age group whith most survivors
        /// </summary>
        /// <param name="data"></param>
        /// <returns>string of age group</returns>
        public static string GetMostAgeGroupSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Age != null && x.Survived).GroupBy(x => (int)x.Age / 10).OrderByDescending(x => x.Count()).Select(x => new
            {
                AgeGroup = $"{x.Key * 10}/{x.Key * 10 + 9}"
            }).First().AgeGroup;
    }

    public class TitanicData
    {
        public TitanicData(string line)
        {
            var toks = line.Split(',');
            PassengerId = toks[0];
            Survived = toks[1] == "1";
            PClass = toks[2];
            Name = toks[3];
            IsFemale = toks[4] == "female";
            Age = toks[5].ParseDoubleOrNull();
            SibilingsOnBoard = toks[6].ParseIntOrNull();
            ParentsOnBoard = toks[7].ParseIntOrNull();
            Ticket = toks[8];
            Fare = double.Parse(toks[9]);
            Cabin = toks[10];
            BoardingPort = toks[11];
        }
        public string PassengerId;
        public bool Survived;
        public string PClass;
        public string Name;
        public bool IsFemale;
        public Nullable<double> Age;
        public Nullable<int> SibilingsOnBoard;
        public Nullable<int> ParentsOnBoard;
        public string Ticket;
        public double Fare;
        public string Cabin;
        public string BoardingPort;
    }
}
