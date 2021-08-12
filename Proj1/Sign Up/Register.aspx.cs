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
    public partial class Register : System.Web.UI.Page
    {
        System.Data.SqlClient.SqlDataReader STR1 ;
        //WARTECHCONNECTION.cConnect con7 = new WARTECHCONNECTION.cConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter name");
                TextBox1.Focus();
                return;
            }
            if (TextBox2.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter name");
                TextBox2.Focus();
                return;
            }
            if (TextBox3.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter email");
                TextBox3.Focus();
                return;
            }
            if (TextBox4.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please enter password");
                TextBox4.Focus();
                return;
            }
            if (DropDownList2.Text == "")
            {
                WARSOFT.WARMsgBox.Show("please select department");
                DropDownList2.Focus();
                return;
            }
            if (DropDownList1.Text == "")
            {
                WARSOFT.WARMsgBox.Show("Please select user");
                DropDownList1.Focus();
                return;
            }

           //string DR12 = " set dateformat dmy insert Into register " + "(firstname,lastname,email,password,department,person) values(@firstname,@lastname,@email,@password,@department,@person)");
            string STR1 = " set dateformat dmy insert into register(firstname,lastname,email,password,department,person) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "', '" + DropDownList2.Text + "','" + DropDownList1.SelectedValue + "')";
            new WARTECHCONNECTION.cConnect().WriteDB(STR1);
			ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Sucessfully inserted');", true);
           TextBox1.Text = "";
			TextBox2.Text = "";
			TextBox3.Text = "";
			TextBox4.Text = "";
            DropDownList2.Text = "";
            DropDownList1.Text = "";
            Response.Redirect("LOGIN.aspx");
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LOGIN.aspx");
        }
    }
}