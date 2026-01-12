using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotel_ManagementIT13.Forms.Services
{
    public class ChartService
    {
        public void UpdateOccupancyChart(Chart chart, OccupancyData data, DateTime date)
        {
            try
            {
                chart.Series.Clear();

                var occupancySeries = new Series("Room Status")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    ChartArea = "ChartArea1"
                };

                int total = data.Available + data.Occupied + data.Reserved;

                if (total > 0)
                {
                    occupancySeries.Points.AddXY("Available", data.Available);
                    occupancySeries.Points.AddXY("Occupied", data.Occupied);
                    occupancySeries.Points.AddXY("Reserved", data.Reserved);
                }
                else
                {
                    occupancySeries.Points.AddXY("No Data", 1);
                }

                // Set colors
                if (occupancySeries.Points.Count >= 3)
                {
                    occupancySeries.Points[0].Color = Color.FromArgb(39, 174, 96);
                    occupancySeries.Points[1].Color = Color.FromArgb(192, 57, 43);
                    occupancySeries.Points[2].Color = Color.FromArgb(243, 156, 18);
                }
                else if (occupancySeries.Points.Count == 1)
                {
                    occupancySeries.Points[0].Color = Color.LightGray;
                }

                chart.Series.Add(occupancySeries);

                // Configure chart area
                chart.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart.ChartAreas[0].Area3DStyle.Rotation = 10;
                chart.ChartAreas[0].Area3DStyle.Inclination = 15;

                // Configure legend
                if (chart.Legends.Count == 0)
                {
                    chart.Legends.Add(new Legend());
                }
                chart.Legends[0].Enabled = true;
                chart.Legends[0].Docking = Docking.Bottom;
                chart.Legends[0].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                // Set labels with percentages
                if (total > 0)
                {
                    foreach (var point in occupancySeries.Points)
                    {
                        double percentage = (point.YValues[0] / total) * 100;
                        point.Label = $"{point.YValues[0]} ({percentage:F1}%)";
                        point.LabelForeColor = Color.White;
                        point.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    }
                }

                // Set chart title
                chart.Titles.Clear();
                var title = new Title($"Room Occupancy - {date:MMM dd, yyyy}")
                {
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(44, 62, 80)
                };
                chart.Titles.Add(title);

                chart.Visible = true;
            }
            catch (Exception ex)
            {
                chart.Titles.Clear();
                chart.Titles.Add("Chart Error - Check Data");
                chart.Titles[0].ForeColor = Color.Red;
                Console.WriteLine($"Error updating occupancy chart: {ex.Message}");
            }
        }

        public void UpdateRevenueChart(Chart chart, RevenueChartData data)
        {
            try
            {
                chart.Series.Clear();

                var revenueSeries = new Series("Revenue")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(52, 152, 219),
                    IsValueShownAsLabel = true,
                    LabelFormat = "₱#,##0",
                    ChartArea = "ChartArea1"
                };

                for (int i = 0; i < data.Days.Count; i++)
                {
                    revenueSeries.Points.AddXY(data.Days[i], data.Revenues[i]);
                }

                chart.Series.Add(revenueSeries);

                // Configure chart
                chart.ChartAreas[0].AxisY.Title = "Amount (₱)";
                chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                chart.Titles.Clear();
                chart.Titles.Add("Last 7 Days Revenue");
                chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                chart.Titles.Clear();
                chart.Titles.Add("Revenue Data Unavailable");
                Console.WriteLine($"Error in revenue chart: {ex.Message}");
            }
        }
    }
}