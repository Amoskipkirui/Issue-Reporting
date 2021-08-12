using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sign_Up
{
    public partial class LOGIN : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlDataReader DR11, DR12, DR2, DR3, DR5, DR6, DR7, sql1;
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-U60GKLU;Initial Catalog=Issues;Integrated Security=True");
        WARTECHCONNECTION.cConnect con4 = new WARTECHCONNECTION.cConnect();
        WARTECHCONNECTION.cConnect con5 = new WARTECHCONNECTION.cConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           DR12 = con4.ReadDB("select count(*) from register where email='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'");
			if (DR12.HasRows)
				while (DR12.Read())
				{
					DR11 = con5.ReadDB("select person from  register where email='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'");
					if (DR11.HasRows)
						while (DR11.Read())
						{
							if (this.DR11["person"].ToString() == "Admin")
							{
								Session["mimi"] = TextBox1.Text;
								Response.Redirect("WebForm1.aspx");

							}
							else
							{
								Session["mimi"] = TextBox1.Text;
								Response.Redirect("WebForm2.aspx");
							}
						}
					//Session["mimi"] = TextBox1.Text;
					//Response.Redirect("IssueRegistration1.aspx");
				}
			else
			{
				ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Invalid Email or wrong password');", true);
			}


		}

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
	}

}
    