using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET1
{

    public partial class FormPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ListItem> listItems = new List<ListItem>();
            listItems.Add(new ListItem("BCA", "1"));
            listItems.Add(new ListItem("BSC", "2"));
            listItems.Add(new ListItem("BBS", "3"));
            listItems.Add(new ListItem("BBA", "4"));
            listItems.Add(new ListItem("BEC", "5"));

            academicListBox.Items.AddRange(listItems.ToArray());

            resultDiv.Style.Add("visibility", "hidden");
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string address = textAddress.Text;
            ListItem academicList = academicListBox.SelectedItem;
            string academic = academicList != null ? academicList.Text.ToString() : "";
            string gender;
            if (radioMale.Checked)
            {
                gender = radioMale.Text;
            }
            else
            {
                gender = radioFemale.Text;
            }
            resultDiv.Style.Add("visibility", "visible");
            if (consentCheck.Checked)
            {
                string result = $"Name: {name}<br/> Address: {address}<br/> Academic: {academic}<br/> Gender: {gender}";
                lblResult.Text = result;
            }
            else
            {
                lblResult.Text = "**Please accept the terms and conditions.";
            }


            Response.Redirect($"FormSubmitted.aspx?name={name}&address={address}&academic={academic}&gender={gender}");

        }
    }
}
