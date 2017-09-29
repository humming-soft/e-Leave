using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using eleave_m;

namespace eleave_c
{
    public class bus_eleave
    {
        data_eleave data = new data_eleave();

        public string user_name { get; set; }
        public string password { get; set; }
        public int userid { get; set; }
        public int lid { get; set; }
        public int ltype { get; set; }
        public double rdays { get; set; }
        public string dates { get; set; }
        public int period { get; set; }
        public string med_path { get; set; }
        public string reason { get; set; }
        public string jobc { get; set; }
        public string contact { get; set; }
        public string event_name { get; set; }
        public DateTime event_date { get; set; }
        public string event_color { get; set; }

        public string name { get; set; }
        public string gender { get; set; }

        public DateTime doj { get; set; }
        public DateTime dob { get; set; }
        public int dep { get; set; }
        public int grade { get; set; }
        public int desi { get; set; }
        public int region { get; set; }
        public int id { get; set; }

        public string oldp { get; set; }
        public string newp { get; set; }
        public string add1 { get; set; }
        public string add2 { get; set; }
        public string mob { get; set; }
        public string email { get; set; }
        public string role { get; set; }
  //      public string region { get; set; }

        public int check_login()
        {
            return data.check_login(user_name, password);
        }

        public DataTable fetch_userdetails()
        {
            return data.fetch_userdetails(user_name);
        }
        public DataTable fetch_holidays()
        {
            return data.fetch_holidays(id);

        }
        public DataTable fetch_holidays_cal()
        {
            return data.fetch_holidays_cal(id);

        }
        public DataTable fetch_holidays1()
        {
            return data.fetch_holidays1(userid);

        }
        public DataTable fetch_holidaysma()
        {
            return data.fetch_holidaysma(userid);

        }
        public DataTable fetch_holidays_cochin()
        {
            return data.fetch_holidays_cochin(userid);

        }

        public DataTable fetch_leaves()
        {
            return data.fetch_leaves(userid);
        }

        public DataTable fill_grid()
        {
            return data.fill_grid(userid);
        }

        public DataTable fetch_download_leaves()
        {
            return data.fetch_download_leaves(lid);
        }

        public DataTable fetch_details()
        {
            return data.fetch_details(userid);
        }

        public DataTable fetch_leavetypes()
        {
            return data.fetch_leavetypes(userid);
        }

        public DataTable fetch_period()
        {
            return data.fetch_period();
        }

        public DataTable fetch_collegues()
        {
            return data.fetch_collegues(userid);
        }

        public int insert_med()
        {
            return data.insert_med(userid, ltype, dates, period, reason, rdays, jobc, contact, med_path);
        }

        public int insert_leave()
        {
            return data.insert_leave(userid, ltype, dates, period, reason, rdays, jobc, contact);
        }

        public int insert_oleave()
        {
            return data.insert_oleave(userid, ltype, dates, period, reason, rdays, jobc, contact);
        }

        public int cancel_leave()
        {
            return data.cancel_leave(lid);
        }

        public DataTable fill_user_approved_leaves()
        {
            return data.fill_user_approved_leaves(userid);
        }

        public int check_avail()
        {
            return data.check_avail(userid,ltype,rdays);
        }

        public int initiate_cancel()
        {
            return data.initiate_cancel(lid);
        }

        public int upload_holidays()
        {
            return data.upload_holidays(event_name,event_date,event_color);
        }

        public int upload_holidays_malaysia()
        {
            return data.upload_holidays_malaysia(event_name, event_date, event_color);
        }

        public DataTable fillgender()
        {
            return data.fillgender();
        }
        public DataTable filldep()
        {
            return data.filldep();
        }
        public int add_user()
        {
            return data.add_user(name,user_name,email,gender,doj,dob,dep,grade,desi,region);
        }
        public DataTable fetchdesignation()
        {
            return data.fetchdesignation(id);
        }
        public DataTable fetchgrade()
        {
            return data.fetchgrade(id);
        }
        public DataTable fillregion()
        {
            return data.fillregion();
        }

        public DataTable fetchdisdates()
        {
            return data.fetchdisdates();
        }

        public DataTable fillusers()
        {
            return data.fillusers();
        }

        public int deleteuser()
        {
            return data.deleteuser(id);
        }

        public DataTable fillleavesfr()
        {
            return data.fillleavesfr();
        }

        public DataTable fill_leaves_all()
        {
            return data.fill_leaves_all();
        }

        public int forward_leave()
        {
            return data.forward_leave(lid);
        }

        public int reject_leave()
        {
            return data.reject_leave(lid,userid,reason);
        }

        public int fetchalerts()
        {
            return data.fetchalerts();
        }

        public int fetchalerts_cancel()
        {
            return data.fetchalerts_cancel();
        }

        public int updatepwd()
        {
            return data.updatepwd(userid, oldp, newp);
        }

        public DataTable fill_details_user()
        {
            return data.fill_details_user(userid);
        }

        public int update_profile()
        {
            return data.update_profile(userid,add1,add2,mob);
        }

        public int oldpchk()
        {
            return data.oldpchk(userid,password);
        }

        public DataTable fillleavesapr()
        {
            return data.fillleavesapr();
        }

        public int approve_leave()
        {
            return data.approve_leave(lid,userid);
        }
        public int reject_leave_md()
        {
            return data.reject_leave_md(lid,userid,reason);
        }

        public DataTable fill_leaves_all_highcharts()
        {
            return data.fill_leaves_all_highcharts();
        }

        public int fetchalerts_md()
        {
            return data.fetchalerts_md();
        }
        public int fetchalerts_user()
        {
            return data.fetchalerts_user(userid);
        }

        public DataTable fillcancapprl()
        {
            return data.fillcancapprl();
        }

        public int reject_can_appr()
        {
            return data.reject_can_appr(lid);
        }

        public int cancel_all_approved()
        {
            return data.cancel_all_approved(lid);
        }

        public int cancel_av_approved()
        {
            return data.cancel_av_approved(lid,dates,rdays);
        }
        public int fetchalerts_md2()
        {
            return data.fetchalerts_md2();
        }
        public void change_stat()
        {
            data.change_stat(userid);
        }
        public DataTable fill_details_user_edit()
        {
            return data.fill_details_user_edit(id);
        }
        public int update_user()
        {
            return data.update_user(id,name, user_name, email,gender, doj, dep, grade, desi, region, dob);
        }

        public DataTable fillcflist() 
        {
            return data.fillcflist();
        }

        public int checkcf()
        {
            return data.checkcf();
        }

        public int cf()
        {
            return data.cf();
        }

        public DataTable fetch_leaves_taken()
        {
            return data.fetch_leaves_taken();
        }
        public DataTable fetch_leaves_balance()
        {
            return data.fetch_leaves_balance();
        }

        public DataTable fill_logs()
        {
            return data.fill_logs();
        }

        public DataTable fetch_mail_details()
        {
            return data.fetch_mail_details(role);
        }
        public DataTable fetch_mail_details_cancel()
        {
            return data.fetch_mail_details_cancel();
        }
        public DataTable fetch_mail_details_hr_apply()
        {
            return data.fetch_mail_details_hr_apply(role);
        }

        public int checkusername()
        {
            return data.checkusername(user_name);
        }
        public int checkemail()
        {
            return data.checkemail(email);
        }
        public int checkusername_edit()
        {
            return data.checkusername_edit(user_name,id);
        }
        public int checkemail_edit()
        {
            return data.checkemail_edit(email, id);
        }
        public DataTable fill_ldetails()
        {
            return data.fill_ldetails(lid);
        }
        public string fetch_details_edit()
        {
            return data.fetch_details_edit(id);
        }

        public int check_in_out()
        {
            return data.check_in_out(userid,ltype,rdays);
        }

        public int clear_holidays()
        {
            return data.clear_holidays();
        }
        public int clear_holidays_hs()
        {
            return data.clear_holidays_hs();
        }
        public DataTable fill_leves_appr_all()
        {
            return data.fill_leves_appr_all();
        }
    }
}
