using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
    public class SachDAL
    {
        private Database db = new Database();

        public DataTable GetAllSach()
        {
            string query = "SELECT * FROM Sach";
            return db.ExecuteQuery(query);
        }

        public bool AddSach(string tensach, string chungloai, int manxb, int matacgia, decimal dongia, DateTime ngayxb)
        {
            string query = $"INSERT INTO Sach (Tensach, Chungloai, Manxb, Matacgia, Dongia, Ngayxb) VALUES " +
                           $"('{tensach}', '{chungloai}', {manxb}, {matacgia}, {dongia}, '{ngayxb:yyyy-MM-dd}')";
            return db.ExecuteNonQuery(query) > 0;
        }

        public bool UpdateSach(int masach, string tensach, string chungloai, int manxb, int matacgia, decimal dongia, DateTime ngayxb)
        {
            string query = $"UPDATE Sach SET Tensach='{tensach}', Chungloai='{chungloai}', " +
                           $"Manxb={manxb}, Matacgia={matacgia}, Dongia={dongia}, Ngayxb='{ngayxb:yyyy-MM-dd}' WHERE Masach={masach}";
            return db.ExecuteNonQuery(query) > 0;
        }

        public bool DeleteSach(int masach)
        {
            string query = $"DELETE FROM Sach WHERE Masach={masach}";
            return db.ExecuteNonQuery(query) > 0;
        }
        public DataTable GetSachByTacGiaNXB()
        {
            string query = "SELECT Sach.*"+
                            " FROM Sach"+
                            " JOIN Tacgia ON Sach.Matacgia = Tacgia.Matacgia"+
                            " JOIN Nhaxuatban ON Sach.Manxb = Nhaxuatban.Manxb"+
                            " WHERE Tacgia.Tentacgia = 'Phạm Văn Ất'"+
                            " AND Nhaxuatban.Tennxb = 'Giao thông vận tải'" ;
            return db.ExecuteQuery(query);
        }

    }
}


