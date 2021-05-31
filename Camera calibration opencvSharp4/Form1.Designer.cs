
namespace Camera_calibration_opencvSharp4
{
    partial class CamCal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_img_path = new System.Windows.Forms.TextBox();
            this.b_img_path = new System.Windows.Forms.Button();
            this.b_save_image = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_text_nx = new System.Windows.Forms.Label();
            this.lbl_text_ny = new System.Windows.Forms.Label();
            this.nud_nx = new System.Windows.Forms.NumericUpDown();
            this.nud_ny = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_display = new System.Windows.Forms.GroupBox();
            this.b_read = new System.Windows.Forms.Button();
            this.b_mtx_path = new System.Windows.Forms.Button();
            this.lbl_text_mtx_path = new System.Windows.Forms.Label();
            this.b_calib = new System.Windows.Forms.Button();
            this.tb_mtx_path = new System.Windows.Forms.TextBox();
            this.pb_right = new System.Windows.Forms.PictureBox();
            this.pb_left = new System.Windows.Forms.PictureBox();
            this.b_connect = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_nx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ny)).BeginInit();
            this.gb_display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).BeginInit();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_img_path);
            this.groupBox2.Controls.Add(this.b_img_path);
            this.groupBox2.Controls.Add(this.b_save_image);
            this.groupBox2.Location = new System.Drawing.Point(291, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 79);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "image saving";
            // 
            // tb_img_path
            // 
            this.tb_img_path.Location = new System.Drawing.Point(6, 19);
            this.tb_img_path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_img_path.Name = "tb_img_path";
            this.tb_img_path.PlaceholderText = "Enter the path";
            this.tb_img_path.Size = new System.Drawing.Size(239, 23);
            this.tb_img_path.TabIndex = 8;
            this.tb_img_path.TextChanged += new System.EventHandler(this.tb_img_path_TextChanged);
            // 
            // b_img_path
            // 
            this.b_img_path.Location = new System.Drawing.Point(251, 19);
            this.b_img_path.Name = "b_img_path";
            this.b_img_path.Size = new System.Drawing.Size(26, 23);
            this.b_img_path.TabIndex = 11;
            this.b_img_path.Text = "...";
            this.b_img_path.UseVisualStyleBackColor = true;
            this.b_img_path.Click += new System.EventHandler(this.b_img_path_Click);
            // 
            // b_save_image
            // 
            this.b_save_image.Location = new System.Drawing.Point(6, 46);
            this.b_save_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.b_save_image.Name = "b_save_image";
            this.b_save_image.Size = new System.Drawing.Size(271, 26);
            this.b_save_image.TabIndex = 4;
            this.b_save_image.Text = "start to save images";
            this.b_save_image.UseVisualStyleBackColor = true;
            this.b_save_image.Click += new System.EventHandler(this.b_save_image_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_text_nx);
            this.groupBox1.Controls.Add(this.lbl_text_ny);
            this.groupBox1.Controls.Add(this.nud_nx);
            this.groupBox1.Controls.Add(this.nud_ny);
            this.groupBox1.Location = new System.Drawing.Point(90, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 84);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "chess pattern size";
            // 
            // lbl_text_nx
            // 
            this.lbl_text_nx.AutoSize = true;
            this.lbl_text_nx.Location = new System.Drawing.Point(6, 22);
            this.lbl_text_nx.Name = "lbl_text_nx";
            this.lbl_text_nx.Size = new System.Drawing.Size(85, 15);
            this.lbl_text_nx.TabIndex = 2;
            this.lbl_text_nx.Text = "num rows(NX)";
            // 
            // lbl_text_ny
            // 
            this.lbl_text_ny.AutoSize = true;
            this.lbl_text_ny.Location = new System.Drawing.Point(6, 45);
            this.lbl_text_ny.Name = "lbl_text_ny";
            this.lbl_text_ny.Size = new System.Drawing.Size(106, 15);
            this.lbl_text_ny.TabIndex = 2;
            this.lbl_text_ny.Text = "num columns(NY)";
            // 
            // nud_nx
            // 
            this.nud_nx.Location = new System.Drawing.Point(116, 17);
            this.nud_nx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_nx.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nud_nx.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_nx.Name = "nud_nx";
            this.nud_nx.Size = new System.Drawing.Size(62, 23);
            this.nud_nx.TabIndex = 3;
            this.nud_nx.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_nx.ValueChanged += new System.EventHandler(this.nud_nx_ValueChanged);
            // 
            // nud_ny
            // 
            this.nud_ny.Location = new System.Drawing.Point(116, 42);
            this.nud_ny.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_ny.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nud_ny.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_ny.Name = "nud_ny";
            this.nud_ny.Size = new System.Drawing.Size(62, 23);
            this.nud_ny.TabIndex = 3;
            this.nud_ny.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_ny.ValueChanged += new System.EventHandler(this.nud_ny_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(1061, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Blue: maximum area without distortion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1061, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Red: area lost by undistortion";
            // 
            // gb_display
            // 
            this.gb_display.Controls.Add(this.b_read);
            this.gb_display.Controls.Add(this.b_mtx_path);
            this.gb_display.Controls.Add(this.lbl_text_mtx_path);
            this.gb_display.Controls.Add(this.b_calib);
            this.gb_display.Controls.Add(this.tb_mtx_path);
            this.gb_display.Location = new System.Drawing.Point(579, 11);
            this.gb_display.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_display.Name = "gb_display";
            this.gb_display.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_display.Size = new System.Drawing.Size(476, 79);
            this.gb_display.TabIndex = 20;
            this.gb_display.TabStop = false;
            this.gb_display.Text = "calibration";
            // 
            // b_read
            // 
            this.b_read.Location = new System.Drawing.Point(303, 45);
            this.b_read.Name = "b_read";
            this.b_read.Size = new System.Drawing.Size(154, 26);
            this.b_read.TabIndex = 12;
            this.b_read.Text = "read matrix file";
            this.b_read.UseVisualStyleBackColor = true;
            this.b_read.Click += new System.EventHandler(this.b_read_Click);
            // 
            // b_mtx_path
            // 
            this.b_mtx_path.Location = new System.Drawing.Point(245, 50);
            this.b_mtx_path.Name = "b_mtx_path";
            this.b_mtx_path.Size = new System.Drawing.Size(26, 23);
            this.b_mtx_path.TabIndex = 11;
            this.b_mtx_path.Text = "...";
            this.b_mtx_path.UseVisualStyleBackColor = true;
            this.b_mtx_path.Click += new System.EventHandler(this.b_mtx_path_Click);
            // 
            // lbl_text_mtx_path
            // 
            this.lbl_text_mtx_path.AutoSize = true;
            this.lbl_text_mtx_path.Location = new System.Drawing.Point(4, 17);
            this.lbl_text_mtx_path.Name = "lbl_text_mtx_path";
            this.lbl_text_mtx_path.Size = new System.Drawing.Size(294, 30);
            this.lbl_text_mtx_path.TabIndex = 9;
            this.lbl_text_mtx_path.Text = "matrix file path\r\n(matrix will be saved  as BELOW_PATH\\mtxNdist.txt)";
            // 
            // b_calib
            // 
            this.b_calib.Location = new System.Drawing.Point(303, 14);
            this.b_calib.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.b_calib.Name = "b_calib";
            this.b_calib.Size = new System.Drawing.Size(154, 26);
            this.b_calib.TabIndex = 4;
            this.b_calib.Text = "make&&save matrixfile";
            this.b_calib.UseVisualStyleBackColor = true;
            this.b_calib.Click += new System.EventHandler(this.b_calib_Click);
            // 
            // tb_mtx_path
            // 
            this.tb_mtx_path.Location = new System.Drawing.Point(4, 50);
            this.tb_mtx_path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_mtx_path.Name = "tb_mtx_path";
            this.tb_mtx_path.PlaceholderText = "Enter the path";
            this.tb_mtx_path.Size = new System.Drawing.Size(235, 23);
            this.tb_mtx_path.TabIndex = 8;
            this.tb_mtx_path.TextChanged += new System.EventHandler(this.tb_mtx_path_TextChanged);
            // 
            // pb_right
            // 
            this.pb_right.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_right.Location = new System.Drawing.Point(665, 98);
            this.pb_right.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pb_right.Name = "pb_right";
            this.pb_right.Size = new System.Drawing.Size(600, 600);
            this.pb_right.TabIndex = 18;
            this.pb_right.TabStop = false;
            // 
            // pb_left
            // 
            this.pb_left.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_left.Location = new System.Drawing.Point(12, 98);
            this.pb_left.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pb_left.Name = "pb_left";
            this.pb_left.Size = new System.Drawing.Size(600, 600);
            this.pb_left.TabIndex = 19;
            this.pb_left.TabStop = false;
            // 
            // b_connect
            // 
            this.b_connect.Location = new System.Drawing.Point(12, 12);
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(72, 72);
            this.b_connect.TabIndex = 25;
            this.b_connect.Text = "Connect camera";
            this.b_connect.UseVisualStyleBackColor = true;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status});
            this.status.Location = new System.Drawing.Point(0, 710);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1288, 27);
            this.status.TabIndex = 26;
            this.status.Text = "hello";
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(220, 22);
            this.lbl_status.Text = "toolStripStatusLabel1";
            // 
            // CamCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 737);
            this.Controls.Add(this.status);
            this.Controls.Add(this.b_connect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_display);
            this.Controls.Add(this.pb_right);
            this.Controls.Add(this.pb_left);
            this.Name = "CamCal";
            this.Text = "CamCal";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_nx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ny)).EndInit();
            this.gb_display.ResumeLayout(false);
            this.gb_display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_left)).EndInit();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_img_path;
        private System.Windows.Forms.Button b_img_path;
        private System.Windows.Forms.Button b_save_image;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_text_nx;
        private System.Windows.Forms.Label lbl_text_ny;
        private System.Windows.Forms.NumericUpDown nud_nx;
        private System.Windows.Forms.NumericUpDown nud_ny;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_display;
        private System.Windows.Forms.Button b_read;
        private System.Windows.Forms.Button b_mtx_path;
        private System.Windows.Forms.Label lbl_text_mtx_path;
        private System.Windows.Forms.Button b_calib;
        private System.Windows.Forms.TextBox tb_mtx_path;
        private System.Windows.Forms.PictureBox pb_right;
        private System.Windows.Forms.PictureBox pb_left;
        private System.Windows.Forms.Button b_connect;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status;
    }
}

