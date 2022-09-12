using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //user login
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Please Use another MemberID');</script>");
            if (checkIfActive())
            {
                Response.Write("<script>alert('Login Successfull');</script>");
                login();


            }
            else
            {
                Response.Write("<script>alert('Sorry!! Your Account is still not Active,Wait for Admin to do it');</script>");

            }

        }

        void login()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        // if (dr.GetValue(10).ToString() == "active")
                        // {
                        Response.Write("<script>alert('Login Successful');</script>");
                        Session["username"] = dr.GetValue(8).ToString();
                        Session["fullname"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(10).ToString();
                        // }
                        //else
                        //{
                        // Response.Write("<script>alert('Sorry!! Your Account is still not Active');</script>");

                        //}
                    }
                    Response.Redirect("homepage.aspx");
                }

                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }

            }


            catch (Exception ex)
            {


            }
        }

        bool checkIfActive()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "' AND account_status='active';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

    }
}