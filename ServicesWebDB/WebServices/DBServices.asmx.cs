using PasswordSecurity;
using ServicesWebDB.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicesWebDB
{
    /// <summary>
    /// Summary description for DBServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DBServices : System.Web.Services.WebService
    {
        private SportModel db = new SportModel();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int CheckLogin(string email, string pass)
        {
            ThanhVien tv = db.ThanhViens.SingleOrDefault(x => x.Email.Equals(email));
            if (tv != null)
            {
                bool result = PasswordStorage.VerifyPassword(pass, tv.Password);
                if (result)
                {
                    //Session.Add("ThanhVien", tv);
                    return 1;
                }
                else
                {
                    //@ViewBag.error = "Mật khẩu không hợp lệ";

                    return 0;
                }
            }
            else
            {
                //@ViewBag.error = "Tài khoản không hợp lệ";

                return -1;
            }
        }
        [WebMethod]
        public DataSet GetAccount(string email)
        {
            DataSet ds = new DataSet();
            DataTable thanhVien = new DataTable("ThanhVien");
            DataColumn col1 = new DataColumn("id",typeof(int));
            DataColumn col2 = new DataColumn("Email", typeof(string));
            DataColumn col3 = new DataColumn("Password", typeof(string));
            DataColumn col4 = new DataColumn("Ho", typeof(string));
            DataColumn col5 = new DataColumn("Ten", typeof(string));
            DataColumn col6 = new DataColumn("NgayDK", typeof(DateTime));
            thanhVien.Columns.Add(col1);
            thanhVien.Columns.Add(col2);
            thanhVien.Columns.Add(col3);
            thanhVien.Columns.Add(col4);
            thanhVien.Columns.Add(col5);
            thanhVien.Columns.Add(col6);
            ///
            ThanhVien tv = db.ThanhViens.SingleOrDefault(x => x.Email.Equals(email));
            thanhVien.Rows.Add(tv.id,tv.Email,tv.Password,tv.Ho,tv.Ten,tv.NgayDK);
            ds.Tables.Add(thanhVien);
            return ds;
        }
    }
}
