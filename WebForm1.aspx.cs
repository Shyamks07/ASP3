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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string Constring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack != true)
            {
                drop();
                show1();
            }

        }

        public void show1()
        {
            Class1 obj = new Class1();
            DataSet sh = new DataSet();
            sh=obj.show();
            GridView2.DataSource = sh;
            GridView2.DataBind();
        }


        public void drop()
        {
            DataSet ds = new DataSet();
            Class1 obj = new Class1();
            ds = obj.dow();
            this.DropDownList1.DataSource = ds.Tables[0];
            this.DropDownList1.DataTextField = "eid";
            this.DropDownList1.DataValueField = "eid";
            this.DropDownList1.DataBind();
            this.DropDownList1.Items.Insert(0, new ListItem("----select your employee id", "0"));
           
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt16(TextBox1.Text);
            string n = TextBox2.Text;
            double s = Convert.ToDouble(TextBox3.Text);
            Class1 ob = new Class1();
            ob.employeeid=a;
            ob.employename=n;
            ob.employesalary=s;
            ob.ins();
            show1();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string d = this.DropDownList1.Text.ToString();
            Class1 obj = new Class1();
            obj.employeeid = Convert.ToInt32(d);
            DataSet ds = new DataSet();
            ds = obj.view();
            GridView1.DataSource = ds;
            GridView1.DataBind(); 
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int d = Convert.ToInt16(TextBox4.Text);
            Class1 obj = new Class1();
            obj.employeeid = d;
            obj.tshow();
            this.TextBox5.Text = obj.employename;
            this.TextBox6.Text = obj.employesalary.ToString();
        }
    }
}