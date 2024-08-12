using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack != true)
            {

                show1();
            }
        }

        public void show1()
        {
            Class1 obj = new Class1();
            DataSet sh = new DataSet();
            sh = obj.show();
            GridView1.DataSource = sh;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt16(TextBox1.Text);
            string n = TextBox2.Text;
            double s = Convert.ToDouble(TextBox3.Text);
            Class1 ob = new Class1();
            ob.employeeid = a;
            ob.employename = n;
            ob.employesalary = s;
            ob.ins();
            show1();
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            show1();
        }

        protected void updating(object sender, GridViewUpdateEventArgs e)
        {
            string Constring = ConfigurationManager.ConnectionStrings["employe"].ConnectionString;
            SqlConnection con = new SqlConnection(Constring);
            Label id = GridView1.Rows[e.RowIndex].FindControl("ID") as Label;
            TextBox name = GridView1.Rows[e.RowIndex].FindControl("Name") as TextBox;
            TextBox sal = GridView1.Rows[e.RowIndex].FindControl("salary") as TextBox;
            con = new SqlConnection(Constring);
            con.Open();
            int d = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand("upt", con);
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", d);
            cmd.Parameters.AddWithValue("@n", name.Text);
            cmd.Parameters.AddWithValue("@sal", Convert.ToDecimal(sal.Text));
            cmd.ExecuteNonQuery();
         
            con.Close();
            GridView1.EditIndex = -1;
            show1();


        }

        protected void del(object sender, GridViewDeleteEventArgs e)
        {



            try
            {

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            Response.Write(id.ToString());
           
            
             
              string Constring = ConfigurationManager.ConnectionStrings["employe"].ConnectionString;
              SqlConnection con = new SqlConnection(Constring);
              con.Open();
              SqlCommand cmd = new SqlCommand("dele", con);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@id", id);
              cmd.ExecuteNonQuery();
              show1();
          }
          catch (Exception p)
          {
              Response.Write(p.ToString());
          }
      }
        
            protected void cancel(object sender, GridViewCancelEditEventArgs e)
            {
                GridView1.EditIndex = -1;
                show1();
            }

        protected void updated(object sender, GridViewUpdatedEventArgs e)
        {

        }
    }
    }
