using System;
using System.Windows.Forms;
using BLL;

namespace QLThuvien.GUI
{
    public partial class SachForm: Form
    {
        private SachBLL sachBLL = new SachBLL();
        public SachForm()
        {
            InitializeComponent();
            dataGridViewSach.CellClick += dataGridViewSach_CellClick;
            LoadData();
        }
        private void dataGridViewSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng chọn đúng hàng (không phải tiêu đề)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSach.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng được chọn vào các TextBox
                txtMasach.Text = row.Cells["Masach"].Value.ToString();
                txtTensach.Text = row.Cells["Tensach"].Value.ToString();
                txtChungloai.Text = row.Cells["Chungloai"].Value.ToString();
                txtManxb.Text = row.Cells["Manxb"].Value.ToString();
                txtMatacgia.Text = row.Cells["Matacgia"].Value.ToString();
                txtDongia.Text = row.Cells["Dongia"].Value.ToString();
                dtNgayXB.Value = Convert.ToDateTime(row.Cells["Ngayxb"].Value);

            }

        }
        private void LoadData()
        {
            dataGridViewSach.DataSource = sachBLL.GetAllSach();
        }
        private void FillData()
        {
            dataGridViewSach.DataSource = sachBLL.FillSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                sachBLL.AddSach(txtTensach.Text, txtChungloai.Text, int.Parse(txtManxb.Text),
                                int.Parse(txtMatacgia.Text), decimal.Parse(txtDongia.Text), dtNgayXB.Value);
                LoadData();
                MessageBox.Show("Thêm sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                sachBLL.UpdateSach(int.Parse(txtMasach.Text), txtTensach.Text, txtChungloai.Text,
                                   int.Parse(txtManxb.Text), int.Parse(txtMatacgia.Text),
                                   decimal.Parse(txtDongia.Text), dtNgayXB.Value);
                LoadData();
                MessageBox.Show("Cập nhật sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                sachBLL.DeleteSach(int.Parse(txtMasach.Text));
                LoadData();
                MessageBox.Show("Xóa sách thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnfill_Click(object sender, EventArgs e)
        {
            FillData();
        }
    }
}
