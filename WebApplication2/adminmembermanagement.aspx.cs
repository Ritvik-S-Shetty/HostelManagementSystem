using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberById();

        }
        //Active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("active");
        }
        //Pending Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("pending");
        }
        //Deactive button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("deactive");
        }
        //Delete Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            deleteMemberById();
        }

        void getMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][0].ToString();
                    TextBox8.Text = dt.Rows[0][10].ToString();
                    TextBox7.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][3].ToString();
                    TextBox9.Text = dt.Rows[0][4].ToString();
                    TextBox10.Text = dt.Rows[0][5].ToString();
                    TextBox11.Text = dt.Rows[0][6].ToString();
                    TextBox6.Text = dt.Rows[0][7].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Member Id');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void updateMemberStatusById(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' where member_id='" + TextBox1.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");
                    clearform();


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member Id wrong');</script>");
            }

        }

        void deleteMemberById()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
                    clearform();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member Id wrong');</script>");
            }

        }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox8.Text = "";
            TextBox7.Text = "";
            TextBox3.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
            TextBox4.Text = "";
        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
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