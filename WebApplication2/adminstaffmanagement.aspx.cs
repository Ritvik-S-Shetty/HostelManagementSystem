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
    public partial class adminstaffmanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfStaffExists())
            {
                Response.Write("<script>alert('Staff with this ID already exists you cannot add another staff whith the same ID');</script>");
            }
            else
            {
                addNewStaff();
            }
        }

        // update button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfStaffExists())
            {
                updateStaff();
            }
            else
            {
                Response.Write("<script>alert('Staff isnt present');</script");

            }
        }

        // delete button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfStaffExists())
            {
                deleteStaff();
            }
            else
            {
                Response.Write("<script>alert('Staff isnt present');</script");

            }
        }

        //Go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getStaffById();

        }

        //user defined function
        void getStaffById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from staff_master_tbl where staff_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Staff Id');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void addNewStaff()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               
                SqlCommand cmd = new SqlCommand("INSERT INTO staff_master_tbl(staff_id,staff_name,staff_work) values(@staff_id,@staff_name,@staff_work)", con);
                cmd.Parameters.AddWithValue("@staff_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@staff_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@staff_work", TextBox3.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Staff added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void updateStaff()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='" + TextBox1.Text.Trim() + "'", con);
                SqlCommand cmd = new SqlCommand("UPDATE staff_master_tbl SET staff_name=@staff_name, staff_work=@staff_work WHERE staff_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@staff_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@staff_work", TextBox3.Text.Trim());



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Staff updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }

        void deleteStaff()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from staff_master_tbl WHERE staff_id='" + TextBox1.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Staff deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";

        }
        bool checkIfStaffExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from staff_master_tbl where staff_id='" + TextBox1.Text.Trim() + "';", con);
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
