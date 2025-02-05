namespace EsemkaVote
{
    partial class Form1
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            judul = new Label();
            subjudul = new Label();
            dataGridView1 = new DataGridView();
            reason = new Label();
            label2 = new Label();
            totalvote = new Label();
            persentase = new Label();
            panel2 = new Panel();
            name = new Label();
            panel3 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(124, 18);
            label1.TabIndex = 0;
            label1.Text = "SELECT VOTE EVENT";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(15, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(156, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // judul
            // 
            judul.Anchor = AnchorStyles.None;
            judul.AutoSize = true;
            judul.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            judul.Location = new Point(172, 6);
            judul.Name = "judul";
            judul.Size = new Size(180, 24);
            judul.TabIndex = 2;
            judul.Text = "Best Employe 2023";
            judul.Click += judul_Click;
            // 
            // subjudul
            // 
            subjudul.Anchor = AnchorStyles.None;
            subjudul.AutoSize = true;
            subjudul.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subjudul.Location = new Point(12, 31);
            subjudul.MaximumSize = new Size(500, 30);
            subjudul.MinimumSize = new Size(500, 48);
            subjudul.Name = "subjudul";
            subjudul.Size = new Size(500, 48);
            subjudul.TabIndex = 3;
            subjudul.Text = "Welcome to the Employee of the Year 2023 voting! Celebrate outstanding dedication and achievement by casting your vote for the most deserving nominee.";
            subjudul.TextAlign = ContentAlignment.MiddleCenter;
            subjudul.Click += label3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 349);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(896, 97);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // reason
            // 
            reason.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            reason.AutoSize = true;
            reason.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            reason.Location = new Point(3, 0);
            reason.Name = "reason";
            reason.Size = new Size(52, 17);
            reason.TabIndex = 6;
            reason.Text = "Reason";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(6, 26);
            label2.MinimumSize = new Size(300, 21);
            label2.Name = "label2";
            label2.Size = new Size(300, 21);
            label2.TabIndex = 8;
            label2.Text = "with";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // totalvote
            // 
            totalvote.Anchor = AnchorStyles.None;
            totalvote.AutoSize = true;
            totalvote.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalvote.Location = new Point(6, 63);
            totalvote.MinimumSize = new Size(300, 21);
            totalvote.Name = "totalvote";
            totalvote.Size = new Size(300, 21);
            totalvote.TabIndex = 12;
            totalvote.Text = "(31/50)";
            totalvote.TextAlign = ContentAlignment.MiddleCenter;
            totalvote.Click += totalvote_Click;
            // 
            // persentase
            // 
            persentase.Anchor = AnchorStyles.None;
            persentase.AutoSize = true;
            persentase.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            persentase.Location = new Point(6, 41);
            persentase.MinimumSize = new Size(300, 21);
            persentase.Name = "persentase";
            persentase.Size = new Size(300, 21);
            persentase.TabIndex = 13;
            persentase.Text = "60%";
            persentase.TextAlign = ContentAlignment.MiddleCenter;
            persentase.Click += persentase_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(subjudul);
            panel2.Controls.Add(judul);
            panel2.Location = new Point(204, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(525, 91);
            panel2.TabIndex = 14;
            panel2.Paint += panel2_Paint;
            // 
            // name
            // 
            name.Anchor = AnchorStyles.None;
            name.AutoSize = true;
            name.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            name.Location = new Point(6, 5);
            name.MinimumSize = new Size(300, 21);
            name.Name = "name";
            name.Size = new Size(300, 21);
            name.TabIndex = 15;
            name.Text = "Sophia";
            name.TextAlign = ContentAlignment.MiddleCenter;
            name.Click += name_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(name);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(totalvote);
            panel3.Controls.Add(persentase);
            panel3.Location = new Point(309, 259);
            panel3.Name = "panel3";
            panel3.Size = new Size(316, 84);
            panel3.TabIndex = 16;
            panel3.Paint += panel3_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(6, 35);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(887, 99);
            flowLayoutPanel1.TabIndex = 20;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.ErrorImage = Properties.Resources.Blank1;
            pictureBox1.Image = Properties.Resources.Blank1;
            pictureBox1.Location = new Point(416, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 134);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(reason);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(3, 462);
            panel1.Name = "panel1";
            panel1.Size = new Size(896, 134);
            panel1.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 598);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            MinimumSize = new Size(898, 521);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label judul;
        private Label subjudul;
        private DataGridView dataGridView1;
        private Label reason;
        private Label label2;
        private Label totalvote;
        private Label persentase;
        private Panel panel2;
        private Label name;
        private Panel panel3;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        private Panel panel1;
    }
}
