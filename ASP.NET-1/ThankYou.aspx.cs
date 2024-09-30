using System;
using System.Web;
using System.Web.UI;

namespace ASP.NET1
{

    public partial class ThankYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["name"];
            string message = Request.QueryString["message"];

            string convertedName = name.ToUpper();

            if (!IsPostBack)
            {
                lblDisplayMessage.Text = $"Thank you, {convertedName}! " +
                    $"We have received your message:<br/><strong>{message}</strong>";
            }
        }

        protected void goBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}
