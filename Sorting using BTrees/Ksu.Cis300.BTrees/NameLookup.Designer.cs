namespace Ksu.Cis300.BTrees
{
    partial class NameLookup
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
            this.uxMakeTree = new System.Windows.Forms.Button();
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxLookup = new System.Windows.Forms.Button();
            this.uxCount = new System.Windows.Forms.NumericUpDown();
            this.uxMinDegree = new System.Windows.Forms.NumericUpDown();
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxNumItemsLabel = new System.Windows.Forms.Label();
            this.uxMinLabel = new System.Windows.Forms.Label();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uxCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinDegree)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMakeTree
            // 
            this.uxMakeTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxMakeTree.Location = new System.Drawing.Point(233, 12);
            this.uxMakeTree.Name = "uxMakeTree";
            this.uxMakeTree.Size = new System.Drawing.Size(154, 56);
            this.uxMakeTree.TabIndex = 0;
            this.uxMakeTree.Text = "Make Tree";
            this.uxMakeTree.UseVisualStyleBackColor = true;
            this.uxMakeTree.Click += new System.EventHandler(this.uxMakeTree_Click);
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxOpen.Location = new System.Drawing.Point(12, 74);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(375, 60);
            this.uxOpen.TabIndex = 1;
            this.uxOpen.Text = "Open Data File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxLookup
            // 
            this.uxLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxLookup.Location = new System.Drawing.Point(12, 184);
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(375, 65);
            this.uxLookup.TabIndex = 2;
            this.uxLookup.Text = "Get Statistics";
            this.uxLookup.UseVisualStyleBackColor = true;
            this.uxLookup.Click += new System.EventHandler(this.uxLookup_Click);
            // 
            // uxCount
            // 
            this.uxCount.Location = new System.Drawing.Point(149, 46);
            this.uxCount.Name = "uxCount";
            this.uxCount.Size = new System.Drawing.Size(78, 22);
            this.uxCount.TabIndex = 3;
            this.uxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uxMinDegree
            // 
            this.uxMinDegree.Location = new System.Drawing.Point(149, 12);
            this.uxMinDegree.Name = "uxMinDegree";
            this.uxMinDegree.Size = new System.Drawing.Size(78, 22);
            this.uxMinDegree.TabIndex = 4;
            this.uxMinDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxMinDegree.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxRank.Location = new System.Drawing.Point(93, 295);
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(294, 34);
            this.uxRank.TabIndex = 5;
            this.uxRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxName
            // 
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxName.Location = new System.Drawing.Point(102, 144);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(285, 34);
            this.uxName.TabIndex = 6;
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxFrequency.Location = new System.Drawing.Point(166, 255);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(221, 34);
            this.uxFrequency.TabIndex = 8;
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxNameLabel.Location = new System.Drawing.Point(12, 147);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(84, 29);
            this.uxNameLabel.TabIndex = 9;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxNumItemsLabel
            // 
            this.uxNumItemsLabel.AutoSize = true;
            this.uxNumItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uxNumItemsLabel.Location = new System.Drawing.Point(12, 50);
            this.uxNumItemsLabel.Name = "uxNumItemsLabel";
            this.uxNumItemsLabel.Size = new System.Drawing.Size(118, 18);
            this.uxNumItemsLabel.TabIndex = 10;
            this.uxNumItemsLabel.Text = "Number of Items";
            // 
            // uxMinLabel
            // 
            this.uxMinLabel.AutoSize = true;
            this.uxMinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uxMinLabel.Location = new System.Drawing.Point(9, 12);
            this.uxMinLabel.Name = "uxMinLabel";
            this.uxMinLabel.Size = new System.Drawing.Size(121, 18);
            this.uxMinLabel.TabIndex = 11;
            this.uxMinLabel.Text = "Minimum Degree";
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxFrequencyLabel.Location = new System.Drawing.Point(7, 258);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(139, 29);
            this.uxFrequencyLabel.TabIndex = 12;
            this.uxFrequencyLabel.Text = "Frequency: ";
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxRankLabel.Location = new System.Drawing.Point(7, 300);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(80, 29);
            this.uxRankLabel.TabIndex = 13;
            this.uxRankLabel.Text = "Rank: ";
            // 
            // NameLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 351);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxMinLabel);
            this.Controls.Add(this.uxNumItemsLabel);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxMinDegree);
            this.Controls.Add(this.uxCount);
            this.Controls.Add(this.uxLookup);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxMakeTree);
            this.Name = "NameLookup";
            this.Text = "B Trees";
            ((System.ComponentModel.ISupportInitialize)(this.uxCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinDegree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxMakeTree;
        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.Button uxLookup;
        private System.Windows.Forms.NumericUpDown uxCount;
        private System.Windows.Forms.NumericUpDown uxMinDegree;
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.Label uxNumItemsLabel;
        private System.Windows.Forms.Label uxMinLabel;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

