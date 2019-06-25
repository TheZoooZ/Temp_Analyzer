using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataAnalyzer
{
    public static class DataAggregator
    {
        public static Dictionary<string, float> DataList { get; private set; }

        public static void AggregateData(string data)
        {
            TruncateData(DataList);
            data = DataCorrection(data);
            if (data != "")
            {
                float parsedValue = float.Parse(data, CultureInfo.InvariantCulture.NumberFormat);
                var time = Regex.Match(DateTime.Now.ToString(), @"(\w+:\w+:\w+)").ToString();
                DataList.Add(time, parsedValue);
            }

        }
        private static string DataCorrection(string data)
        {
            data = data.Replace("\r", "°C");
            data = Regex.Match(data, @"(\w{1,2}\.\w{2}°C)").ToString().Remove(data.Length-2,2);
            return data;
        }
        private static void TruncateData(Dictionary<string, float> dataList)
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
            if (DataList.Count == 0)
                return "0.00";
            else
                return DataList.Values.Last().ToString();
        }
        public static string MaxValue()
        {
            if (DataList.Count == 0)
                return "0.00";
            else
                return DataList.Values.Max().ToString();
        }
        public static string MinValue()
        {
            if (DataList.Count == 0)
                return "0.00";
            else
                return DataList.Values.Min().ToString();
        }
        public static string AvgValue()
        {
            if (DataList.Count == 0)
                return "0.00";
            else
                return DataList.Values.Average().ToString();
        }
    }
}
