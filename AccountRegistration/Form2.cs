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
    public partial class FrmConfirm : Form
    {
        // Delegates
        private StudentInfoClass.DelegateText delProgram, delLastName, delFirstName, delMiddleName, delAddress;
        private StudentInfoClass.DelegateNumber delStudentNo, delContactNo, delAge;
        public FrmConfirm()
        {
            InitializeComponent();
            // Initialize delegates
            delProgram = new StudentInfoClass.DelegateText(StudentInfoClass.GetProgram);
            delLastName = new StudentInfoClass.DelegateText(StudentInfoClass.GetLastName);
            delFirstName = new StudentInfoClass.DelegateText(StudentInfoClass.GetFirstName);
            delMiddleName = new StudentInfoClass.DelegateText(StudentInfoClass.GetMiddleName);
            delAddress = new StudentInfoClass.DelegateText(StudentInfoClass.GetAddress);
            delStudentNo = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetStudentNo);
            delContactNo = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetContactNo);
            delAge = new StudentInfoClass.DelegateNumber(StudentInfoClass.GetAge);

            // Display data
            lblStudentNo.Text = delStudentNo(StudentInfoClass.StudentNo).ToString();
            lblProgram.Text = delProgram(StudentInfoClass.Program);
            lblLastName.Text = delLastName(StudentInfoClass.LastName);
            lblFirstName.Text = delFirstName(StudentInfoClass.FirstName);
            lblMiddleName.Text = delMiddleName(StudentInfoClass.MiddleName);
            lblAge.Text = delAge(StudentInfoClass.Age).ToString();
            lblContactNo.Text = delContactNo(StudentInfoClass.ContactNo).ToString();
            lblAddress.Text = delAddress(StudentInfoClass.Address);
        }

        private void Form2_Load(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
