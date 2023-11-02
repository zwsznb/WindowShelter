using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Whiteboard
{
    public partial class Form1 : Form
    {
        private Thread ChangePosThread;
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
            ChangePosThread = new Thread(() =>
            {
                while (true)
                {
                    var rect = GetWindowRect();
                    var winInfo = new ShelterWinInfo(rect);
                    Location = new Point(rect.Left - 1, rect.Top);
                    //遮盖宽度，减三百是为了不遮盖关闭按钮
                    this.Width = winInfo.Width - 300;
                    //大概高度是十二分之一，微信显示名字的栏目
                    this.Height = Convert.ToInt32(winInfo.Height * 0.08);
                    Thread.Sleep(200);
                }
            });
            //设置为后台线程
            ChangePosThread.IsBackground = true;
            ChangePosThread.Start();
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
        private void Form1_Dispose(object sender, EventArgs e)
        {
            //终止线程
            if (ChangePosThread != null)
                ChangePosThread.Abort();
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
            Image img = Image.FromFile($@"{AppDomain.CurrentDomain.BaseDirectory}/1698909836913.jpg");
            //重置高宽
            Bitmap map = new Bitmap(img, new Size(width, height));
            var adjustMap = AdjustTobMosaic(map, 8);
            pictureBox1.Image = adjustMap;

        }

        /// <summary>
        /// https://www.cnblogs.com/smartsmile/p/7665799.html
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="effectWidth"></param>
        /// <returns></returns>
        public Bitmap AdjustTobMosaic(Bitmap bitmap, int effectWidth)
        {
            // 差异最多的就是以照一定范围取样 玩之后直接去下一个范围
            for (int heightOfffset = 0; heightOfffset < bitmap.Height; heightOfffset += effectWidth)
            {
                for (int widthOffset = 0; widthOffset < bitmap.Width; widthOffset += effectWidth)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    for (int x = widthOffset; (x < widthOffset + effectWidth && x < bitmap.Width); x++)
                    {
                        for (int y = heightOfffset; (y < heightOfffset + effectWidth && y < bitmap.Height); y++)
                        {
                            System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    // 计算范围平均
                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;


                    // 所有范围内都设定此值
                    for (int x = widthOffset; (x < widthOffset + effectWidth && x < bitmap.Width); x++)
                    {
                        for (int y = heightOfffset; (y < heightOfffset + effectWidth && y < bitmap.Height); y++)
                        {

                            System.Drawing.Color newColor = System.Drawing.Color.FromArgb(avgR, avgG, avgB);
                            bitmap.SetPixel(x, y, newColor);
                        }
                    }
                }
            }
            return bitmap;
        }
    }
}
