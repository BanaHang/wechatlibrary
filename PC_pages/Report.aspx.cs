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

namespace LibraryDemo_1.PC_pages
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = SelectTable();
            this.GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.GridView1.DataSource = SelectTable();
            this.GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ExportToSpreadsheet(SelectTable(), "查询结果");
        }

        private DataTable SelectTable()     //gridview数据绑定
        {
            int index1 = this.DropDownList1.SelectedIndex;
            int index2 = this.DropDownList2.SelectedIndex;

            string sql1 = "select [ApplyBname] as [申购图书名称], [ApplyBwriter] as [申购图书作者], [ApplyBpublish] as [申购图书出版社] , [ApplyDate] as [申购时间] from [Library].[library].[Apply] where [ApplyDate] ";
            string sql2 = "select [BorrowRname] as [读者姓名], [BorrowRnum] as [读者学号/工号], [BorrowBname] as [图书名称], [BorrowBid] as [图书序号] from [Library].[library].[Borrow] where [BorrowDate] ";

            string datestr = " ";

            DataManage dm = new DataManage();
            DataTable dt = new DataTable();

            switch (index2)
            {
                case 0: datestr = "between '" + DateTime.Now.Year + "/1/1' and '" + DateTime.Now.Year + "/1/31'"; break;
                case 1: datestr = "between '" + DateTime.Now.Year + "/2/1' and '" + DateTime.Now.Year + "/2/29'"; break;
                case 2: datestr = "between '" + DateTime.Now.Year + "/3/1' and '" + DateTime.Now.Year + "/3/31'"; break;
                case 3: datestr = "between '" + DateTime.Now.Year + "/4/1' and '" + DateTime.Now.Year + "/4/30'"; break;
                case 4: datestr = "between '" + DateTime.Now.Year + "/5/1' and '" + DateTime.Now.Year + "/5/31'"; break;
                case 5: datestr = "between '" + DateTime.Now.Year + "/6/1' and '" + DateTime.Now.Year + "/6/30'"; break;
                case 6: datestr = "between '" + DateTime.Now.Year + "/7/1' and '" + DateTime.Now.Year + "/7/31'"; break;
                case 7: datestr = "between '" + DateTime.Now.Year + "/8/1' and '" + DateTime.Now.Year + "/8/31'"; break;
                case 8: datestr = "between '" + DateTime.Now.Year + "/9/1' and '" + DateTime.Now.Year + "/9/30'"; break;
                case 9: datestr = "between '" + DateTime.Now.Year + "/10/1' and '" + DateTime.Now.Year + "/10/31'"; break;
                case 10: datestr = "between '" + DateTime.Now.Year + "/11/1' and '" + DateTime.Now.Year + "/11/30'"; break;
                case 11: datestr = "between '" + DateTime.Now.Year + "/12/1' and '" + DateTime.Now.Year + "/12/31'"; break;
            }

            if (index1 == 0)
            {
                sql1 = sql1 + datestr;
                dt = dm.ReadTable(sql1);                
            }
            else
            {
                sql2 = sql2 + datestr;
                dt = dm.ReadTable(sql2);
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
    }
}