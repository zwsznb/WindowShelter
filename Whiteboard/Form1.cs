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
        private void Form1Resize(object sender, EventArgs e)
        {
            var rect = GetWindowRect(ProcessName);
            var winInfo = new ShelterWinInfo(rect);
            this.pictureBox1.Width = winInfo.Width;
            this.pictureBox1.Height = winInfo.Height;
            DrawImage(this.pictureBox1);
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
        }
        private void KeyClose(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                this.CloseFormAction.Invoke();
            }
        }


        //画马赛克
        private void DrawImage(PictureBox image)
        {
            int width = image.Width, height = image.Height;
            Image img = null;
            if (IsNullAndEmpty(this.ImgPath))
                img = Image.FromFile($@"{AppDomain.CurrentDomain.BaseDirectory}/1698909836913.jpg");
            else
                img = Image.FromFile($"{this.ImgPath}");
            //重置高宽
            Bitmap map = new Bitmap(img, new Size(width, height));
            pictureBox1.Image = map;

        }
    }
}
