using System;
using System.Drawing;
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
        private int PositionX;
        private int PositionY;
        private string ProcessName;
        private string ImgPath;
        private Action CloseFormAction;
        private GifImage gifImage = null;
        public Form1(string processName, int width, int height, int positionX, int positionY,
            string imgPath, Action closeFormAction)
        {
            this.ProcessName = processName;
            this.ShelterWidth = width;
            this.ShelterHeight = height;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.ImgPath = imgPath;
            this.CloseFormAction = closeFormAction;
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //隐藏导航条
            this.FormBorderStyle = FormBorderStyle.None;
            DrawImage(this.pictureBox1);

            ChangePosThread = new Thread(() =>
            {
                while (true)
                {
                    var rect = GetWindowRect(ProcessName);
                    //针对选择窗口调整渲染位置
                    //初始渲染位置为窗口左上角
                    Location = new Point(this.PositionX + rect.Left - 1, this.PositionY + rect.Top);
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
            this.gifTimer.Stop();
        }
        private void KeyClose(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.CloseFormAction.Invoke();
            }
        }


        //TODO 优化？
        private void DrawImage(PictureBox image)
        {
            int width = image.Width, height = image.Height;
            Image img = null;
            if (IsNullAndEmpty(this.ImgPath))
            {
                NormalImage(width, height, $@"{AppDomain.CurrentDomain.BaseDirectory}/1698909836913.jpg");
            }
            else
            {
                if (this.ImgPath.EndsWith(".gif"))
                {
                    CreateGifImg();
                }
                else
                {
                    NormalImage(width, height, $"{this.ImgPath}");
                }
            }
        }

        private void NormalImage(int width, int height, string path)
        {
            Image img = Image.FromFile(path);
            //重置高宽
            Bitmap map = new Bitmap(img, new Size(width, height));
            pictureBox1.Image = map;
        }

        private void CreateGifImg()
        {
            if (this.ImgPath.EndsWith(".gif"))
            {
                gifImage = new GifImage(this.ImgPath);
                gifImage.ReverseAtEnd = false;
                this.gifTimer.Enabled = true;
            }
        }
        private void GifTimerTick(object sender, EventArgs e)
        {
            pictureBox1.Image = gifImage.GetNextFrame();
        }
    }
}
