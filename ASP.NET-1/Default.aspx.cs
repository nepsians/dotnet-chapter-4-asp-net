using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ASP.NET1
{

    public partial class Default : System.Web.UI.Page
    {

        string connectionString = "datasource = localhost; port = 3306; username = root; password = root";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bca.studentinformation", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GvData.DataSource = dt;
                GvData.DataBind();
            }
        }

        private void ExecuteNonQuery(string commandText, MySqlParameter[] parameters)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(commandText, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool IsRegIdExist(string regId, int studentId)
        {
            string query = "SELECT COUNT(*) FROM bca.studentinformation WHERE reg_id = @RegId AND Id != @StudentId";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@RegId", regId);
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void ShowAlert(string title, string message, string type)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert",
                $"Swal.fire('{title}', '{message}', '{type}')", true);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string regId = RegId.Text;

            if (IsRegIdExist(regId, 0))
            {
                ShowAlert("Error", "Reg ID already exists. Please use a different ID.", "error");
                Reset();
            }
            else
            {
                string commandText = "INSERT INTO bca.studentinformation (reg_id, name, marks, address) VALUES(@RegId, @Name, @Marks, @Address)";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@Name", Name.Text),
                    new MySqlParameter("@RegId", regId),
                    new MySqlParameter("@Marks", Marks.Text),
                    new MySqlParameter("@Address", Address.Text)
                };

                ExecuteNonQuery(commandText, parameters);
                BindGridView();
                Reset();
                ShowAlert("Success", "Data inserted successfully!", "success");
            }
        }

        private void DeleteData(int studentId)
        {
            string commandText = "DELETE FROM bca.studentinformation WHERE Id = @StudentId";
            MySqlParameter[] parameters = { new MySqlParameter("@StudentId", studentId) };
            ExecuteNonQuery(commandText, parameters);
        }

        protected void GvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(GvData.DataKeys[e.RowIndex].Value);
            DeleteData(userId);
            BindGridView();
            ShowAlert("Success", "Data deleted successfully!", "success");
        }

        protected void GvData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvData.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CancelEditing();
        }

        private void UpdateData(int studentId, string regId, string name, string marks, string address)
        {
            string commandText = "UPDATE bca.studentinformation SET reg_id = @RegId, name = @Name, marks = @Marks, address = @Address WHERE Id = @StudentId";
            MySqlParameter[] parameters = {
                new MySqlParameter("@RegId", regId),
                new MySqlParameter("@Name", name),
                new MySqlParameter("@Marks", marks),
                new MySqlParameter("@Address", address),
                new MySqlParameter("@StudentId", studentId)
            };

            ExecuteNonQuery(commandText, parameters);
        }

        protected void Gvdata_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(GvData.DataKeys[e.RowIndex].Value);
            GridViewRow row = GvData.Rows[e.RowIndex];
            TextBox textRegId = (TextBox)row.Cells[1].Controls[0];
            TextBox textName = (TextBox)row.Cells[2].Controls[0];
            TextBox textMarks = (TextBox)row.Cells[3].Controls[0];
            TextBox textAddress = (TextBox)row.Cells[4].Controls[0];

            if (IsRegIdExist(textRegId.Text, userId))
            {
                ShowAlert("Error", "Reg ID already exists. Please use a different ID.", "error");
                return;
            }

            UpdateData(userId,textRegId.Text, textName.Text, textMarks.Text, textAddress.Text);
            CancelEditing();
            ShowAlert("Success", "Data updated successfully!", "success");
        }

        private void CancelEditing()
        {
            GvData.EditIndex = -1;
            BindGridView();
        }

        protected void GvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvData.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        private void Reset()
        {
            Name.Text = RegId.Text = Marks.Text = Address.Text = string.Empty;
        }
    }
}
