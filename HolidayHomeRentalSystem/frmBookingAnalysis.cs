using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HolidayHomeRentalSystem
{
    // public — доступна из других файлов (frmMainMenu открывает её)
    // partial — код разделён с frmManageAccounts.Designer.cs
    // : Form — наследует окно, заголовок и кнопку закрытия от класса Form
    public partial class frmBookingAnalysis : Form
    {
        private Chart chartBookings;

        public frmBookingAnalysis()
        {
            InitializeComponent();
            CreateChart();
        }

        private void CreateChart()
        {
            chartBookings = new Chart();
            chartBookings.Size = new Size(780, 250);
            chartBookings.Location = new Point(23, dgvBookings.Bottom + 10);
            chartBookings.BackColor = Color.White;

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "Month";
            area.AxisY.Title = "Bookings";
            chartBookings.ChartAreas.Add(area);

            Series series = new Series("Bookings");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.MediumSeaGreen;
            chartBookings.Series.Add(series);

            this.Controls.Add(chartBookings);

            if (this.ClientSize.Height < chartBookings.Bottom + 60)
                this.ClientSize = new Size(this.ClientSize.Width, chartBookings.Bottom + 60);

            btnClose.Location = new Point(btnClose.Location.X, chartBookings.Bottom + 10);
        }

        private void frmBookingAnalysis_Load(object sender, EventArgs e)
        {
            Utility.FormatGrid(dgvBookings);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show("Please enter a year.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TryParse безопасно конвертирует текст в число
            // Если не удалось (например "abc") → возвращает false → показываем ошибку
            // out int year → переменная year создаётся и заполняется автоматически
            // В отличие от Convert.ToInt32 — не бросает исключение при неправильном вводе

            if (!int.TryParse(txtYear.Text, out int year))  //пробует конвертировать текст в число:
            {
                MessageBox.Show("Year must be a valid number.", "Validation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                // GetYearlyBookings() возвращает данные сгруппированные по месяцам
                // monthNames[] конвертирует номер месяца в название (1 → "Jan")
                // Points.Clear() очищает старые данные перед новым запуском
                // foreach добавляет каждый месяц как столбик на Chart
                // dt.Rows.Count == 0 → нет данных за этот год

                DataTable dt = Rental.GetYearlyBookings(year);
                dgvBookings.DataSource = dt;

                Utility.SetColumnHeader(dgvBookings, "MONTH", "Month");
                Utility.SetColumnHeader(dgvBookings, "TOTALBOOKINGS", "Bookings");
                Utility.SetColumnHeader(dgvBookings, "TOTALGUESTS", "Total Guests");
                Utility.SetColumnHeader(dgvBookings, "REVENUE", "Revenue");
                Utility.SetColumnFormat(dgvBookings, "REVENUE", "C2");

                // Populate chart
                string[] monthNames = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                            "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

                chartBookings.Series["Bookings"].Points.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int monthNum = Convert.ToInt32(row["MONTH"]);
                    int bookings = Convert.ToInt32(row["TOTALBOOKINGS"]);

                    // Защита от неожиданных значений из Oracle
                    // Если monthNum вне диапазона 1-12 → просто показываем число
                    // Предотвращает IndexOutOfRangeException
                    string label = (monthNum >= 1 && monthNum <= 12)
                        ? monthNames[monthNum] : monthNum.ToString();

                    chartBookings.Series["Bookings"].Points.AddXY(label, bookings);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No booking data found for " + year + ".", "Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}