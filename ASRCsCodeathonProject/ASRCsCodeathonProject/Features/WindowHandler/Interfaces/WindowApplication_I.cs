using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASRCsCodeathonProject.Features.WindowHandler.Interfaces
{
    interface WindowApplication_I
    {
        //Name of the process as shown in windows task manager -- found under "Name" in the details tab
        String getWinAppProcessName();

        /*
         * The Data Struct isn't generic, but we will use it for now...
         * The parameter is a raw string of data which the windowStringProcessor gathers
        */
        SerializableDataStruct processWindowData(String windowStringProcessorOutput);
    }
}
