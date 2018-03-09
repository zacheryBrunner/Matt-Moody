namespace Ksu.Cis300.MapViewer
{
    partial class uxMapViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uxMapViewer));
            this.uxButtonBar = new System.Windows.Forms.ToolStrip();
            this.uxOpenMap = new System.Windows.Forms.ToolStripButton();
            this.uxZoomIn = new System.Windows.Forms.ToolStripButton();
            this.uxZoomOut = new System.Windows.Forms.ToolStripButton();
            this.uxMapContainer = new System.Windows.Forms.Panel();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxButtonBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxButtonBar
            // 
            this.uxButtonBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uxButtonBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenMap,
            this.uxZoomIn,
            this.uxZoomOut});
            resources.ApplyResources(this.uxButtonBar, "uxButtonBar");
            this.uxButtonBar.Name = "uxButtonBar";
            // 
            // uxOpenMap
            // 
            this.uxOpenMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.uxOpenMap, "uxOpenMap");
            this.uxOpenMap.Name = "uxOpenMap";
            this.uxOpenMap.Click += new System.EventHandler(this.uxOpenMap_Click);
            // 
            // uxZoomIn
            // 
            this.uxZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.uxZoomIn, "uxZoomIn");
            this.uxZoomIn.Name = "uxZoomIn";
            this.uxZoomIn.Click += new System.EventHandler(this.uxZoomIn_Click);
            // 
            // uxZoomOut
            // 
            this.uxZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.uxZoomOut, "uxZoomOut");
            this.uxZoomOut.Name = "uxZoomOut";
            this.uxZoomOut.Click += new System.EventHandler(this.uxZoomOut_Click);
            // 
            // uxMapContainer
            // 
            resources.ApplyResources(this.uxMapContainer, "uxMapContainer");
            this.uxMapContainer.Name = "uxMapContainer";
            // 
            // uxOpenDialog
            // 
            resources.ApplyResources(this.uxOpenDialog, "uxOpenDialog");
            // 
            // uxMapViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uxMapContainer);
            this.Controls.Add(this.uxButtonBar);
            this.Name = "uxMapViewer";
            this.uxButtonBar.ResumeLayout(false);
            this.uxButtonBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip uxButtonBar;
        private System.Windows.Forms.ToolStripButton uxOpenMap;
        private System.Windows.Forms.ToolStripButton uxZoomIn;
        private System.Windows.Forms.ToolStripButton uxZoomOut;
        private System.Windows.Forms.Panel uxMapContainer;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

