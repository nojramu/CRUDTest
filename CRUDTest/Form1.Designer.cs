namespace CRUDTest
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
            Create = new Button();
            Read = new Button();
            Update = new Button();
            Delete = new Button();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            student_no = new DataGridViewTextBoxColumn();
            full_name = new DataGridViewTextBoxColumn();
            course = new DataGridViewTextBoxColumn();
            year_level = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Create
            // 
            Create.Location = new Point(152, 302);
            Create.Name = "Create";
            Create.Size = new Size(75, 23);
            Create.TabIndex = 0;
            Create.Text = "Create";
            Create.UseVisualStyleBackColor = true;
            Create.Click += button1_Click;
            // 
            // Read
            // 
            Read.Location = new Point(291, 302);
            Read.Name = "Read";
            Read.Size = new Size(75, 23);
            Read.TabIndex = 1;
            Read.Text = "Read";
            Read.UseVisualStyleBackColor = true;
            Read.Click += button2_Click;
            // 
            // Update
            // 
            Update.Location = new Point(425, 302);
            Update.Name = "Update";
            Update.Size = new Size(75, 23);
            Update.TabIndex = 2;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += button1_Click_1;
            // 
            // Delete
            // 
            Delete.Location = new Point(576, 302);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 3;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += button2_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AccessibleRole = AccessibleRole.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, student_no, full_name, course, year_level });
            dataGridView1.Location = new Point(205, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(586, 237);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.Name = "id";
            // 
            // student_no
            // 
            student_no.HeaderText = "student_no";
            student_no.Name = "student_no";
            // 
            // full_name
            // 
            full_name.HeaderText = "full_name";
            full_name.Name = "full_name";
            // 
            // course
            // 
            course.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            course.HeaderText = "course";
            course.Name = "course";
            // 
            // year_level
            // 
            year_level.HeaderText = "year_level";
            year_level.Name = "year_level";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(139, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(33, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(139, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(33, 177);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(139, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(33, 242);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(139, 23);
            textBox4.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 28);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 9;
            label1.Text = "Student ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 96);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 10;
            label2.Text = "Full Name";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 159);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 11;
            label3.Text = "Course";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 224);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 12;
            label4.Text = "Year Level";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 359);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(Delete);
            Controls.Add(Update);
            Controls.Add(Read);
            Controls.Add(Create);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Create;
        private Button Read;
        private Button Update;
        private Button Delete;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn student_no;
        private DataGridViewTextBoxColumn full_name;
        private DataGridViewTextBoxColumn course;
        private DataGridViewTextBoxColumn year_level;
    }
}
