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
            this.label1 = new System.Windows.Forms.Label();
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
            this.serializeData.Location = new System.Drawing.Point(24, 240);
            this.serializeData.Name = "serializeData";
            this.serializeData.Size = new System.Drawing.Size(193, 45);
            this.serializeData.TabIndex = 1;
            this.serializeData.Text = "Save Data and Close App";
            this.serializeData.UseVisualStyleBackColor = true;
            this.serializeData.Click += new System.EventHandler(this.serializeData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // KestrelLiveDataReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 318);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serializeData);
            this.Controls.Add(this.addLiveDataToList);
            this.Name = "KestrelLiveDataReader";
            this.Text = "KestrelLiveDataReader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addLiveDataToList;
        private System.Windows.Forms.Button serializeData;
        private System.Windows.Forms.Label label1;
    }
}