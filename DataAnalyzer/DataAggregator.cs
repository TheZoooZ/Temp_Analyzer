using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataAnalyzer
{
    public class DataAggregator
    {
        private static SortedDictionary<string, float> dataList = new SortedDictionary<string, float>();
        public static void AggregateData(string data)
        {
            TruncateData();
            data = DataCorrection(data);
            if (data != "")
            {
                float parsedValue = float.Parse(data, CultureInfo.InvariantCulture.NumberFormat);
                var time = Regex.Match(DateTime.Now.ToString(), @"(\w+:\w+:\w+)").ToString();

                dataList.Add(time, parsedValue);
            }

        }
        public static void ShowAllOfTheRecords()
        {
            foreach (var item in dataList)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
        }
        private static string DataCorrection(string data)
        {
            data = data.Replace("\r", "°C");
            data = Regex.Match(data, @"(\w{1,2}\.\w{2}°C)").ToString().Remove(data.Length - 2, 2);
            return data;
        }

        private static void TruncateData()
        {
            if (dataList.Count > 100)
            {
                dataList.Remove(dataList.Keys.First());
            }
        }
        public static void GenerateLog()
        {
            throw new NotImplementedException();
        }
        public static string CurrentValue()
        {
            if (dataList.Count == 0)
                return "0.00";
            else
                return dataList.Values.Last().ToString();
        }
        public static string MaxValue()
        {
            if (dataList.Count == 0)
                return "0.00";
            else
                return dataList.Values.Max().ToString();
        }
        public static string MinValue()
        {
            if (dataList.Count == 0)
                return "0.00";
            else
                return dataList.Values.Min().ToString();
        }
        public static string AvgValue()
        {
            if (dataList.Count == 0)
                return "0.00";
            else
                return dataList.Values.Average().ToString();
        }
    }
}