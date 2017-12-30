using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public class vo_LoaiHangHoa : PropertyChangedBase
    {
        private int id;
        private string name;

        public vo_LoaiHangHoa()
        {

        }
        public vo_LoaiHangHoa(int _id, string _name)
        {
            this.name = _name;
            this.id = _id;
        }
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    }
}
