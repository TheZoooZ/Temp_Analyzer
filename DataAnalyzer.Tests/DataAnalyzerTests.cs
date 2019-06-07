using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnalyzer.Tests
{
    [TestClass]
    public class DataAnalyzerTests
    {
        [TestMethod]
        public void ShouldNotAggregate()
        {
            DataAggregator.AggregateData("22.22/r");
            Assert.AreEqual(DataAggregator.CurrentValue(),22.22);
        }
    }
}
