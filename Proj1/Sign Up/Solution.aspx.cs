using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace Sign_Up
{
    public partial class Solution : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlDataReader STR3;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox4.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter Issue ID");
                TextBox4.Focus();
                return;
            }
            if (TextBox3.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter Issue Description");
                TextBox3.Focus();
                return;
            }
            if (TextBox2.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter the solution");
                TextBox2.Focus();
                return;
            }
            if (TextBox1.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter Date");
                TextBox1.Focus();
                return;
            }
            if (DropDownList1.Text == "")
            {
                WARSOFT.WARMsgBox.Show("please select the Status");
                DropDownList1.Focus();
                return;
            }
            string STR3 = " set dateformat dmy insert into issue(IssueID,IssueDescription,IssueSolution,Date,Status) values ('" + TextBox4.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "','" + TextBox1.Text + "', '" + DropDownList1.SelectedValue + "')";
            new WARTECHCONNECTION.cConnect().WriteDB(STR3);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully inserted');", true);
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            DropDownList1.Text = "";
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}