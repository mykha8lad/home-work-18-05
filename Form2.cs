using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork1805
{
    public partial class Form2 : Form
    {
        DateTime startTime;
        System.Windows.Forms.Timer timer;

        public Form2()
        {
            InitializeComponent();

            startTime = DateTime.Now;

            timer = new();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            int milliseconds = (int)elapsedTime.TotalMilliseconds;
            
            Text = milliseconds + " мс с момента запуска";
        }
    }
}
