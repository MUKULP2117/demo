using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string user_id = TextBox1.Text;
        string pwd = TextBox2.Text;
        Service db = new Service();
        try
        {
            if (db.login_validate(user_id, pwd))
            {
                Label1.Text = "Login success";
            }
            else { Label1.Text = "Login Fail"; }
        }
        catch (Exception ex) { Label1.Text = "Error - "+ex.Message; }
    }
}