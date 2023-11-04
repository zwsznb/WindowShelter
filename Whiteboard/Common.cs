using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

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
        public enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }
        /// <summary>
        /// 判断文件是否为图片
        /// 参考：https://web.archive.org/web/20090302032444/http://www.mikekunz.com/image_file_header.html
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            // see http://www.mikekunz.com/image_file_header.html  
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }
        public static bool IsImageFile(string fileName)
        {
            var format = GetImageFormat(File.ReadAllBytes(fileName));
            return format != ImageFormat.unknown;
        }

        public static bool IsNullAndEmpty(string str)
        {
            return str == null || str.Trim().Length == 0;
        }
    }
}
