namespace CodeathonExcelAddin
{
    partial class KestralDataManip
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.readData = new System.Windows.Forms.Button();
            this.serializeData = new System.Windows.Forms.Button();
            this.loadSerializedData = new System.Windows.Forms.Button();
            this.mergeDataSets = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // readData
            // 
            this.readData.Location = new System.Drawing.Point(20, 22);
            this.readData.Name = "readData";
            this.readData.Size = new System.Drawing.Size(179, 35);
            this.readData.TabIndex = 0;
            this.readData.Text = "Read Data From Sheet";
            this.readData.UseVisualStyleBackColor = true;
            this.readData.Click += new System.EventHandler(this.readData_Click);
            // 
            // serializeData
            // 
            this.serializeData.Location = new System.Drawing.Point(20, 64);
            this.serializeData.Name = "serializeData";
            this.serializeData.Size = new System.Drawing.Size(179, 35);
            this.serializeData.TabIndex = 2;
            this.serializeData.Text = "Serialize Data";
            this.serializeData.UseVisualStyleBackColor = true;
            this.serializeData.Click += new System.EventHandler(this.serializeData_Click);
            // 
            // loadSerializedData
            // 
            this.loadSerializedData.Location = new System.Drawing.Point(20, 106);
            this.loadSerializedData.Name = "loadSerializedData";
            this.loadSerializedData.Size = new System.Drawing.Size(179, 35);
            this.loadSerializedData.TabIndex = 3;
            this.loadSerializedData.Text = "Load Serialized Data";
            this.loadSerializedData.UseVisualStyleBackColor = true;
            this.loadSerializedData.Click += new System.EventHandler(this.loadSerializedData_Click);
            // 
            // mergeDataSets
            // 
            this.mergeDataSets.Location = new System.Drawing.Point(20, 147);
            this.mergeDataSets.Name = "mergeDataSets";
            this.mergeDataSets.Size = new System.Drawing.Size(179, 35);
            this.mergeDataSets.TabIndex = 7;
            this.mergeDataSets.Text = "Merge Data Sets (loaded and sheet)";
            this.mergeDataSets.UseVisualStyleBackColor = true;
            this.mergeDataSets.Click += new System.EventHandler(this.mergeDataSets_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Merge Data Sets (Load in)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.mergeAnotherLoadedSet_Click);
            // 
            // KestralDataManip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mergeDataSets);
            this.Controls.Add(this.loadSerializedData);
            this.Controls.Add(this.serializeData);
            this.Controls.Add(this.readData);
            this.Name = "KestralDataManip";
            this.Size = new System.Drawing.Size(223, 476);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button readData;
        private System.Windows.Forms.Button serializeData;
        private System.Windows.Forms.Button loadSerializedData;
        private System.Windows.Forms.Button mergeDataSets;
        private System.Windows.Forms.Button button1;
    }
}
