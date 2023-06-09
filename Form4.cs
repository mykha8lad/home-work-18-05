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
    public partial class Form4 : Form
    {
        int clickCount = 0;
        int maxClickCount = 0;
        System.Windows.Forms.Timer timer;
        int gameDurationSeconds = 20;

        public Form4()
        {
            InitializeComponent();

            button.Click += Button_Click; ;

            timer = new();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick; ;

            StartGame();
        }

        private void StartGame()
        {
            clickCount = 0;
            button.Enabled = true;
            button.Text = "Нажми!";
            timer.Start();
        }

        private void EndGame()
        {
            button.Enabled = false;
            timer.Stop();

            string message = $"Ты прожмякал {clickCount} раз\nРекорд: {maxClickCount}";
            MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            gameDurationSeconds--;

            if (gameDurationSeconds <= 0)
            {
                EndGame();
            }
            else
            {
                button.Text = $"До самоуничтожения тачпада осталось: {gameDurationSeconds}";
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            clickCount++;
            button.Text = $"Ну же: {clickCount}";

            if (clickCount > maxClickCount)
                maxClickCount = clickCount;
        }
    }
}
