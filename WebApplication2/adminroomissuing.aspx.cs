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
    public partial class adminroomissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getStudentById();

        }
        //Active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateRoomStatusById("active");
        }
        //Pending Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateRoomStatusById("pending");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Delete from roombooking_tbl where student_id='" + TextBox1.Text.Trim() + "';", con);
                cmd.ExecuteNonQuery();

                
                GridView1.DataBind();

                string statuss = "pending";
                cmd = new SqlCommand("UPDATE room_master_tblnew SET room_status='" + statuss + "' where room_name='" + TextBox7.Text.Trim() + "';", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Deleted Successfully');</script>");
                clearform();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }




        void getStudentById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from roombooking_tbl where student_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][0].ToString();
                    TextBox8.Text = dt.Rows[0][5].ToString();
                    TextBox7.Text = dt.Rows[0][4].ToString();
                    TextBox3.Text = dt.Rows[0][3].ToString();
                    //TextBox9.Text = dt.Rows[0][4].ToString();
                   // TextBox10.Text = dt.Rows[0][5].ToString();
                    //TextBox11.Text = dt.Rows[0][6].ToString();
                    //TextBox6.Text = dt.Rows[0][7].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Student Id');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void updateRoomStatusById(string status)
        {
            if (checkIfStudentExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE roombooking_tbl SET room_status='" + status + "' where student_id='" + TextBox1.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                  
                    GridView1.DataBind();

                    cmd = new SqlCommand("UPDATE room_master_tblnew SET room_status='" + status + "' where room_name='" + TextBox7.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Room Status Updated');</script>");
                    clearform();


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Student Id wrong');</script>");
            }

        }

     

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox8.Text = "";
            TextBox7.Text = "";
            TextBox3.Text = "";
           // TextBox9.Text = "";
           // TextBox10.Text = "";
           // TextBox11.Text = "";
           // TextBox6.Text = "";
            TextBox4.Text = "";
        }

        bool checkIfStudentExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='" + TextBox1.Text.Trim() + "';", con);
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
