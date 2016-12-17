using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ASRCsCodeathonProject.Features.WindowHandler.WinAppImpl;
using System.Collections;

namespace ASRCsCodeathonProject.Features.WindowHandler
{
    class WindowHandlerManager
    {
        public WindowHandlerManager()
        {
            initialize();
        }

        private void initialize()
        {
            WinApp_A windowsApp = new WinAppKestrelTracker();
            Process[] processes = Process.GetProcessesByName(windowsApp.winAppProcessName);
            if (processes[0] != null)
            {
                List<String> windowStrings = WindowStringProcessor.processWindowStrings(processes[0].MainWindowHandle);
                SerializableDataStruct windowData = windowsApp.processWindowData(windowStrings);
            }
        }

        public static void Main()
        {
            new WindowHandlerManager();
        }
    }
}
