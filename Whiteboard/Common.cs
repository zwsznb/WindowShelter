using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Whiteboard
{
    public static class Common
    {
        public static int GetProcessIdByName(string ProcessName)
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
        public static List<string> GetProcessNameList()
        {
            //获取所有的进程列表
            Process[] ps = Process.GetProcesses();
            var processList = new List<string>();
            foreach (Process p in ps)
            {
                try
                {
                    processList.Add(p.ProcessName);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return processList.OrderBy(x => x).ToList();
        }
        public static User32.Rect GetWindowRect(string ProcessName)
        {
            var process = Process.GetProcessById(Common.GetProcessIdByName(ProcessName));
            //获取窗口句柄
            var handle = process.MainWindowHandle;

            Common.User32.Rect windowRect = new Common.User32.Rect();
            var isSuccess = Common.User32.GetWindowRect(handle, ref windowRect);
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
    }
}
