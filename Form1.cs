using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new StudentContext())
                {
                    var student = new Student
                    {
                        Name = txtName.Text,
                        Age = int.Parse(txtAge.Text),
                        Class = txtClass.Text
                    };
                    context.Students.Add(student);
                    context.SaveChanges();
                }

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudentData()
        {
            using (var context = new StudentContext())
            {
                dataGridView1.DataSource = context.Students.ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStudentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

    }
}
