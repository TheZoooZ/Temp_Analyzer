using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace DataAnalyzer.Tests
{
    [TestClass]
    public class DataAnalyzerTests
    {
        
        [TestMethod]
        public void DataAggregator_ShouldShowLatestValue()
        {
            DataAggregator.AggregateData("5.05\r");
            Thread.Sleep(1000);
            DataAggregator.AggregateData("18.55\r");

            Assert.AreEqual(DataAggregator.CurrentValue(),"18,55");
        }

        [TestMethod]
        public void DataAggregator_ShouldShowMaxValue()
        {
            DataAggregator.AggregateData("5.05\r");
            Thread.Sleep(1000);
            DataAggregator.AggregateData("18.55\r");
            Thread.Sleep(1000);
            Assert.AreEqual("18,55", DataAggregator.MaxValue());
        }

        [TestMethod]
        public void DataAggregator_ShouldShowMinValue()
        {
            DataAggregator.AggregateData("5.05\r");
            Thread.Sleep(1000);
            DataAggregator.AggregateData("18.55\r");
            Thread.Sleep(1000);
            Assert.AreEqual("5,05", DataAggregator.MinValue());
        }

        [TestMethod]
        public void DataAggregator_NotMoreThanOneHunderedRecords()
        {
            DataAggregator.AggregateData("11.11\r");
            Thread.Sleep(1000);
            DataAggregator.ShowAllOfTheRecords();
            for (int i = 0; i < 110; i++)
            {
                DataAggregator.AggregateData("22.22\r");
                Thread.Sleep(1000);
            }
            DataAggregator.AggregateData("66.66\r");
            DataAggregator.ShowAllOfTheRecords();
            
            Assert.AreEqual("66,66", DataAggregator.CurrentValue());
            Assert.AreNotEqual("11,11", DataAggregator.MinValue());
        }
    }
}
