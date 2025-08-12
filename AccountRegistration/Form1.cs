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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assign textbox/combobox values to static variables
            StudentInfoClass.Program = cboProgram.Text;
            StudentInfoClass.FirstName = txtFirstName.Text;
            StudentInfoClass.LastName = txtLastName.Text;
            StudentInfoClass.MiddleName = txtMiddleName.Text;
            StudentInfoClass.Address = txtAddress.Text;

            StudentInfoClass.Age = long.TryParse(txtAge.Text, out long age) ? age : 0;
            StudentInfoClass.ContactNo = long.TryParse(txtContactNo.Text, out long contact) ? contact : 0;
            StudentInfoClass.StudentNo = long.TryParse(txtStudentNo.Text, out long studNo) ? studNo : 0;

            // Open FrmConfirm as dialog
            FrmConfirm frm = new FrmConfirm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Registration confirmed!", "Success");
            }
        }
    }
}
