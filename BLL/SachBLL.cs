using System;
using System.Data;
using DAL;

namespace BLL
{
    public class SachBLL
    {
        private SachDAL sachDAL = new SachDAL();

        public DataTable GetAllSach()
        {
            return sachDAL.GetAllSach();
        }
        public DataTable FillSach()
        {
            return sachDAL.GetSachByTacGiaNXB();
        }

        public bool AddSach(string tensach, string chungloai, int manxb, int matacgia, decimal dongia, DateTime ngayxb)
        {
            if (dongia < 0)
                throw new Exception("Đơn giá không hợp lệ.");
            if (ngayxb > DateTime.Now)
                throw new Exception("Ngày xuất bản không hợp lệ.");

            return sachDAL.AddSach(tensach, chungloai, manxb, matacgia, dongia, ngayxb);
        }

        public bool UpdateSach(int masach, string tensach, string chungloai, int manxb, int matacgia, decimal dongia, DateTime ngayxb)
        {
            return sachDAL.UpdateSach(masach, tensach, chungloai, manxb, matacgia, dongia, ngayxb);
        }

        public bool DeleteSach(int masach)
        {
            return sachDAL.DeleteSach(masach);
        }
    }
}
