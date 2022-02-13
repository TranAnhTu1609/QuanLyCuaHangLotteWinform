using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangLotte.Models;

namespace QuanLyCuaHangLotte
{
    public partial class FormBaoCao : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        string TenNV;
        public FormBaoCao()
        {
            InitializeComponent();
        }
        public FormBaoCao(string TenNV)
        {
            InitializeComponent();
            this.TenNV = TenNV;
            loadData();
            loadCombobox();
        }
        private void loadData()
        {
            dgvBaoCao.Rows.Clear();
            var query = from bc in db.BaoCaos
                        select bc;
            if(query.Count() > 0)
            {
                foreach(var item in query)
                {
                    dgvBaoCao.Rows.Add(item.MaBc, item.TenNv, item.NgayLap, item.Loai, item.Mota);
                }
            }
        }
        public void exportExcelFile()
        {
            int rowIndex = 1;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excelApp.Application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            excelApp.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            worksheet.Name = "Phiếu nhập hàng";
            worksheet.get_Range("A1", "A1").Cells.Font.Size = 14;
            worksheet.Cells[rowIndex, 1] = "Công ty TNHH LOTTERIA VIỆT NAM";
            rowIndex++;
            worksheet.get_Range("A2", "A2").Cells.Font.Size = 14;
            excelApp.Cells[rowIndex, 1] = "03 Nguyễn Lương Bằng, F Tân Hưng, Q7";
            rowIndex++;

            worksheet.get_Range("A3", "A3").Cells.Font.Size = 14;
            excelApp.Cells[rowIndex, 1] = "(08) 5416107279";
            rowIndex++;
            
            Microsoft.Office.Interop.Excel.Range ten = worksheet.get_Range("B5", "B5");
            ten.Value2 = "Người lập phiếu: " + TenNV; ;
            ten.Font.Size = 12;
            ten.Font.Bold = true;
            ten.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range time = worksheet.get_Range("B6", "B6");
            time.Value2 = "Ngày tạo phiếu: " + DateTime.Now.ToString("dd/MM/yyyy");
            time.Font.Size = 12;
            time.Font.Bold = true;
            time.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("D4", "D4");
            head.Value2 = "Báo Cáo";
            head.Font.Size = 18;
            head.Font.Bold = true;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowIndex++;

            rowIndex++;

            Microsoft.Office.Interop.Excel.Range tieude = worksheet.Cells[rowIndex, 2];
            tieude.MergeCells = true;
            tieude.Font.Bold = true;
            tieude.Value2 = "Danh sách đơn:";
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range oRange = null;
            for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 2];
                oRange.Value2 = dgvBaoCao.Columns[i].HeaderText;
                oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange.Interior.ColorIndex = 6;
            }
            rowIndex++;

            for (int i = 0; i < dgvBaoCao.Rows.Count; i++)
            {

                for (int j = 0; j < dgvBaoCao.Columns.Count; j++)
                {
                    oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, j + 2];
                    oRange.NumberFormat = "@";
                    oRange.Value2 = dgvBaoCao[j, i].Value.ToString();
                    oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                rowIndex++;
            }
            Microsoft.Office.Interop.Excel.Range tdtTien = worksheet.Cells[rowIndex + 1, 5];
            tdtTien.MergeCells = true;
            tdtTien.Font.Bold = true;
            tdtTien.Value2 = "Tổng tiền:";
            tdtTien.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range tongT = worksheet.Cells[rowIndex + 1, 6];
            tongT.MergeCells = true;
            tongT.Value2 = "";
            tongT.Font.Bold = true;

            excelApp.Columns.AutoFit();
            excelApp.Visible = true;
        }
        private void loadCombobox()
        {
            cbbLoai.Items.Add("Xuất Hàng");
            cbbLoai.Items.Add("Nhập Hàng");
            cbbLoai.Items.Add("Hủy đơn");
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtpTruoc.Value.Date > dtpSau.Value.Date)
            {
                MessageBox.Show("Nhập ngày không hợp lệ","Thông báo");
            }
            else
            {
                dgvBaoCao.Rows.Clear();
                cbbLoai.SelectedItem = null;
                var query = from bc in db.BaoCaos
                            where bc.NgayLap >= dtpTruoc.Value.Date && bc.NgayLap<= dtpSau.Value.Date
                            select bc;
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        dgvBaoCao.Rows.Add(item.MaBc, item.TenNv, item.NgayLap, item.Loai, item.Mota);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy báo cáo bạn yêu cầu", "Thông báo");
                }

            }
        }

        private void cbbLoai_TextChanged(object sender, EventArgs e)
        {
            if (cbbLoai.Text == "")
            {
                loadData();
            }
            else
            {
                dgvBaoCao.Rows.Clear();
                var query = from bc in db.BaoCaos
                            where bc.Loai == cbbLoai.Text
                            select bc;
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        dgvBaoCao.Rows.Add(item.MaBc, item.TenNv, item.NgayLap, item.Loai, item.Mota);
                    }
                }
            }
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            loadData();
            cbbLoai.SelectedItem = null;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            exportExcelFile();
        }
    }
}
