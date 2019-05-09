using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAnalyzer
{
    class DataAggregator
    {
        private static List<int> dataList = new List<int>();

        public static void AggregateData(string data)
        {
            TruncateData(dataList);
            if(data!=null)
                dataList.Add(int.Parse(data));
        }

        private static void TruncateData(List<int> dataList)
        {
            if (dataList.Count > 100)
            {
                dataList.RemoveRange(0, 1);
            }
        }

        public static string MaxValue()
        {
            return dataList.Max().ToString();
        }
        public static string MinValue()
        {
            return dataList.Min().ToString();
        }
        public static string AvgValue()
        {
            return dataList.Average().ToString();
        }

    }
}
