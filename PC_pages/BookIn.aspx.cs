using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryDemo_1.App_Code;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace LibraryDemo_1.PC_pages
{
    public partial class BookIn : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["AdminName"] == null)
                {
                    Response.Redirect("./AdminLogin.aspx");
                }
                else
                {
                    DataTable table = new DataTable();
                    CreateTable(table);
                    DataRow row=table.NewRow();
                    table.Rows.Add(row);
                    GridviewBind(table);
                }
            }

        }
      
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.TextBox1.Text;
            string type = this.DropDownList1.SelectedItem.Text;
            string writer = this.TextBox2.Text;
            string publisher = this.TextBox3.Text;
            string num = this.TextBox4.Text;
            string price = this.TextBox5.Text;

            DataTable dt = getGridviewTable();
            DataRow dr = dt.NewRow();
            dr["Bname"] = name;
            dr["Btype"] = type;
            dr["Bwriter"] = writer;
            dr["Bpub"] = publisher;
            dr["Bnum"] = num;
            dr["Bprice"] = price;

            dt.Rows.Add(dr);

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = getGridviewTable();
            ExportToSpreadsheet(dt, "图书入库表");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile==false)
            {
                Response.Write("<script>alert('请先选择文件！')</script>");
            }
            else
            {
                string savePath = Server.MapPath("~/ExcelUpload/");
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                savePath = savePath + "\\" + FileUpload1.FileName;
                FileUpload1.SaveAs(savePath);
                
                DataSet ds = ExcelToDS(savePath);
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            DataTable dt = getGridviewTable();
            DataManage dm = new DataManage();

            //string insql = "insert into [Library].[library].[Book] ([Bname], [Btype],[Bwriter],[Bpublish],[Bamount],[Bprice]) VALUES('{0}','{1}','{2}','{3}',{4},{5})";

            int dtcount = dt.Rows.Count;

            for (int i = 0; i < dtcount;i++ )
            {
                string selectsql = "select * from [Library].[library].[Book] where [Bname] like '" + dt.Rows[i][0] + "' and [Bwriter] like '" + dt.Rows[i][2] + "'";
                int amount;
                DataTable table = dm.ReadTable(selectsql);
                if (table.Rows.Count > 0)
                {
                    amount = Convert.ToInt32(dt.Rows[i][4]) + (int)table.Rows[0][5];
                    string updatesql = "update [Library].[library].[Book] set [Bamount] =" + amount + "where [Bname] like '" + dt.Rows[i][0] + "' and [Bwriter] like '" + dt.Rows[i][2] + "'";
                    dm.ExecuteSql(updatesql);
                }
                else
                {
                    //insql = string.Format(insql, dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5]);
                    string insql = "insert into [Library].[library].[Book] ([Bname], [Btype],[Bwriter],[Bpublish],[Bamount],[Bprice]) VALUES('" + dt.Rows[i][0] + "','" + dt.Rows[i][1] + "','" + dt.Rows[i][2] + "','" + dt.Rows[i][3] + "'," + dt.Rows[i][4] + "," + dt.Rows[i][5] + ")";
                    dm.ExecuteSql(insql);
                }
            }

            Response.Write("<script>alert('导入成功！')</script>");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            DataTable dt = getGridviewTable();
            dt.Rows.RemoveAt(index);
            GridviewBind(dt);
        }

        public void CreateTable(DataTable dt) //新建datatable
        {
            dt.Columns.Add("Bname");
            dt.Columns.Add("Btype");
            dt.Columns.Add("Bwriter");
            dt.Columns.Add("Bpub");
            dt.Columns.Add("Bnum");
            dt.Columns.Add("Bprice");
        }

        public void GridviewBind(DataTable dt) //gridview绑定数据
        {
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        public DataTable getGridviewTable() //获取gridview数据
        {
            DataTable dt = new DataTable();
            CreateTable(dt);
            foreach(GridViewRow gvr in this.GridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["Bname"] = gvr.Cells[1].Text;
                dr["Btype"] = gvr.Cells[2].Text;
                dr["Bwriter"] = gvr.Cells[3].Text;
                dr["Bpub"] = gvr.Cells[4].Text;
                dr["Bnum"] = gvr.Cells[5].Text;
                dr["Bprice"] = gvr.Cells[6].Text;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static void ExportToSpreadsheet(DataTable table, string name)  //报表导出
        {
            Random r = new Random();
            string rf = "";
            for (int j = 0; j < 10; j++)
            {
                rf = r.Next(int.MaxValue).ToString();
            }

            HttpContext context = HttpContext.Current;
            context.Response.Clear();

            context.Response.ContentType = "application/ms-excel";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + rf + ".xls");
            context.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

            foreach (DataColumn column in table.Columns)
            {
                context.Response.Write(column.ColumnName + ",");
            }

            context.Response.Write(Environment.NewLine);
            double test;

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    switch (table.Columns[i].DataType.ToString())
                    {
                        case "System.String":
                            if (double.TryParse(row[i].ToString(), out test)) context.Response.Write("=");
                            context.Response.Write("\"" + row[i].ToString().Replace("\"", "\"\"") + "\",");
                            break;
                        case "System.DateTime":
                            if (row[i].ToString() != "")
                                context.Response.Write("\"" + ((DateTime)row[i]).ToString("yyyy-MM-dd hh:mm:ss") + "\",");
                            else
                                context.Response.Write("\"" + row[i].ToString().Replace("\"", "\"\"") + "\",");
                            break;
                        default:
                            context.Response.Write("\"" + row[i].ToString().Replace("\"", "\"\"") + "\",");
                            break;
                    }
                }
                context.Response.Write(Environment.NewLine);
            }

            context.Response.End();

        }

        public static DataSet ExcelToDS(string Path)  //报表导入
        {
            string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", Path); 
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            myCommand.Dispose();
            conn.Close();
            return ds;
        }

    }
}