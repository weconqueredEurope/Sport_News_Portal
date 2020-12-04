using PasswordSecurity;
using ServicesWebDB.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    static class Connection
    {
        static string ConnectionString = @"Data Source=DESKTOP-3QME7JC;Initial Catalog=Sports_News;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        public static SqlConnection conn = new SqlConnection(ConnectionString);
    }
    public class DBServices : System.Web.Services.WebService
    {
        private SportModel db = new SportModel();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //Login
        [WebMethod]
        public int CheckLogin(string email, string pass)
        {
            ThanhVien tv = db.ThanhViens.SingleOrDefault(x => x.Email.Equals(email));
            CongTacVien ctv = db.CongTacViens.SingleOrDefault(x => x.Username.Equals(email));
            if (tv != null)
            {
                bool result = PasswordStorage.VerifyPassword(pass, tv.Password);
                if (result)
                {
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
                if (ctv != null)
                {
                    if (ctv.Password == pass)
                    {
                        return 2;
                    }
                    else return 0;
                }
                else
                {
                    return -1;
                }

                
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
        [WebMethod]
        public DataTable GetAccountCTV(string Username)
        {
            DataTable result = new DataTable("GetAccCTV");
            // Lấy dữ liệu
            string strCommand = @"select ctv.id,ctv.Username,ctv.Password,ctv.Roles_id,ctv.Ho,ctv.Ten,ctv.Email,ctv.SDT
                                    from CongTacVien ctv
                                    where ctv.Username = N'"+Username+"'";
            SqlCommand command = new SqlCommand(strCommand, Connection.conn);
            SqlDataAdapter Adapter = new SqlDataAdapter(command);
            Adapter.Fill(result);
            Adapter.Dispose();
            //Kết thúc lấy dữ liệu
            return result;
        }
        //Search
        [WebMethod]
        public int Search(string keyword)
        {
            var result = db.TinTucs.Where(x => x.TieuDe.Contains(keyword) || x.TacGia.Contains(keyword)).ToList();
            if (result.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        [WebMethod]
        public DataTable GetTT(string keyword)
        {
            DataTable result = new DataTable("GetTT");
            // Lấy dữ liệu
            string strCommand = @"Select tt.id,tt.idCM,tt.id_User,tt.TieuDe,tt.MoTa,
                                                    tt.NoiDung,tt.TacGia,tt.Thumbnails,tt.NgayDang,tt.Numread
                                  from TinTuc as tt
                                  where tt.TieuDe like N'%"+keyword+"%'";
            SqlCommand command = new SqlCommand(strCommand, Connection.conn);
            SqlDataAdapter Adapter = new SqlDataAdapter(command);
            Adapter.Fill(result);
            Adapter.Dispose();
            //Kết thúc lấy dữ liệu
            return result;
        }
    }
}
