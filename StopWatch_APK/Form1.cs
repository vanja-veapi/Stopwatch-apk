using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace StopWatch_APK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.Timer timer1;
        //private System.Windows.Forms.Timer timer2;
        private int _seconds = 00;
        private int _minutes = 00;
        private int _hours = 00;
        private bool _check = false;
        

        private void start_Click_1(object sender, EventArgs e)
        {
            if(_check == false)
            {
                timer1 = new System.Windows.Forms.Timer();
                //timer2 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second                   

                timer1.Start();
                _check = true;
                textBox1.Text = _hours.ToString("D2") + ":" + _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(_check == true)
            {
                _seconds++;
                if (_seconds == 60)
                {
                    _seconds = 00;
                    _minutes++;
                }
                if (_minutes == 60)
                {
                    _minutes = 00;
                    _hours++;
                }
                textBox1.Text = _hours.ToString("D2") + ":" + _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
                notifyIcon.Text = _hours.ToString("D2") + ":" + _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
            }
        }
        private void stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            _check = false;
            textBox1.Text = _hours.ToString("D2") + ":" + _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //notifyIcon.Icon = SystemIcons.Application; // Proveriti sta je;
                //notifyIcon.BalloonTipText = _hours.ToString("D2") + ":" + _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
                //notifyIcon.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            _hours = 00;
            _minutes = 00;
            _seconds = 00;
            textBox1.Text = _hours.ToString("D2") + ":" + _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
            notifyIcon.Text = _hours.ToString("D2") + ":" + _minutes.ToString("D2") + ":" + _seconds.ToString("D2");
        }
    }
}
