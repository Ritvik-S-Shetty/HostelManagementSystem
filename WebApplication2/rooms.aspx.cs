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

    public partial class rooms : System.Web.UI.Page
    {
        static string payment = "not done";
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillRoomValues();
            }

           // GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkStudentExists())
            {
                if (checkAlreadyBooked())
                {
                    Response.Write("<script>alert('You have already Booked a room!!');</script>");
                }
                else
                {
                    BookNewroom();
                }
            }
            else
            {
                Response.Write("<script>alert('Please Use correct StudentID');</script>");
            }
        }

        //payment
        protected void Button2_Click(object sender, EventArgs e)
        {
             payment = "done";
        }

        //user defined method

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        bool checkStudentExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from student_master_tbl where student_id='" + TextBox2.Text.Trim() + "';", con);
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

                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }
        void BookNewroom()
        {
            //Response.Write("<script>alert('Testing');</script>");
            
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO roombooking_tbl(full_name,student_id,contact_no,email,room,room_status,payment) values(@full_name,@student_id,@contact_no,@email,@room,@room_status,@payment)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@student_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@room", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@payment", payment);
                cmd.Parameters.AddWithValue("@room_status", "pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Booking pending Wait for admin to accept');</script>");
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void fillRoomValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT room_name from room_master_tblnew where room_status='pending';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //  DropDownList3.DataSource = dt;
                //  DropDownList3.DataValueField = "author_name";
                // DropDownList3.DataBind();

                // cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl;", con);
                //da = new SqlDataAdapter(cmd);
                //dt = new DataTable();
                //da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "room_name";
                DropDownList1.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        bool checkAlreadyBooked()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from roombooking_tbl where student_id='" + TextBox2.Text.Trim() + "';", con);
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

                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        
    }
}