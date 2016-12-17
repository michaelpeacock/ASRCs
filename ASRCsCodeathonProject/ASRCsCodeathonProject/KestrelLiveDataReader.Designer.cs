namespace ASRCsCodeathonProject
{
    partial class KestrelLiveDataReader
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addLiveDataToList = new System.Windows.Forms.Button();
            this.serializeData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addLiveDataToList
            // 
            this.addLiveDataToList.Location = new System.Drawing.Point(24, 22);
            this.addLiveDataToList.Name = "addLiveDataToList";
            this.addLiveDataToList.Size = new System.Drawing.Size(193, 45);
            this.addLiveDataToList.TabIndex = 0;
            this.addLiveDataToList.Text = "Read Live Data";
            this.addLiveDataToList.UseVisualStyleBackColor = true;
            this.addLiveDataToList.Click += new System.EventHandler(this.addLiveDataToList_Click);
            // 
            // serializeData
            // 
            this.serializeData.Location = new System.Drawing.Point(24, 97);
            this.serializeData.Name = "serializeData";
            this.serializeData.Size = new System.Drawing.Size(193, 45);
            this.serializeData.TabIndex = 1;
            this.serializeData.Text = "Save Data and Close App";
            this.serializeData.UseVisualStyleBackColor = true;
            this.serializeData.Click += new System.EventHandler(this.serializeData_Click);
            // 
            // KestrelLiveDataReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 172);
            this.Controls.Add(this.serializeData);
            this.Controls.Add(this.addLiveDataToList);
            this.Name = "KestrelLiveDataReader";
            this.Text = "KestrelLiveDataReader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addLiveDataToList;
        private System.Windows.Forms.Button serializeData;
    }
}