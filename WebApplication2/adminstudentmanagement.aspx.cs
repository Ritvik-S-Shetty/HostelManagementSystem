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
    public partial class adminstudentmanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfStudentExists())
            {
                Response.Write("<script>alert('Student with this ID already exists you cannot add another student whith the same ID');</script>");
            }
            else
            {
                addNewStudent();
            }
        }
        // update button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfStudentExists())
            {
                updateStudent();
            }
            else
            {
                Response.Write("<script>alert('Student isnt present');</script");

            }
        }

        // delete button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfStudentExists())
            {
                deleteStudent();
            }
            else
            {
                Response.Write("<script>alert('Student isnt present');</script");

            }
        }

        //Go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getStudentById();

        }

        //user defined function
        void getStudentById()
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
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    TextBox4.Text = dt.Rows[0][3].ToString();
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
        void addNewStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO student_master_tbl(student_id,student_name,student_year,student_dept) values(@student_id,@student_name,@student_year,@student_dept)", con);
                cmd.Parameters.AddWithValue("@student_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@student_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@student_year", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@student_dept", TextBox4.Text.Trim());



                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void updateStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='" + TextBox1.Text.Trim() + "'", con);
                SqlCommand cmd = new SqlCommand("UPDATE student_master_tbl SET student_name=@student_name, student_year=@student_year, student_dept=@student_dept  WHERE student_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@student_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@student_year", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@student_dept", TextBox4.Text.Trim());




                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }

        void deleteStudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from student_master_tbl WHERE student_id='" + TextBox1.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Student deleted Successfully');</script>");
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
            TextBox3.Text = "";
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