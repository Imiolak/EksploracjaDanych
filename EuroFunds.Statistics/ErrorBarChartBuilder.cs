using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace EuroFunds.Statistics
{
    public class ErrorBarChartBuilder<TKey, TValue> : ChartBuilderBase
    {
        public new ErrorBarChartBuilder<TKey, TValue> Title(string title)
        {
            base.Title(title);

            return this;
        }

        public new ErrorBarChartBuilder<TKey, TValue> WithLegend(string legendTitle = "")
        {
            base.WithLegend(legendTitle);

            return this;
        }

        public new ErrorBarChartBuilder<TKey, TValue> AxesTitles(string xAxisTitle = "", string yAxisTitle = "")
        {
            base.AxesTitles(xAxisTitle, yAxisTitle);

            return this;
        }

        public new ErrorBarChartBuilder<TKey, TValue> Height(int height)
        {
            base.Height(height);

            return this;
        }

        public new ErrorBarChartBuilder<TKey, TValue> Width(int width)
        {
            base.Width(width);

            return this;
        }

        public ErrorBarChartBuilder<TKey, TValue> AddSeries(string seriesName, IDictionary<TKey, TValue> values,
            IEnumerable<TValue> standardDeviations)
        {
            var valueSeries = new Series
            {
                Name = seriesName,
                ChartType = SeriesChartType.Column
            };

            for (var i = 0; i < values.Count; i++)
            {
                valueSeries.Points.AddXY(values.ElementAt(i).Key, values.ElementAt(i).Value);
            }

            var errorSeries = new Series
            {
                Name = seriesName + "Error",
                ChartType = SeriesChartType.ErrorBar,
                YValuesPerPoint = 3
            };

            for (var i = 0; i < values.Count; i++)
            {
                dynamic value = values.ElementAt(i).Value;
                dynamic stdDev = standardDeviations.ElementAt(i);

                errorSeries.Points.AddXY(values.ElementAt(i).Key, value,
                    value - stdDev, value + stdDev);
            }

            Chart.Series.Add(valueSeries);
            Chart.Series.Add(errorSeries);

            return this;
        }
    }
}
