using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataAnalyzer
{
    class DataAggregator
    {
        private static Dictionary<string, float> dataList = new Dictionary<string, float>();

        public static void AggregateData(string data)
        {

            TruncateData(dataList);
            data = DataCorrection(data);
            if (data != "")
            {
                float parsedValue = float.Parse(data, CultureInfo.InvariantCulture.NumberFormat);
                var time = Regex.Match(DateTime.Now.ToString(), @"(\w+:\w+:\w+)").ToString();
                dataList.Add(time, parsedValue);
            }

        }
        private static string DataCorrection(string data)
        {
            data = data.Replace("\r", "°C");
            data = Regex.Match(data, @"(\w{1,2}\.\w{2}°C)").ToString();
            return data;
        }
        public static void GenerateLog()
        {
            throw new NotImplementedException();
        }
        private static void TruncateData(Dictionary<string, float> dataList)
        {
            if (dataList.Count > 100)
            {
                dataList.Remove(dataList.Keys.First());
            }
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
