using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_.Utilities
{
    public class Utilities
    {
        /// <summary>
        /// Convert YYYY-MM-DD to DD-MM-YYYY
        /// </summary>
        /// <returns></returns>
        public static String ConvertDateType(String date)
        {
            DateTime _date;
            _date = DateTime.Parse(date);
            return _date.ToString("dd-MM-yyyy");

        }

        /// <summary>
        /// Convert DD-MM-YYYY to YYYY-MM-DD
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String RevertDateType(String _date)
        {

            String[] date = _date.Split('-');
             
            return date[2] + "-" + date[1]+ "-" + date[0];
        }

        // convert datatime system to my datetime
        public static string StandardTime(string _date)
        {
            string[] dateTime = _date.Split(' ');
            string date1 = dateTime[0];
            string time = dateTime[1];
            string[] detailTime = time.Split(':');
            string[] detailDate = date1.Split('/');
            string _sqlDate = detailDate[2] + "-" + detailDate[0] + "-" + detailDate[1] + " " + detailTime[0] + ":" + detailTime[1];
            return _sqlDate;
        }


        public static string myTimeType(string _date)
        {
            string[] dateTime = _date.Split(' ');
            string date1 = dateTime[0];
            string time = dateTime[1];
            string[] detailTime = time.Split(':');
            string[] detailDate = date1.Split('/');
            string _sqlDate = detailDate[1] + "-" + detailDate[0] + "-" + detailDate[2] + " " + detailTime[0] + ":" + detailTime[1] + " " + dateTime[2];
            return _sqlDate;
        }
    }
}
