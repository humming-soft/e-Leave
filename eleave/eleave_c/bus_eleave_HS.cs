using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using eleave_m;

namespace eleave_c
{
    
    public class bus_eleave_HS
    {
        data_eleave_HS obj=new data_eleave_HS();
        public int userid { get; set; }
        public int lid { get; set; }
        public string nwpwd { get; set; }
        public string cnf_nwpwd { get; set; }
        public string role { get; set; }
        // public struct name { get; set; }

        public DataTable fetch_collegues()
        {
            return obj.fetch_collegues(userid);
        }

        public DataTable fill_app_rej_hr()
        {
            return obj.fill_app_rej_hr();
        }

        public int reject_leave()
        {
            return obj.reject_leave(lid);
        }

        public int accept_leave()
        {
            return obj.accept_leave(lid);
        }

        public int checkold()
        {
            return obj.checkold(userid);
        }

        public int updatepwd()
        {
            return obj.updatepwd(userid, nwpwd, cnf_nwpwd);
        }

        public string file_hr()
        {
            return obj.file_hr(lid);
        }
        //public int approve_mul_hr()
        //{
        //    return obj.approve_mul_hr(lid);
        //}

        public DataTable fetch_mail_details_hr()
        {
            return obj.fetch_mail_details_hr();
        }
        public DataTable fetch_mail_details_cancel()
        {
            return obj.fetch_mail_details_cancel();
        }

        public DataTable fill_approvedleaves()
        {
            return obj.fill_approvedleaves();
        }

        public int forward_leave_appr()
        {
            return obj.forward_leave_appr(lid);
        }

        public DataTable fetch_mail_details_appr()
        {
            return obj.fetch_mail_details_appr();
        }

        public int forward_leave_rej()
        {
            return obj.forward_leave_rej(lid);
        }
        
    }
}
