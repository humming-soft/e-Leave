using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Mail;

namespace eleave_view.user
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            //SendWebMail("smijith@hummingsoft.com.my", "Testing web mail", "blah blah blah blah", "agaile@hummingsoft.com.my", "jane@hummingsoft.com.my", "agaile@hummingsoft.com.my");
        }

        private bool SendWebMail(string strTo, string subj, string cont, string cc, string bcc, string strfrom)
        {
            bool flg1 = false;
            MailMessage msg = new MailMessage();
            msg.Body = cont;
            msg.From = strfrom;
            msg.To = strTo;
            msg.Subject = subj;
            msg.Cc = cc;
            msg.Bcc = bcc;
            msg.BodyFormat = MailFormat.Html;
            try
            {
                SmtpMail.SmtpServer = "175.143.44.165";
                SmtpMail.Send(msg);
                flg1 = true;
            }
            catch (Exception)
            {
                flg1 = false;
            }
            return flg1;
        }
    }
}