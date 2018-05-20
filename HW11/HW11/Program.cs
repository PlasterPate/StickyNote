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
            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;
        public static Nullable<double> ParseDoubleOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? double.Parse(str) as Nullable<double> : null;

        public static TitanicData GetMostExpensiveFare(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Fare).First();

        public static TitanicData GetEldestPerson(this IEnumerable<TitanicData> data)
            => data.OrderByDescending(x => x.Age).First();

        public static TitanicData GetEldestFemale(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale).OrderByDescending(x => x.Age).First();

        public static int GetTotalPassengers(this IEnumerable<TitanicData> data)
            => data.Count();

        public static int GetTotalFemales(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale).Count();

        public static int GetTotalSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Survived).Count();

        public static double GetSurvivedPercent(this IEnumerable<TitanicData> data)
           => (double)data.GetTotalSurvivors() / data.GetTotalPassengers() * 100;

        public static int GetTotalFemaleSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(x => x.IsFemale && x.Survived).Count();

        public static double GetFemalesSurvivedPercent(this IEnumerable<TitanicData> data)
           => (double)data.GetTotalFemaleSurvivors() / data.GetTotalFemales() * 100;

        public static double GetSurvivedFemalesPercent(this IEnumerable<TitanicData> data)
           => (double)data.GetTotalFemaleSurvivors() / data.GetTotalSurvivors() * 100;

        public static double GetKidsUnderTenSurvivedPercent(this IEnumerable<TitanicData> data)
            => (double)data.Where(x => x.Age < 10 && x.Survived).Count() / data.Where(x => x.Age < 10).Count() * 100;

        public static TitanicData GetPortOfMostSurvivors(this IEnumerable<TitanicData> data)
           => data.Where(x => x.Survived).GroupBy(x => x.BoardingPort).OrderByDescending(x => x.Count()).First().First();

        public static string GetPortOfMostSurvivorsPercent(this IEnumerable<TitanicData> data)
        
            => data.Where(x => x.BoardingPort != "").GroupBy(x => x.BoardingPort).Select(x => new
               {
                   percent = (double)x.Where(p => p.Survived ).Count() / x.Count(),
                   port = x.Key.ToString()
               }).OrderByDescending(x => x.percent).First().port;

        public static string GetMostAgeGroupPassengers(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Age != null).GroupBy(x => (int)x.Age / 10).OrderByDescending(x => x.Count()).Select(x => new
            {
                AgeGroup = $"{x.Key * 10}/{x.Key * 10 + 9}"
            }).First().AgeGroup;

        public static string GetMostAgeGroupSurvivors(this IEnumerable<TitanicData> data)
            => data.Where(x => x.Age != null && x.Survived).GroupBy(x => (int)x.Age / 10).OrderByDescending(x => x.Count()).Select(x => new
            {
                AgeGroup = $"{x.Key * 10}/{x.Key * 10 + 9}"
            }).First().AgeGroup;


        /// <summary>
        /// you must modify the name of this method and its 
        /// implementation to fit your need and create more methods like this
        public static TitanicData ExtensionMethodPlaceHolder(this IEnumerable<TitanicData> data)
            => data.First(); 


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
