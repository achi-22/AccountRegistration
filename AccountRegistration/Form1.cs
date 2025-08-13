using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountRegistration
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            cboProgram.Items.AddRange(new string[]
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

            if (cboProgram.Items.Count > 0)
                cboProgram.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInfoClass.Program = cboProgram.Text;
            StudentInfoClass.FirstName = txtFirstName.Text;
            StudentInfoClass.LastName = txtLastName.Text;
            StudentInfoClass.MiddleName = txtMiddleName.Text;
            StudentInfoClass.Address = txtAddress.Text;

            StudentInfoClass.Age = long.TryParse(txtAge.Text, out long age) ? age : 0;
            StudentInfoClass.ContactNo = long.TryParse(txtContactNo.Text, out long contact) ? contact : 0;
            StudentInfoClass.StudentNo = long.TryParse(txtStudentNo.Text, out long studNo) ? studNo : 0;

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
        {

        }
    }
}
