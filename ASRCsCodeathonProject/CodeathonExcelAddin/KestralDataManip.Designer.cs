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
            this.label1 = new System.Windows.Forms.Label();
            this.serializeData = new System.Windows.Forms.Button();
            this.loadSerializedData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // readData
            // 
            this.readData.Location = new System.Drawing.Point(49, 55);
            this.readData.Name = "readData";
            this.readData.Size = new System.Drawing.Size(75, 23);
            this.readData.TabIndex = 0;
            this.readData.Text = "button1";
            this.readData.UseVisualStyleBackColor = true;
            this.readData.Click += new System.EventHandler(this.readData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // serializeData
            // 
            this.serializeData.Location = new System.Drawing.Point(49, 179);
            this.serializeData.Name = "serializeData";
            this.serializeData.Size = new System.Drawing.Size(75, 23);
            this.serializeData.TabIndex = 2;
            this.serializeData.Text = "button1";
            this.serializeData.UseVisualStyleBackColor = true;
            this.serializeData.Click += new System.EventHandler(this.serializeData_Click);
            // 
            // loadSerializedData
            // 
            this.loadSerializedData.Location = new System.Drawing.Point(49, 235);
            this.loadSerializedData.Name = "loadSerializedData";
            this.loadSerializedData.Size = new System.Drawing.Size(75, 23);
            this.loadSerializedData.TabIndex = 3;
            this.loadSerializedData.UseVisualStyleBackColor = true;
            this.loadSerializedData.Click += new System.EventHandler(this.loadSerializedData_Click);
            // 
            // KestralDataManip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadSerializedData);
            this.Controls.Add(this.serializeData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readData);
            this.Name = "KestralDataManip";
            this.Size = new System.Drawing.Size(239, 476);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button serializeData;
        private System.Windows.Forms.Button loadSerializedData;
    }
}
