using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace EuroFunds.Statistics
{
    public class ColumnChartBuilder<TKey, TValue>
    {
        private readonly Chart _chart;

        public ColumnChartBuilder()
        {
            _chart = new Chart();
            _chart.ChartAreas.Add(new ChartArea());

            _chart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            _chart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90;
            _chart.ChartAreas[0].AxisX.Interval = 1;

            _chart.ChartAreas[0].AxisY.Minimum = 0;
            _chart.ChartAreas[0].AxisY.Maximum = double.NaN;
        }

        public Chart Build()
        {
            return _chart;
        }

        public ColumnChartBuilder<TKey, TValue> Title(string title)
        {
            _chart.Titles.Add(title);

            return this;
        }

        public ColumnChartBuilder<TKey, TValue> WithLegend(string legendTitle = "")
        {
            _chart.Legends.Add(new Legend
            {
                Title = legendTitle
            });

            return this;
        }

        public ColumnChartBuilder<TKey, TValue> AxesTitles(string xAxisTitle = "", string yAxisTitle = "")
        {
            _chart.ChartAreas[0].AxisX.Title = xAxisTitle;
            _chart.ChartAreas[0].AxisY.Title = yAxisTitle;

            return this;
        }

        public ColumnChartBuilder<TKey, TValue> Height(int height)
        {
            _chart.Height = height;

            return this;
        }
 
        public ColumnChartBuilder<TKey, TValue> Width(int width)
        {
            _chart.Width = width;

            return this;
        }

        public ColumnChartBuilder<TKey, TValue> AddSeries(string seriesName, IDictionary<TKey, TValue> values)
        {
            var series = new Series
            {
                Name = seriesName,
                ChartType = SeriesChartType.Column
            };

            foreach (var entry in values)
            {
                series.Points.AddXY(entry.Key, entry.Value);
            }

            _chart.Series.Add(series);

            return this;
        }
    }
}
