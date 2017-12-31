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


       
    }
}
