namespace AutoInstallWindowsServiceTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmeServiceRun = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServiceStop = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOPenNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBackupAll = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLocateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 2);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 340);
            this.listBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmeServiceRun,
            this.itemServiceStop,
            this.itemOPenNotepad,
            this.itemBackupAll,
            this.itemLocateFile});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 114);
            // 
            // itmeServiceRun
            // 
            this.itmeServiceRun.Name = "itmeServiceRun";
            this.itmeServiceRun.Size = new System.Drawing.Size(172, 22);
            this.itmeServiceRun.Text = "启动服务";
            this.itmeServiceRun.Click += new System.EventHandler(this.itmeServiceRun_Click);
            // 
            // itemServiceStop
            // 
            this.itemServiceStop.Name = "itemServiceStop";
            this.itemServiceStop.Size = new System.Drawing.Size(172, 22);
            this.itemServiceStop.Text = "停止服务";
            this.itemServiceStop.Click += new System.EventHandler(this.itemServiceStop_Click);
            // 
            // itemOPenNotepad
            // 
            this.itemOPenNotepad.Name = "itemOPenNotepad";
            this.itemOPenNotepad.Size = new System.Drawing.Size(172, 22);
            this.itemOPenNotepad.Text = "打开记事本";
            this.itemOPenNotepad.Click += new System.EventHandler(this.itemOPenNotepad_Click);
            // 
            // itemBackupAll
            // 
            this.itemBackupAll.Name = "itemBackupAll";
            this.itemBackupAll.Size = new System.Drawing.Size(172, 22);
            this.itemBackupAll.Text = "备份当前目录文件";
            this.itemBackupAll.Click += new System.EventHandler(this.itemBackupAll_Click);
            // 
            // itemLocateFile
            // 
            this.itemLocateFile.Name = "itemLocateFile";
            this.itemLocateFile.Size = new System.Drawing.Size(172, 22);
            this.itemLocateFile.Text = "打开所在的文件夹";
            this.itemLocateFile.Click += new System.EventHandler(this.itemLocateFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 354);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "安装";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 354);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "卸载";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 388);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动安装Windows服务程序（x86/x64）";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itmeServiceRun;
        private System.Windows.Forms.ToolStripMenuItem itemServiceStop;
        private System.Windows.Forms.ToolStripMenuItem itemOPenNotepad;
        private System.Windows.Forms.ToolStripMenuItem itemBackupAll;
        private System.Windows.Forms.ToolStripMenuItem itemLocateFile;
    }
}

