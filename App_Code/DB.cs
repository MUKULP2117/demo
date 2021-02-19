using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB
{
    public DB()
    {
        //
        // TODO: Add constructor logic here
        //

       
    }

    public bool login_Validate(string userid, string pwd,string db_File)
    {
        bool is_valid = false;
        string qry = "select count(*) from users where user_id = '"+userid+"' and pwd = '"+pwd+"'";
        DataTable dt = get_dt(qry,db_File);
        if (dt != null && dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
            {
                is_valid = true;
            }
        }
        return is_valid;

    }

    public DataTable get_dt(string qry,string db_File)
    {
        DataTable dt = new DataTable();
        try
        {
            string sqlCon = @"Data Source=.\SQLEXPRESS; AttachDbFilename=" + db_File + "; Integrated Security=True; Connect Timeout=30; User Instance=True";
            SqlConnection Con = new SqlConnection(sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(qry, Con);
            da.Fill(dt);
        }
        catch(Exception ex) { }
        return dt;

    }
}