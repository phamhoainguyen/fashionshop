using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public class vo_DangNhap : PropertyChangedBase
    {
        private string userName;
        private string password;
        private int idCV;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public int IdCV
        {
            get { return idCV; }
            set
            {
                if (idCV != value)
                {
                    idCV = value;
                    OnPropertyChanged("IdCV");
                }
            }
        }
    }
}
