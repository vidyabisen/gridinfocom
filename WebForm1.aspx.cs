using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication2AddressBook
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con;
        

        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ToString();

            con = new SqlConnection(connectionString);
            return con;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand("InsertAddress",con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure; 
                   // com.Parameters.AddWithValue("@id", Convert.ToInt32(TextBox1.Text));
                    com.Parameters.AddWithValue("@FName", TextBox2.Text);
                    com.Parameters.AddWithValue("@LName", TextBox3.Text);
                    com.Parameters.AddWithValue("@email", TextBox4.Text);
                    com.Parameters.AddWithValue("@PhoneNo", TextBox5.Text);
                    com.Parameters.AddWithValue("@Country", TextBox6.Text);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("Record inserted");
                    // Label1.Text = "Record inserted";
                    //@id,@FName,@LName,@email,@PhoneNo,@Country
                }
            }
        }

        protected void SerchAdd_btn(object sender, EventArgs e)
        {
            using (con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "select * from AddressBook where Address_ID=@id";
                    com.Connection = con;
                    com.Parameters.AddWithValue("@id", Convert.ToInt32(TextBox1.Text));
                    com.Connection = con;
                    con.Open();
                    GridView1.DataSource = com.ExecuteReader();
                    GridView1.DataBind();
                    con.Close();
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "delete from AddressBook where Address_ID=@id";
                    com.Connection = con;
                    com.Parameters.AddWithValue("@id",Convert.ToInt32(TextBox1.Text));
                    com.Connection = con;
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("Record deleted");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = "update AddressBook set LastName=@LName where Address_ID=@id";
                    com.Connection = con;
                    com.Parameters.AddWithValue("@id",Convert.ToInt32(TextBox1.Text));
                    com.Parameters.AddWithValue("@LName", TextBox3.Text);
                    com.Connection = con;
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("Record Updated");
                }
            }
        }
    }
}