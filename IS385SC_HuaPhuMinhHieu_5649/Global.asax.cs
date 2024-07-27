using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace IS385SC_HuaPhuMinhHieu_5649
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();


            if (!System.IO.File.Exists(Server.MapPath("~/count.txt")))
                System.IO.File.WriteAllText(Server.MapPath("~/count.txt"), "0");


            Application["SoLuotTruyCap"] = int.Parse(System.IO.File.ReadAllText(Server.MapPath("~/count.txt")));
            Application.UnLock();

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["SoLuotTruyCap"] = (int)Application["SoLuotTruyCap"] + 1;

            System.IO.File.WriteAllText(Server.MapPath("~/count.txt"), Application["SoLuotTruyCap"].ToString());


            if (Application["SLOnline"] == null)
                Application["SLOnline"] = 1;
            else
                Application["SLOnline"] = (int)Application["SLOnline"] + 1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["SLOnline"] = (int)Application["SLOnline"] - 1;

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

    }
}