using System.Windows.Forms.DataVisualization.Charting;

namespace EuroFunds.Statistics
{
    public abstract class ChartBuilderBase
    {
        protected readonly Chart Chart;

        protected ChartBuilderBase()
        {
            Chart = new Chart();
            Chart.ChartAreas.Add(new ChartArea());

            Chart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            Chart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90;
            Chart.ChartAreas[0].AxisX.Interval = 1;

            Chart.ChartAreas[0].AxisY.Minimum = 0;
            Chart.ChartAreas[0].AxisY.Maximum = double.NaN;
        }

        public Chart Build()
        {
            return Chart;
        }

        protected void Title(string title)
        {
            Chart.Titles.Add(title);
        }

        protected void WithLegend(string legendTitle = "")
        {
            Chart.Legends.Add(new Legend
            {
                Title = legendTitle
            });
        }

        protected void AxesTitles(string xAxisTitle = "", string yAxisTitle = "")
        {
            Chart.ChartAreas[0].AxisX.Title = xAxisTitle;
            Chart.ChartAreas[0].AxisY.Title = yAxisTitle;
        }

        public void Height(int height)
        {
            Chart.Height = height;
        }

        public void Width(int width)
        {
            Chart.Width = width;
        }
    }
}
