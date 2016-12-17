using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ASRCsCodeathonProject
{
    class WindowStringProcessor
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int Param, System.Text.StringBuilder text);

        public static List<String> processWindowStrings(IntPtr processHandle)
        {
            List<String> result = new List<String>();
            var allChildWindows = new WindowHandler(processHandle).GetAllChildHandles();
            foreach (IntPtr whndlr in allChildWindows)
            {
                const int WM_GETTEXT = 0x0D;
                StringBuilder sb = new StringBuilder(255);
                int RetVal = SendMessage(whndlr, WM_GETTEXT, sb.Capacity, sb);
                if (sb.Length > 0)
                {
                    result.Add(sb.ToString());
                }
            }

            return result;
        }
    }
}