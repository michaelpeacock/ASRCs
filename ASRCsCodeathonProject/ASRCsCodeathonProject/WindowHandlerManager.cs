using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ASRCsCodeathonProject;
using System.Collections;

namespace ASRCsCodeathonProject
{
    public class WindowHandlerManager
    {
        public WindowHandlerManager()
        {
            initialize();
        }

        private void initialize()
        {
            //currently no initializing needed
        }

        public SerializableDataStruct getKestrelAppData()
        {
            WinApp_A windowsApp = new WinAppKestrelTracker();
            Process[] processes = Process.GetProcessesByName(windowsApp.winAppProcessName);
            SerializableDataStruct dataResult = null;

            if (processes[0] != null)
            {
                List<String> windowStrings = WindowStringProcessor.processWindowStrings(processes[0].MainWindowHandle);
                dataResult = windowsApp.processWindowData(windowStrings);
            }
            else
            {
                //app not running exception
            }

            return dataResult;
        }

    }
}