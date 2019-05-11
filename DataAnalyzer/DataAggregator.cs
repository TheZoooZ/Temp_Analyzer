using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalyzer
{
    class DataAggregator
    {
        private static Dictionary<string,float> dataList = new Dictionary<string, float>();

        public static void AggregateData(string data)
        {
            TruncateData(dataList);
            if (data != "")
            {
                float parsedValue = float.Parse(data, CultureInfo.InvariantCulture.NumberFormat);
                var time = Regex.Match(DateTime.Now.ToString(), @"(\w+:\w+:\w+)").ToString();
                dataList.Add(time, parsedValue);
            }
                
        }
        public static void GenerateLog()
        {
        }
        private static void TruncateData(Dictionary<string,float> dataList)
        {
            if (dataList.Count > 100)
            {
                dataList.Remove(dataList.Keys.First());
            }
        }
        public static string CurrentValue()
        {
            if(dataList.Count == 0)
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
