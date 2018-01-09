using System;
using System.Collections.Generic;
using System.Globalization;
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
        /// // chuyen doi VIET NAM sang sql
        public static String RevertDateType(String _date)
        {

            String[] date = _date.Split('-');
             
            return date[2] + "-" + date[1]+ "-" + date[0];
        }


        // chuyen doi VIET NAM sang SQL dd-MM-yyyy hh:mm to yyyy-mm-dd
        public static string VietNamToSql(string _date)
        {
            string[] dateTime = _date.Split(' ');
            if (dateTime.Length >= 2)
            {
                string date1 = dateTime[0];
                string time = dateTime[1];
                string[] detailTime = time.Split(':');
                string[] detailDate = date1.Split('-');
                string _sqlDate = detailDate[2] + "-" + detailDate[1] + "-" + detailDate[0] + " " + detailTime[0] + ":" + detailTime[1];
                return _sqlDate;
            }
            else
            {
                string date1 = dateTime[0];
                string[] detailDate = date1.Split('-');
                string _sqlDate = detailDate[2] + "-" + detailDate[1] + "-" + detailDate[0];
                return _sqlDate;
            }

        }


        public static string SqlSangVietNam(string _date)
        {

            return VietNamToSql(_date);
        }



        // chuyen doi VietNam sang .NET dd-MM-yyyy to mm-dd-yyyy
        public static string StandardTime(string _date)
        {
            string[] dateTime = _date.Split(' ');
            if(dateTime.Length >= 2)
            {
                string date1 = dateTime[0];
                string time = dateTime[1];
                string[] detailTime = time.Split(':');
                string[] detailDate = date1.Split('-');
                string _sqlDate = detailDate[1] + "-" + detailDate[0] + "-" + detailDate[2] + " " + detailTime[0] + ":" + detailTime[1];
                return _sqlDate;
            }
            else
            {
                string date1 = dateTime[0];
                string[] detailDate = date1.Split('-');
                string _sqlDate = detailDate[1] + "-" + detailDate[0] + "-" + detailDate[2];
                return _sqlDate;
            }
           
        }


        // chuyen doi datetime cua .NET sang Viet nam
        public static string DotNetToVietNam(string _date)
        {
            string[] dateTime = _date.Split(' ');
            if(dateTime.Length >= 2)
            {
                string date1 = dateTime[0];
                string time = dateTime[1];
                string[] detailTime = time.Split(':');
                string[] detailDate = date1.Split('/');
                string _sqlDate = detailDate[1] + "-" + detailDate[0] + "-" + detailDate[2] + " " + detailTime[0] + ":" + detailTime[1] + " " + dateTime[2];
                return _sqlDate;
            } 
            else
            {
                string date1 = dateTime[0];
                string[] detailDate = date1.Split('/');
                string _sqlDate = detailDate[1] + "-" + detailDate[0] + "-" + detailDate[2];
                return _sqlDate;
            }
            
        }

        /// <summary>
        /// DateTime date1 = new DateTime(2009, 8, 1, 0, 0, 0);
        //        DateTime date2 = new DateTime(2009, 8, 1, 12, 0, 0);
        //        int result = DateTime.Compare(date1, date2);
        //        string relationship;

        //if (result< 0)
        //   relationship = "is earlier than";
        //else if (result == 0)
        //   relationship = "is the same time as";         
        //else
        //   relationship = "is later than";

        //Console.WriteLine("{0} {1} {2}", date1, relationship, date2);
        /// </summary>
        /// <param name="_date1"></param>
        /// <param name="_date2"></param>
        /// <returns></returns>
        public static int CompareDateTime(string _date1, string _date2)
        {
            try
            {
                string stdDate1 = StandardTime(_date1) + " 00:00";
                DateTime _date11 = DateTime.Parse(stdDate1);

                string stdDate2 = StandardTime(_date2);
                DateTime _date22 = DateTime.Parse(stdDate2);

                int result = DateTime.Compare(_date11, _date22);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        

        
    }
}
