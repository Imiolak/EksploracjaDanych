using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace EuroFunds.Statistics
{
    public class ColumnChartBuilder<TKey, TValue> : ChartBuilderBase
    {
        public new ColumnChartBuilder<TKey, TValue> Title(string title)
        {
            base.Title(title);

            return this;
        }

        public new ColumnChartBuilder<TKey, TValue> WithLegend(string legendTitle = "")
        {
            base.WithLegend(legendTitle);

            return this;
        }

        public new ColumnChartBuilder<TKey, TValue> AxesTitles(string xAxisTitle = "", string yAxisTitle = "")
        {
            base.AxesTitles(xAxisTitle, yAxisTitle);

            return this;
        }

        public new ColumnChartBuilder<TKey, TValue> Height(int height)
        {
            base.Height(height);

            return this;
        }
 
        public new ColumnChartBuilder<TKey, TValue> Width(int width)
        {
            base.Width(width);

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

            Chart.Series.Add(series);

            return this;
        }
    }
}
