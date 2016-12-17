namespace CodeathonExcelAddin
{
    partial class KestrelDataAddInRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public KestrelDataAddInRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.customRibbon = this.Factory.CreateRibbonGroup();
            this.openManForm = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.customRibbon.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.customRibbon);
            this.tab1.Label = "Kestrel Data";
            this.tab1.Name = "tab1";
            // 
            // customRibbon
            // 
            this.customRibbon.Items.Add(this.openManForm);
            this.customRibbon.Label = "Open Data Form";
            this.customRibbon.Name = "customRibbon";
            // 
            // openManForm
            // 
            this.openManForm.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.openManForm.Image = global::CodeathonExcelAddin.Properties.Resources.Kestrel;
            this.openManForm.Label = " Data Model";
            this.openManForm.Name = "openManForm";
            this.openManForm.ShowImage = true;
            this.openManForm.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openManForm_Click);
            // 
            // KestrelDataAddInRibbon
            // 
            this.Name = "KestrelDataAddInRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.KestrelDataAddInRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.customRibbon.ResumeLayout(false);
            this.customRibbon.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup customRibbon;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openManForm;
    }

    partial class ThisRibbonCollection
    {
        internal KestrelDataAddInRibbon KestrelDataAddInRibbon
        {
            get { return this.GetRibbon<KestrelDataAddInRibbon>(); }
        }
    }
}
