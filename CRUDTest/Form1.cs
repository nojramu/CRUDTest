using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CRUDTest
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "server=localhost;database=student_db;uid=root;pwd=B@CKspaces4M;";
        private int? selectedStudentId = null;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateStudent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestConnectionAndLoadData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateStudent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateFieldsFromGridRow(e.RowIndex);
        }

        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            PopulateFieldsFromGridRow(e.RowIndex);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoadTableData()
        {
            string query = "SELECT id, student_no, full_name, course, year_level FROM students";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridView1.DataSource = null;
                            dataGridView1.Columns.Clear();
                            dataGridView1.AutoGenerateColumns = true;
                            dataGridView1.DataSource = dt;

                            if (dataGridView1.Columns.Contains("id"))
                            {
                                dataGridView1.Columns["id"].Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection or query error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TestConnectionAndLoadData()
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                }

                MessageBox.Show("Database connection successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateStudent()
        {
            string studentNo = textBox1.Text.Trim();
            string fullName = textBox2.Text.Trim();
            string courseName = textBox3.Text.Trim();
            string yearLevelText = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentNo) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(courseName) ||
                string.IsNullOrWhiteSpace(yearLevelText))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(yearLevelText, out int yearLevel))
            {
                MessageBox.Show("Year level must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string query = "INSERT INTO students (student_no, full_name, course, year_level) VALUES (@student_no, @full_name, @course, @year_level)";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@student_no", studentNo);
                    cmd.Parameters.AddWithValue("@full_name", fullName);
                    cmd.Parameters.AddWithValue("@course", courseName);
                    cmd.Parameters.AddWithValue("@year_level", yearLevel);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
                LoadTableData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Create failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudent()
        {
            if (!selectedStudentId.HasValue)
            {
                MessageBox.Show("Select a row first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentNo = textBox1.Text.Trim();
            string fullName = textBox2.Text.Trim();
            string courseName = textBox3.Text.Trim();
            string yearLevelText = textBox4.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentNo) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(courseName) ||
                string.IsNullOrWhiteSpace(yearLevelText))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(yearLevelText, out int yearLevel))
            {
                MessageBox.Show("Year level must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string query = "UPDATE students SET student_no = @student_no, full_name = @full_name, course = @course, year_level = @year_level WHERE id = @id";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@student_no", studentNo);
                    cmd.Parameters.AddWithValue("@full_name", fullName);
                    cmd.Parameters.AddWithValue("@course", courseName);
                    cmd.Parameters.AddWithValue("@year_level", yearLevel);
                    cmd.Parameters.AddWithValue("@id", selectedStudentId.Value);

                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();
                    if (affected == 0)
                    {
                        MessageBox.Show("No record updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                MessageBox.Show("Student updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteStudent()
        {
            if (!selectedStudentId.HasValue)
            {
                MessageBox.Show("Select a row first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Delete selected student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            const string query = "DELETE FROM students WHERE id = @id";

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedStudentId.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedStudentId = null;
                ClearInputFields();
                LoadTableData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFieldsFromGridRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }

            var row = dataGridView1.Rows[rowIndex];
            if (row.IsNewRow)
            {
                return;
            }

            if (row.Cells["id"].Value == null)
            {
                return;
            }

            selectedStudentId = Convert.ToInt32(row.Cells["id"].Value);
            textBox1.Text = row.Cells["student_no"].Value?.ToString() ?? string.Empty;
            textBox2.Text = row.Cells["full_name"].Value?.ToString() ?? string.Empty;
            textBox3.Text = row.Cells["course"].Value?.ToString() ?? string.Empty;
            textBox4.Text = row.Cells["year_level"].Value?.ToString() ?? string.Empty;
        }

        private void ClearInputFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
