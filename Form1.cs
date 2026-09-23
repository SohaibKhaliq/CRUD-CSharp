using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        public Form1()
        {
            InitializeComponent();
            con=Database.GetConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void load_students()
        {
            con.Open();
            string query = "SELECT * FROM students";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_students();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            string user_name = name.Text;
            string user_email = email.Text;
            string user_phone = phone.Text;
            string user_department = department.Text;

            // Task 1: Implement Restriction on Empty Fields

            con.Open();
            string query= "INSERT INTO students (name, email, phone, department) VALUES (@name, @email, @phone, @department)";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", user_name);
            cmd.Parameters.AddWithValue("@email", user_email);
            cmd.Parameters.AddWithValue("@phone", user_phone);
            cmd.Parameters.AddWithValue("@department", user_department);
            cmd.ExecuteNonQuery();
            // Task 2: Check how many rows were affected by the query and display a message box accordingly
            con.Close();
            MessageBox.Show("Student added successfully!");
            load_students();
        }
    }
}
