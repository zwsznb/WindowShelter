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
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            var changePosThread = new Thread(() =>
            {
                while (true)
                {
                    var rect = GetWeChatWindowRect(this);
                    Location = new Point(rect.Left - 8, rect.Top);
                    this.Width = rect.Right;
                    Thread.Sleep(200);
                }
            });
            //设置为后台线程
            changePosThread.IsBackground = true;
            changePosThread.Start();
        }

        private static User32.Rect GetWeChatWindowRect(Form form)
        {
            //获取所有的进程列表
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                string info = "";
                try
                {
                    if (p.ProcessName.Equals("WeChat"))
                    {
                        //获取窗口句柄
                        var handle = p.MainWindowHandle;

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
                Console.WriteLine(info);
            }
            return new User32.Rect();
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
    }
}
