using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS385SC_HuaPhuMinhHieu_5649
{
    public partial class QLBanHang : System.Web.UI.MasterPage
    {
        DatabaseConnect db = new DatabaseConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string querry = "select * from DanhMuc";
            DataList1.DataSource = db.getData(querry);
            DataList1.DataBind();
            lblSoLuotTC.Text = Application["SoLuotTruyCap"].ToString();
            lblOnline.Text = Application["SLOnline"].ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string MaDanhMuc = ((LinkButton)sender).CommandArgument;
            Response.Redirect("SanPham.aspx?MaDanhMuc=" + MaDanhMuc);
        }
    }
}