using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalyzer
{
    public class Chart
    {
        ChartValues<double> chartValues = new ChartValues<double>();

        private LiveCharts.WinForms.CartesianChart _chart;
        public Chart(ref LiveCharts.WinForms.CartesianChart chart)
        {
            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = chartValues
                }
            };

            _chart = chart;
        }

        public void DrawChart(ref ToolStripMenuItem btn, IEnumerable<double> dataSet)
        {
            chartValues.Clear();
            if (btn.Checked && dataSet.Count() != 0)
            {
                chartValues.AddRange(dataSet.Reverse().Take(360).Reverse());
            }

        }
    }
}
