using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ASRCsCodeathonProject
{
    public partial class KestrelLiveDataReader : Form
    {
        ListSerializableDataStruct lsds;
        WindowHandlerManager whm;
        private Timer timer;

        public KestrelLiveDataReader()
        {
            lsds = new ListSerializableDataStruct();
            whm = new WindowHandlerManager();
            InitializeComponent();
        }

        
        public void InitTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 5000; // in miliseconds
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lsds.add(whm.getKestrelAppData());
        }

        private void addLiveDataToList_Click(object sender, EventArgs e)
        {
            InitTimer();
        }

        private void serializeData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog.ShowNewFolderButton = false;
            saveFileDialog.DefaultExt = "osl";
            saveFileDialog.Filter = "osl files (*.osl)|*.osl";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Personal;
            saveFileDialog.InitialDirectory = folderBrowserDialog.SelectedPath;
            saveFileDialog.FileName = null;
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string saveFileName = saveFileDialog.FileName;
                try
                {

                    Stream stream = File.Open(saveFileName, FileMode.Create);
                    BinaryFormatter bformatter = new BinaryFormatter();

                    bformatter.Serialize(stream, lsds);
                    stream.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
                }
                Invalidate();

            }

       // Cancel button was pressed. 
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
