using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataAnalyzer
{
    public class Data
    {
        public string DateTime { get; set; }
        public double Value { get; set; }

    }
    public class DataAggregator
    {
        private static readonly List<Data> dataList = new List<Data>();
        public static void AggregateData(string data)
        {
            TruncateData();
            data = DataCorrection(data);
            if (data != "")
            {
                float parsedValue = float.Parse(data, CultureInfo.InvariantCulture.NumberFormat);
                var time = Regex.Match(DateTime.Now.ToString(), @"(\w+:\w+:\w+)").ToString();

                dataList.Add(new Data { DateTime = time, Value = parsedValue });
            }

        }
        public static void ShowAllOfTheRecords()
        {
            foreach (var item in dataList)
            {
                Console.WriteLine($"{item.DateTime} {item.Value}");
            }
        }
        private static string DataCorrection(string data)
        {
            data = data.Replace("\r", "°C");
            data = Regex.Match(data, @"(\w{1,2}\.\w{2}°C)").ToString();
            data = data.Remove(data.Length - 2);
            return data;
        }

        private static void TruncateData()
        {
            if (dataList != null && dataList.Count > 100)
            {
                dataList.Remove(dataList.Last());
            }
        }
        public static void GenerateLog()
        {
            throw new NotImplementedException();
        }
        public static string CurrentValue()
        {
            return dataList.Select(x => x.Value).LastOrDefault().ToString();
        }
        public static string MaxValue()
        {
            List<Data> dataset = new List<Data>();
            dataset = dataList;

            if (dataList.Count == 0)
                return "0.00";
            else
                return dataset.Select(x=>x.Value).Max().ToString();
        }
        public static string MinValue()
        {
            List<Data> dataset = new List<Data>();
            dataset = dataList;

            if (dataList.Count == 0)
                return "0.00";
            else
                return dataset.Select(x => x.Value).Min().ToString();
        }
        public static string AvgValue()
        {
            List<Data> dataset = new List<Data>();
            dataset = dataList;

            if (dataList.Count == 0)
                return "0.00";
            else
                return String.Format("{0:F2}", dataset.Select(x => x.Value).Average()).ToString();
        }
    }
}