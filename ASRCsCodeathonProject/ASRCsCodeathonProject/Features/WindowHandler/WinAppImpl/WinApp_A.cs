using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRCsCodeathonProject.Features.WindowHandler.WinAppImpl
{
    abstract class WinApp_A
    {
        public WinApp_A()
        {
            //
        }

        //Name of the process as shown in windows task manager -- found under "Name" in the details tab
        public String winAppProcessName { get; set; }

        /*
         * The Data Struct isn't generic, but we will use it for now...
         * The parameter is a raw string of data which the windowStringProcessor gathers
        */
        public abstract SerializableDataStruct processWindowData(List<String> windowStringProcessorOutput);
    }
}
