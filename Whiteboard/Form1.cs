using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whiteboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string ProcessName = "WeChat";
        private void Form1_Resize(object sender, EventArgs e)
        {
            var rect = GetWindowRect();
            var winInfo = new ShelterWinInfo(rect);
            this.pictureBox1.Width = winInfo.Width;
            this.pictureBox1.Height = winInfo.Height;
            DrawMosaic(this.pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //隐藏导航条
            this.FormBorderStyle = FormBorderStyle.None;
            DrawMosaic(this.pictureBox1);
            var changePosThread = new Thread(() =>
            {
                while (true)
                {
                    var rect = GetWindowRect();
                    var winInfo = new ShelterWinInfo(rect);
                    Location = new Point(rect.Left - 8, rect.Top);
                    this.Width = winInfo.Width - 300;
                    Thread.Sleep(200);
                }
            });
            //设置为后台线程
            changePosThread.IsBackground = true;
            changePosThread.Start();
        }

        private int GetProcessIdByName()
        {
            //获取所有的进程列表
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                try
                {
                    if (p.ProcessName.Equals(ProcessName))
                    {
                        return p.Id;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return 0;
        }

        public User32.Rect GetWindowRect()
        {
            var process = Process.GetProcessById(GetProcessIdByName());
            //获取窗口句柄
            var handle = process.MainWindowHandle;

            User32.Rect windowRect = new User32.Rect();
            var isSuccess = User32.GetWindowRect(handle, ref windowRect);
            if (isSuccess)
            {
                //左上角
                Console.WriteLine(windowRect.Top);
                Console.WriteLine(windowRect.Left);
                //右下角
                Console.WriteLine(windowRect.Right);
                Console.WriteLine(windowRect.Bottom);
                return windowRect;
            }
            else
            {
                Console.WriteLine("获取窗口信息失败");
            }
            return windowRect;
        }

        public static class User32
        {
            [DllImport("User32.dll")]
            public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
        }
        public class ShelterWinInfo
        {
            public ShelterWinInfo(User32.Rect rect)
            {
                Width = rect.Right - rect.Left;
                Height = rect.Bottom - rect.Top;
            }
            public int Width { get; set; }
            public int Height { get; set; }

        }

        //画马赛克
        private void DrawMosaic(PictureBox image)
        {
            int width = image.Width, height = image.Height;

            //bitmap
            Bitmap bmp = new Bitmap(width, height);

            //random number
            Random rand = new Random();

            //create random pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //generate random ARGB value
                    int a = rand.Next(256);
                    int r = rand.Next(256);
                    int g = rand.Next(256);
                    int b = rand.Next(256);

                    //set ARGB value
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            //load bmp in picturebox1
            pictureBox1.Image = bmp;


        }
    }
}
