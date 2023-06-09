namespace HomeWork1805
{
    public partial class Form1 : Form
    {
        DateTime targetDate;
        System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();

            targetDate = new DateTime(2023, 6, 13);

            timer = new();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimeSpan remainingTime = targetDate - DateTime.Now;
            
            labelCountdown.Text = string.Format("До конца курса осталось {0} дня, {1:D2}:{2:D2}:{3:D2}",
                remainingTime.Days,
                remainingTime.Hours,
                remainingTime.Minutes,
                remainingTime.Seconds);
        }
    }
}