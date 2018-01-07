using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.bl_Utilities;
namespace BL.VO.HUY
{
   public class vo_ChucVu : PropertyChangedBase
    {
        private int id;
        private string chucVu;

        public vo_ChucVu()
        {

        }
        public vo_ChucVu(int _id, string _chucVu)
        {
            this.chucVu = _chucVu;
            this.id = _id;
        }
        public int Id
        {
            get { return id;  }
            set
            {
                if (id != value)
                    {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string ChucVu
        {
            get { return chucVu; }
            set
            {
                if (chucVu != value)
                {
                    chucVu = value;
                    OnPropertyChanged("ChucVu");
                }
            }
        }
    }
}
