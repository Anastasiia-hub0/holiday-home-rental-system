using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HolidayHomeRentalSystem
{
    public partial class frmRevenueAnalysis : Form
    {
        private Chart chartRevenue;

        public frmRevenueAnalysis()
        {
            InitializeComponent();
            CreateChart();
        }

        private void CreateChart()
        {
            chartRevenue = new Chart();
            chartRevenue.Size = new Size(780, 250);
            chartRevenue.Location = new Point(23, dgvRevenue.Bottom + 10);
            chartRevenue.BackColor = Color.White;

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Month";
            area.AxisY.Title = "Revenue";
            area.AxisY.LabelStyle.Format = "C0";
            chartRevenue.ChartAreas.Add(area);

            Series series = new Series("Revenue");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.SteelBlue;
            chartRevenue.Series.Add(series);

            this.Controls.Add(chartRevenue);

           
            if (this.ClientSize.Height < chartRevenue.Bottom + 60)
                this.ClientSize = new Size(this.ClientSize.Width, chartRevenue.Bottom + 60);

            // Move Close button below chart
            btnClose.Location = new Point(btnClose.Location.X, chartRevenue.Bottom + 10);
        }

        private void frmRevenueAnalysis_Load(object sender, EventArgs e)
        {
            Utility.FormatGrid(dgvRevenue);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show("Please enter a year.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show("Year must be a valid number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                DataTable dt = Rental.GetYearlyRevenue(year);
                dgvRevenue.DataSource = dt;

                Utility.SetColumnHeader(dgvRevenue, "MONTH", "Month");
                Utility.SetColumnHeader(dgvRevenue, "TOTALBOOKINGS", "Bookings");
                Utility.SetColumnHeader(dgvRevenue, "TOTALREVENUE", "Revenue");
                Utility.SetColumnFormat(dgvRevenue, "TOTALREVENUE", "C2");

                // Populate chart
                string[] monthNames = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun","Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

                chartRevenue.Series["Revenue"].Points.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int monthNum = Convert.ToInt32(row["MONTH"]);
                    decimal revenue = Convert.ToDecimal(row["TOTALREVENUE"]);

                    string label = (monthNum >= 1 && monthNum <= 12)
                        ? monthNames[monthNum] : monthNum.ToString();

                    chartRevenue.Series["Revenue"].Points.AddXY(label, revenue);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No revenue data found for " + year + ".", "Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}