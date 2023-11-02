using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static Whiteboard.Common;

namespace Whiteboard
{
    public partial class Form1 : Form
    {
        private Thread ChangePosThread;
        private int ShelterWidth;
        private int ShelterHeight;
        private int? PositionX;
        private int? PositionY;
        private string ProcessName;
        public Form1(string processName, int width, int height, int? positionX = null, int? positionY = null)
        {
            this.ProcessName = processName;
            this.ShelterWidth = width;
            this.ShelterHeight = height;
            this.PositionX = positionX;
            this.PositionY = positionY;
            InitializeComponent();
        }
        private void Form1Resize(object sender, EventArgs e)
        {
            var rect = GetWindowRect(ProcessName);
            var winInfo = new ShelterWinInfo(rect);
            this.pictureBox1.Width = winInfo.Width;
            this.pictureBox1.Height = winInfo.Height;
            DrawMosaic(this.pictureBox1);
        }

        private void Form1Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //隐藏导航条
            this.FormBorderStyle = FormBorderStyle.None;
            DrawMosaic(this.pictureBox1);
            if (this.PositionX.HasValue && this.PositionY.HasValue)
            {
                Location = new Point((int)this.PositionX, (int)this.PositionY);
                this.Width = this.ShelterWidth;
                this.Height = this.ShelterHeight;
                return;
            }
            ChangePosThread = new Thread(() =>
            {
                while (true)
                {
                    //如果没有指定定位则以遮盖窗口左上角为准
                    var rect = GetWindowRect(ProcessName);
                    Location = new Point(rect.Left - 1, rect.Top);
                    this.Width = this.ShelterWidth;
                    this.Height = this.ShelterHeight;
                    Thread.Sleep(200);
                }
            });
            //设置为后台线程
            ChangePosThread.IsBackground = true;
            ChangePosThread.Start();
        }


        private void Form1Dispose(object sender, EventArgs e)
        {
            //终止线程
            if (ChangePosThread != null)
                ChangePosThread.Abort();
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
