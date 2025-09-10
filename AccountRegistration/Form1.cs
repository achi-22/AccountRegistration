using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountRegistration
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            cbProgram.Items.AddRange(new string[]
            {
                "BS Computer Science",
                "BS Information Technology",
                "BS Information Systems",
                "BS Software Engineering",
                "BS Data Science",
                "BS Civil Engineering",
                "BS Electrical Engineering",
                "BS Mechanical Engineering",
                "BS Architecture",
                "BS Accountancy",
                "BS Business Administration",
                "BS Marketing Management",
                "BS Psychology",
                "BS Nursing",
                "BS Medical Technology",
                "BS Pharmacy",
                "BS Biology",
                "BS Mathematics",
                "BA Communication",
                "BA Political Science",
                "BA Economics",
                "BA English Language Studies",
                "Bachelor of Elementary Education",
                "Bachelor of Secondary Education"
            });

            if (cbProgram.Items.Count > 0)
                cbProgram.SelectedIndex = 0;

            cbGender.Items.AddRange(new string[]
             {
                "Male",
                "Famale"
             });

            if (cbGender.Items.Count > 0)
                cbGender.SelectedIndex = 0;
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInfoClass.Program = cbProgram.Text;
                StudentInfoClass.FirstName = txtFirstName.Text;
                StudentInfoClass.LastName = txtLastName.Text;
                StudentInfoClass.MiddleName = txtMiddleName.Text;
                StudentInfoClass.Age = long.Parse(txtAge.Text);
                StudentInfoClass.ContactNo = long.Parse(txtContactNo.Text);
                StudentInfoClass.StudentNo = long.Parse(txtStudentNo.Text);
                StudentInfoClass.Birthday = datePickerBirtday.Text;
                StudentInfoClass.Gender = cbGender.Text;
            }
            catch (FormatException) {
                MessageBox.Show("Please type numbers only for student number, age, and contact number.", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number entered is too large. please enter valid number", "invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            



            FrmConfirm frm = new FrmConfirm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Registration confirmed!", "Success");

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Clear();
                    else if (ctrl is ComboBox)
                        ((ComboBox)ctrl).SelectedIndex = -1;
                }
            }

        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        { }
    }
}
