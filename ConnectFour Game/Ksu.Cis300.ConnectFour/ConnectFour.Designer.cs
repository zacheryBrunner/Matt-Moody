namespace Ksu.Cis300.ConnectFour
{
    partial class ConnectFour
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
            this.uxTopContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTurnLabel = new System.Windows.Forms.Label();
            this.uxPlayerLabel = new System.Windows.Forms.Label();
            this.uxPlaceButtonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxBoardContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTopContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxTopContainer
            // 
            this.uxTopContainer.Controls.Add(this.uxTurnLabel);
            this.uxTopContainer.Controls.Add(this.uxPlayerLabel);
            this.uxTopContainer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.uxTopContainer.Location = new System.Drawing.Point(12, 12);
            this.uxTopContainer.Name = "uxTopContainer";
            this.uxTopContainer.Size = new System.Drawing.Size(518, 28);
            this.uxTopContainer.TabIndex = 0;
            // 
            // uxTurnLabel
            // 
            this.uxTurnLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uxTurnLabel.Location = new System.Drawing.Point(465, 0);
            this.uxTurnLabel.Name = "uxTurnLabel";
            this.uxTurnLabel.Size = new System.Drawing.Size(50, 17);
            this.uxTurnLabel.TabIndex = 1;
            // 
            // uxPlayerLabel
            // 
            this.uxPlayerLabel.AutoSize = true;
            this.uxPlayerLabel.Location = new System.Drawing.Point(359, 0);
            this.uxPlayerLabel.Name = "uxPlayerLabel";
            this.uxPlayerLabel.Size = new System.Drawing.Size(100, 17);
            this.uxPlayerLabel.TabIndex = 0;
            this.uxPlayerLabel.Text = "Player\'s Turn: ";
            // 
            // uxPlaceButtonContainer
            // 
            this.uxPlaceButtonContainer.Location = new System.Drawing.Point(12, 46);
            this.uxPlaceButtonContainer.Name = "uxPlaceButtonContainer";
            this.uxPlaceButtonContainer.Size = new System.Drawing.Size(518, 30);
            this.uxPlaceButtonContainer.TabIndex = 0;
            // 
            // uxBoardContainer
            // 
            this.uxBoardContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxBoardContainer.Location = new System.Drawing.Point(12, 82);
            this.uxBoardContainer.Name = "uxBoardContainer";
            this.uxBoardContainer.Size = new System.Drawing.Size(518, 419);
            this.uxBoardContainer.TabIndex = 0;
            // 
            // ConnectFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 513);
            this.Controls.Add(this.uxBoardContainer);
            this.Controls.Add(this.uxPlaceButtonContainer);
            this.Controls.Add(this.uxTopContainer);
            this.MaximizeBox = false;
            this.Name = "ConnectFour";
            this.Text = "Connect Four";
            this.uxTopContainer.ResumeLayout(false);
            this.uxTopContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uxTopContainer;
        private System.Windows.Forms.FlowLayoutPanel uxPlaceButtonContainer;
        private System.Windows.Forms.FlowLayoutPanel uxBoardContainer;
        private System.Windows.Forms.Label uxTurnLabel;
        private System.Windows.Forms.Label uxPlayerLabel;
    }
}

