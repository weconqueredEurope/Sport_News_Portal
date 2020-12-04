using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing.Design;
using System.Linq;
using System.Web;

namespace Sport_News_Portal.Models
{
    public class ConvertToOBJ
    {
        public static ThanhVien Convert1(DataSet ds)
        {
            ThanhVien tv = new ThanhVien();
            DataRow rows = ds.Tables[0].Rows[0];
            tv.id = (int)rows["id"];
            tv.Email = (string)rows["Email"];
            tv.Password = (string)rows["Password"];
            tv.Ho = (string)rows["Ho"];
            tv.Ten = (string)rows["Ten"];
            tv.NgayDK = (DateTime)rows["NgayDK"];

            return tv;
        }
        public static List<TinTuc> Convert2(DataTable dt)
        {
            List<TinTuc> tt = new List<TinTuc>();
            foreach (DataRow rows in dt.Rows)
            {
                TinTuc tinTuc = new TinTuc();
                tinTuc.id = (int)rows["id"];
                tinTuc.idCM = (int)rows["idCM"];
                tinTuc.id_User = (int)rows["id_User"];
                tinTuc.TieuDe = (string)rows["TieuDe"];
                tinTuc.MoTa = (string)rows["MoTa"];
                tinTuc.NoiDung = (string)rows["NoiDung"];
                tinTuc.TacGia = (string)rows["TacGia"];
                tinTuc.Thumbnails = (string)rows["Thumbnails"];
                tinTuc.NgayDang = (DateTime)rows["NgayDang"];
                tinTuc.Numread = (int)rows["Numread"];
                tt.Add(tinTuc);
            }
            return tt;
        }
    }
}