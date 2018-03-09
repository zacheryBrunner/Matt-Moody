﻿namespace Ksu.Cis300.TravelingSalesperson
{
    partial class UserInterface
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
            this.uxOpenButton = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxTourLabel = new System.Windows.Forms.Label();
            this.uxTour = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxOpenButton
            // 
            this.uxOpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F);
            this.uxOpenButton.Location = new System.Drawing.Point(12, 12);
            this.uxOpenButton.Name = "uxOpenButton";
            this.uxOpenButton.Size = new System.Drawing.Size(305, 66);
            this.uxOpenButton.TabIndex = 0;
            this.uxOpenButton.Text = "Load Graph";
            this.uxOpenButton.UseVisualStyleBackColor = true;
            this.uxOpenButton.Click += new System.EventHandler(this.uxOpenButton_Click);
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.FileName = "openFileDialog1";
            // 
            // uxTourLabel
            // 
            this.uxTourLabel.AutoSize = true;
            this.uxTourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F);
            this.uxTourLabel.Location = new System.Drawing.Point(9, 81);
            this.uxTourLabel.Name = "uxTourLabel";
            this.uxTourLabel.Size = new System.Drawing.Size(71, 29);
            this.uxTourLabel.TabIndex = 1;
            this.uxTourLabel.Text = "Tour:";
            // 
            // uxTour
            // 
            this.uxTour.AcceptsReturn = true;
            this.uxTour.Location = new System.Drawing.Point(12, 113);
            this.uxTour.Multiline = true;
            this.uxTour.Name = "uxTour";
            this.uxTour.ReadOnly = true;
            this.uxTour.Size = new System.Drawing.Size(305, 236);
            this.uxTour.TabIndex = 2;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 361);
            this.Controls.Add(this.uxTour);
            this.Controls.Add(this.uxTourLabel);
            this.Controls.Add(this.uxOpenButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(347, 408);
            this.MinimumSize = new System.Drawing.Size(347, 408);
            this.Name = "UserInterface";
            this.Text = "Traveling Salesperson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxOpenButton;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.Label uxTourLabel;
        private System.Windows.Forms.TextBox uxTour;
    }
}

