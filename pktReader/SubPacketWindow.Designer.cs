namespace pktReader
{
    partial class SubPacketWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subPacketList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subPacketCodeLabel = new System.Windows.Forms.Label();
            this.subTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCaptureToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openCaptureToolStripMenuItem
            // 
            this.openCaptureToolStripMenuItem.Name = "openCaptureToolStripMenuItem";
            this.openCaptureToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openCaptureToolStripMenuItem.Text = "Open Capture";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // subPacketList
            // 
            this.subPacketList.FormattingEnabled = true;
            this.subPacketList.Location = new System.Drawing.Point(12, 27);
            this.subPacketList.Name = "subPacketList";
            this.subPacketList.Size = new System.Drawing.Size(245, 407);
            this.subPacketList.TabIndex = 2;
            this.subPacketList.SelectedIndexChanged += new System.EventHandler(this.subPacketList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Possible Opcode Type:";
            // 
            // subPacketCodeLabel
            // 
            this.subPacketCodeLabel.AutoSize = true;
            this.subPacketCodeLabel.Location = new System.Drawing.Point(411, 26);
            this.subPacketCodeLabel.Name = "subPacketCodeLabel";
            this.subPacketCodeLabel.Size = new System.Drawing.Size(13, 13);
            this.subPacketCodeLabel.TabIndex = 10;
            this.subPacketCodeLabel.Text = "?";
            // 
            // subTextBox
            // 
            this.subTextBox.Location = new System.Drawing.Point(290, 201);
            this.subTextBox.Multiline = true;
            this.subTextBox.Name = "subTextBox";
            this.subTextBox.Size = new System.Drawing.Size(498, 233);
            this.subTextBox.TabIndex = 11;
            // 
            // SubPacketWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.subTextBox);
            this.Controls.Add(this.subPacketCodeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subPacketList);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SubPacketWindow";
            this.Text = "SubPacketWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox subPacketList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label subPacketCodeLabel;
        private System.Windows.Forms.TextBox subTextBox;
    }
}