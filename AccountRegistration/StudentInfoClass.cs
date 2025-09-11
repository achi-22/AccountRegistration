using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountRegistration
{
    public class StudentInfoClass
    {
        public delegate long DelegateNumber(long number);
        public delegate string DelegateText(string txt);

        public static string FirstName = "";
        public static string LastName = "";
        public static string MiddleName = "";
        public static string Program = "";
        public static long Age = 0;
        public static long ContactNo = 0;
        public static long StudentNo = 0;
        public static string Birthday = "";
        public static string Gender = "";

        // Properties (for database mapping)
        public long StudentNoProp { get => StudentNo; set => StudentNo = value; }
        public string FirstNameProp { get => FirstName; set => FirstName = value; }
        public string LastNameProp { get => LastName; set => LastName = value; }
        public string MiddleNameProp { get => MiddleName; set => MiddleName = value; }
        public string ProgramProp { get => Program; set => Program = value; }
        public long AgeProp { get => Age; set => Age = value; }
        public long ContactNoProp { get => ContactNo; set => ContactNo = value; }
        public string BirthdayProp { get => Birthday; set => Birthday = value; }
        public string GenderProp { get => Gender; set => Gender = value; }

        // Delegates
        public static string GetFirstName(string txt) => FirstName;
        public static string GetLastName(string txt) => LastName;
        public static string GetMiddleName(string txt) => MiddleName;
        public static string GetProgram(string txt) => Program;
        public static string GetBirthday(string txt) => Birthday;
        public static string GetGender(string txt) => Gender;

        public static long GetAge(long number) => Age;
        public static long GetContactNo(long number) => ContactNo;
        public static long GetStudentNo(long number) => StudentNo;
    }
}
