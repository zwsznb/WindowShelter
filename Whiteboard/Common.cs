using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return processList;
        }
    }
}
