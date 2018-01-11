using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public static class CurrentUser
    {
        private static vo_NhanVien user;

        public static vo_NhanVien User { get => user; set => user = value; }
    }
}
