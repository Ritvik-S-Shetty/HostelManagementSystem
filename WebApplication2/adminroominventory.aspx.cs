using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class adminroominventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        //static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!IsPostBack)
            {
                fillStudentValues();
            }
            */
            GridView1.DataBind();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            getRoomById();
        }


        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateRoomByID();
        }
        // delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteRoomByID();
        }
        // add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfRoomExists())
            {
                Response.Write("<script>alert('Room ID Already Exists, try some other Room ID');</script>");
            }
            else
            {
                addNewRoom();
            }
        }



        // user defined functions   update

        void deleteRoomByID()
        {
            if (checkIfRoomExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from room_master_tblnew WHERE room_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Room Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Room ID');</script>");
            }
        }

        void updateRoomByID()
        {

            if (checkIfRoomExists())
            {
                try
                {

                   // int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    //int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                   

                    string equipments = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        equipments = equipments + ListBox1.Items[i] + ",";
                    }
                    equipments = equipments.Remove(equipments.Length - 1);

                    string filepath = "~/book_inventory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE room_master_tblnew set room_name=@room_name, equipments=@equipments, type=@type, room_description=@room_description, room_img_link=@room_img_link, room_status=@room_status  where room_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@room_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@equipments", equipments);
                  //  cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                 //   cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    //cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedItem.Value);
                 //   cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                  //  cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
                   // cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@room_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@room_status", TextBox3.Text.Trim());
                    // cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    // cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@room_img_link", filepath);



                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Room Updated Successfully');</script>");
                    clearForm();


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Room ID');</script>");
            }
        }
     

        void getRoomById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from room_master_tblnew WHERE room_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    TextBox2.Text = dt.Rows[0]["room_name"].ToString();
                  //  TextBox3.Text = dt.Rows[0]["publisher_date"].ToString();
                   
                    TextBox6.Text = dt.Rows[0]["room_description"].ToString();

                    TextBox3.Text = dt.Rows[0]["room_status"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["type"].ToString();
                   // DropDownList2.SelectedValue = dt.Rows[0]["student_name"].ToString();
                    //DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["equipments"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }
                    global_filepath = dt.Rows[0]["room_img_link"].ToString();



                }
                else
                {
                    Response.Write("<script>alert('Invalid Room Id');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        /*
        void fillStudentValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT student_name from student_master_tbl;", con);
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
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "student_name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
        */
        bool checkIfRoomExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from room_master_tblnew where room_id='" + TextBox1.Text.Trim() + "' OR room_name='" + TextBox2.Text.Trim() + "';", con);
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

        void addNewRoom()
        {
            try
            {
                string equipments = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    equipments = equipments + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
               equipments = equipments.Remove(equipments.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO room_master_tblnew(room_id,room_name,equipments,type,room_description,room_img_link,room_status) values(@room_id,@room_name,@equipments,@type,@room_description,@room_img_link,@room_status)", con);

                cmd.Parameters.AddWithValue("@room_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@room_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@equipments", equipments);
             //   cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
              //  cmd.Parameters.AddWithValue("@student_name", DropDownList2.SelectedItem.Value);
              //  cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedItem.Value);
              //  cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
               // cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
               // cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@room_description", TextBox6.Text.Trim());
               // cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
               // cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@room_img_link", filepath);

                cmd.Parameters.AddWithValue("@room_status", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Room added successfully.');</script>");
                GridView1.DataBind();
                clearForm();

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
            TextBox6.Text = "";
        }
    }


}
