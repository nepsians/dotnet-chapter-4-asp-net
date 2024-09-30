using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET1
{

    public partial class StudentFormApp : System.Web.UI.Page
    {
        // In-memory storage for students
        private static List<Student> students = new List<Student>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStudentGrid();
            }
        }

        protected void cvPhone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string phone = args.Value;


            // Validate if the phone number has exactly 10 digits
            if (phone.Length == 10 && long.TryParse(phone, out _)) // Ensure it contains only numbers
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string name = txtName.Text;
                int age;
                string email = txtEmail.Text;
                string phone = txtPhone.Text;

                if (string.IsNullOrEmpty(name) || !int.TryParse(txtAge.Text, out age) || string.IsNullOrEmpty(email))
                {
                    return;
                }

                students.Add(new Student { Name = name, Age = age, Email = email, PhoneNumber=phone });

                txtName.Text = string.Empty;
                txtAge.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtPhone.Text = string.Empty;

                BindStudentGrid();
            }
        }


        private void BindStudentGrid()
        {
            gvStudents.DataSource = students;
            gvStudents.DataBind();
        }

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0 && index < students.Count)
            {
                students.RemoveAt(index);
            }

            BindStudentGrid();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
