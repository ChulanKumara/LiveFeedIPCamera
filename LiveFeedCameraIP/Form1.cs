using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using MjpegProcessor;

namespace LiveFeedCameraIP
{
    public partial class Form1 : Form
    {
        private MJPEGStream mpeg;       
        public Form1()
        {
            InitializeComponent();
            mpeg = new MJPEGStream();
            
            mpeg.Login = "admin";
            mpeg.Password = "admin1234";
            //mpeg.Source = "http://10.128.1.31/Streaming/Channels/1/picture";
            mpeg.Source = "http://88.53.197.250/axis-cgi/mjpg/video.cgi?resolution=320×240";            
            mpeg.NewFrame += mpeg_NewFrame;
           
        }

        private void mpeg_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap) eventArgs.Frame.Clone();
            pictureBox1.Image = bmp;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            // Create new stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing
            stopwatch.Start();

            mpeg.Start();

            System.Threading.Thread.Sleep(500);

            // Stop timing
            stopwatch.Stop();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);           
        }
    }
}
