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

        public void DrawChart(ref ToolStripMenuItem btn, double[] newestData)
        {
            chartValues.Clear();
            if (btn.Checked && newestData != null)
            {
                if (chartValues.Count > 40)
                {
                    chartValues.Remove(chartValues.First());
                }
                
                chartValues.AddRange(newestData);
            }

        }
    }
}
