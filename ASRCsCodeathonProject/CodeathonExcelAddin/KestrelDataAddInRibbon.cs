using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace CodeathonExcelAddin
{
    public partial class KestrelDataAddInRibbon
    {
        private Microsoft.Office.Tools.CustomTaskPane kestrelTaskPane;

        private void KestrelDataAddInRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void openManForm_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Application excel_app = (Excel.Application)Globals.ThisAddIn.Application;
            Excel.Workbook active_workbook = null;
            Excel.Worksheet active_sheet = null;

            if (excel_app != null)
            {
                active_workbook = excel_app.ActiveWorkbook;
                if (active_workbook != null)
                {
                    active_sheet = active_workbook.ActiveSheet;
                }
            }

            if (active_sheet == null)
            {
                System.Windows.Forms.MessageBox.Show("No active sheet available. Please make sure that a Excel file is loaded!");
                return;
            }



            Excel.Range usedRange = active_sheet.UsedRange;
            if (usedRange.Rows.Count > 2 && usedRange.Columns.Count > 2)
            {

                if (kestrelTaskPane == null)
                {
                    KestralDataManip krestralDataManip = new KestralDataManip(active_sheet, active_workbook, this);
                    kestrelTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(krestralDataManip, "Kestrel Comm Pane");
                    kestrelTaskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft;
                    kestrelTaskPane.DockPositionRestrict = Microsoft.Office.Core.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;
                    kestrelTaskPane.Width = 460;
                }

                kestrelTaskPane.Visible = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("There must be data on spread sheet to open the form. \n If you are going to build a forest this data will be used to build the forest \n Other wise the loaded data will be run down a forest once one is loaded");
            }
        }

        public void closePane()
        {
            //close pane and remove from memory
            kestrelTaskPane.Visible = false;
            //ControlVisitor visitor = ((Controls.WizardControl)randomForestTaskPane.Control).getControlVisitor();
            Globals.ThisAddIn.CustomTaskPanes.Remove(kestrelTaskPane);

            kestrelTaskPane = null;


        }
    }
}
