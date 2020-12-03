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
        public static ThanhVien Convert(DataSet ds)
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
    }
}