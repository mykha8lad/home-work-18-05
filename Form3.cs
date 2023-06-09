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
    public partial class Form3 : Form
    {
        System.Windows.Forms.Timer timer;
        Color[] colors = { Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Pink, Color.White };

        int currentColorIndex = 0;
        int colorTransitionDuration = 2000;
        DateTime transitionStartTime;

        public Form3()
        {
            InitializeComponent();

            timer = new();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

            transitionStartTime = DateTime.Now;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime - transitionStartTime;
            
            double transitionProgress = elapsedTime.TotalMilliseconds / colorTransitionDuration;
            
            if (transitionProgress >= 1)
            {
                currentColorIndex = (currentColorIndex + 1) % colors.Length;
                transitionStartTime = currentTime;
            }

            Color currentColor = InterpolateColor(colors[currentColorIndex], colors[(currentColorIndex + 1) % colors.Length], transitionProgress);

            BackColor = currentColor;
        }

        private Color InterpolateColor(Color color1, Color color2, double progress)
        {
            int red = (int)Math.Round(color1.R + (color2.R - color1.R) * progress);
            int green = (int)Math.Round(color1.G + (color2.G - color1.G) * progress);
            int blue = (int)Math.Round(color1.B + (color2.B - color1.B) * progress);

            red = Math.Clamp(red, 0, 255);
            green = Math.Clamp(green, 0, 255);
            blue = Math.Clamp(blue, 0, 255);

            return Color.FromArgb(red, green, blue);
        }
    }
}
