using System;
using System.Data;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace ASP.NET1
{

    public partial class ListStudent : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;

        void CreateConnection()
        {
            string connectionString = "datasource = localhost; port = 3306; username = root; password = root";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CreateConnection();
                System.Diagnostics.Debug.WriteLine("Connected to database");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Failed to connected to database: " + ex);
            }
        }
        //void InsertUpdateDelete(string sqlQuery, int type)
        //{
        //    lblResult.Text = "";
        //    updateLblResult.Text = "";
        //    deleteLblResult.Text = "";

        //    try
        //    {
        //        command = new MySqlCommand(sqlQuery, connection);
        //        command.ExecuteNonQuery();

        //        if (type == 1)
        //            lblResult.Text = "*** Operation performed successfully!! ***";
        //        if (type == 2)
        //            updateLblResult.Text = "*** Operation performed successfully!! ***";
        //        if (type == 3)
        //            deleteLblResult.Text = "*** Operation performed successfully!! ***";

        //        SelectRecords();
        //    }
        //    catch
        //    {
        //        if (type == 1)
        //            lblResult.Text = "*** Error with DB operation!!! ***";
        //        if (type == 2)
        //            updateLblResult.Text = "*** Error with DB operation!!! ***";
        //        if (type == 3)
        //            deleteLblResult.Text = "*** Error with DB operation!!! ***";

        //    }
        //}

        void SelectRecords(string sql = "SELECT * FROM bca.studentinformation")
        {
            command = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //protected void submitButton_Click(object sender, EventArgs e)
        //{
        //    string regId = textRegId.Text;
        //    string firstName = textFirstName.Text;
        //    string lastName = textLastName.Text;

        //    string sql = "INSERT INTO bca.studentinformation (reg_id, name, address) VALUES (" + regId + ",'" + firstName + "','" + lastName + "')";

        //    InsertUpdateDelete(sql, 1);

        //}

        //protected void updateButton_Click(object sender, EventArgs e)
        //{
        //    string studentId = textStudentId.Text;
        //    string regId = updateTextRegId.Text;
        //    string firstName = updateTextFirstName.Text;
        //    string lastName = updateTextLastName.Text;

        //    string sql = "UPDATE college.students SET reg_id=" + regId + ",first_name='" + firstName + "',last_name='" + lastName + "' WHERE id=" + studentId + "";

        //    InsertUpdateDelete(sql, 2);

        //}

        //protected void deleteButton_Click(object sender, EventArgs e)
        //{
        //    string studentId = deleteStudentId.Text;

        //    string sql = "DELETE FROM college.students WHERE id=" + studentId;

        //    InsertUpdateDelete(sql, 3);

        //}

        protected void submitButton_Click1(object sender, EventArgs e)
        {
            SelectRecords();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
