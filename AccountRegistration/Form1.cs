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
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtStudentNo.Text) ||
                    string.IsNullOrWhiteSpace(txtAge.Text) ||
                    string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    throw new ArgumentNullException("One or more required fields are empty.");
                }

                if (cbProgram.SelectedIndex < 0 || cbProgram.SelectedIndex >= cbProgram.Items.Count)
                    throw new IndexOutOfRangeException("Program selection is invalid.");
                if (cbGender.SelectedIndex < 0 || cbGender.SelectedIndex >= cbGender.Items.Count)
                    throw new IndexOutOfRangeException("Gender selection is invalid.");
                if (!long.TryParse(txtAge.Text.Trim(), out long age))
                    throw new FormatException("Age must be a valid number.");
                if (!long.TryParse(txtContactNo.Text.Trim(), out long contactNo))
                    throw new FormatException("Contact number must be a valid number.");
                if (!long.TryParse(txtStudentNo.Text.Trim(), out long studentNo))
                    throw new FormatException("Student number must be a valid number.");

                StudentInfoClass.Program = cbProgram.Text;
                StudentInfoClass.FirstName = txtFirstName.Text.Trim();
                StudentInfoClass.LastName = txtLastName.Text.Trim();
                StudentInfoClass.MiddleName = txtMiddleName.Text.Trim();
                StudentInfoClass.Age = age;
                StudentInfoClass.ContactNo = contactNo;
                StudentInfoClass.StudentNo = studentNo;
                StudentInfoClass.Birthday = datePickerBirtday.Value.ToShortDateString();
                StudentInfoClass.Gender = cbGender.Text;

                FrmConfirm frm = new FrmConfirm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DatabaseHelper.InsertStudent(new StudentInfoClass
                        {
                            StudentNoProp = StudentInfoClass.StudentNo,
                            FirstNameProp = StudentInfoClass.FirstName,
                            LastNameProp = StudentInfoClass.LastName,
                            MiddleNameProp = StudentInfoClass.MiddleName,
                            ProgramProp = StudentInfoClass.Program,
                            AgeProp = StudentInfoClass.Age,
                            ContactNoProp = StudentInfoClass.ContactNo,
                            BirthdayProp = StudentInfoClass.Birthday,
                            GenderProp = StudentInfoClass.Gender
                        });

                        MessageBox.Show("Student saved to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving student: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number entered is too large. Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (IndexOutOfRangeException iore)
            {
                MessageBox.Show(iore.Message, "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                MessageBox.Show(aoore.Message, "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        { }
    }
}
