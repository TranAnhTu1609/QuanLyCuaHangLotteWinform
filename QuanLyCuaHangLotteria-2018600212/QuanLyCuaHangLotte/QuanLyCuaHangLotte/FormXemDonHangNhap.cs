using System;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangLotte.Models;

namespace QuanLyCuaHangLotte
{
    public partial class FormXemDonHangNhap : Form
    {
        QuanLyCuaHangLotteContext db = new QuanLyCuaHangLotteContext();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        string TenNv;
        int MaHdk;
        
        public FormXemDonHangNhap()
        {
            InitializeComponent();
        }
        public FormXemDonHangNhap(string TenNv,int Ma)
        {
            InitializeComponent();
            this.TenNv = TenNv;
            this.MaHdk = Ma;
            
            lblMahdk.Text = Ma.ToString();
            labelTenNV.Text = TenNv;
            LoadNgay();
            LoadData();
            TinhTien();
        }
        private void LoadData()
        {
            dgvNLDat.Rows.Clear();
            dgvNLDat.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvNLDat.Columns["Soluong"].DefaultCellStyle.Format = "N0";
            dgvNLDat.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            var query = from hdk in db.CthoaDonKhos
                        where hdk.MaHdk == MaHdk
                        select new
                        {
                            hdk.MaNl,
                            hdk.SoLuong,
                            hdk.MaNlNavigation.DonGia,
                            hdk.MaNlNavigation.TenNl
                        };
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    dgvNLDat.Rows.Add(item.MaNl, item.TenNl, item.SoLuong, item.DonGia, item.SoLuong * item.DonGia);
                }
            }
        }
        private void LoadNgay()
        {
            var ngay =db.HoaDonKhos.FirstOrDefault(x=>x.MaHdk==MaHdk);
            if (ngay != null)
            {
                labelNgayTao.Text = ngay.NgayCc.ToString("dd/MM/yyyy");
            }
        }
        private void TinhTien()
        {
            int tt = 0;
            if (dgvNLDat.RowCount > -1)
            {
                for (int i = 0; i < dgvNLDat.RowCount; i++)
                {
                    tt += int.Parse(dgvNLDat.Rows[i].Cells[4].Value.ToString());
                }
                labelTongTien.Text = string.Format("{0:N0}", tt);
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
            worksheet.Cells[rowIndex, 1] = lblTenCongty.Text;
            rowIndex++;
            worksheet.get_Range("A2", "A2").Cells.Font.Size = 14;
            excelApp.Cells[rowIndex, 1] = lblDiaChi.Text;
            rowIndex++;

            worksheet.get_Range("A3", "A3").Cells.Font.Size = 14;
            excelApp.Cells[rowIndex, 1] = lblSdt.Text;
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("D4", "D4");
            head.Value2 = "PHIẾU NHẬP HÀNG";
            head.Font.Size = 18;
            head.Font.Bold = true;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range lableMaDH = worksheet.get_Range("D5", "D5");
            lableMaDH.MergeCells = true;
            lableMaDH.Value2 = "Mã hóa đơn: "+lblMahdk.Text;
            lableMaDH.Font.Bold = true;
            lableMaDH.Font.Size = 14;
            lableMaDH.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowIndex++;


            rowIndex++;

            Microsoft.Office.Interop.Excel.Range tieude = worksheet.Cells[rowIndex, 2];
            tieude.MergeCells = true;
            tieude.Font.Bold = true;
            tieude.Value2 = "Danh sách sản phẩm:";
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range oRange = null;
            for (int i = 0; i < dgvNLDat.Columns.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 2];
                oRange.Value2 = dgvNLDat.Columns[i].HeaderText;
                oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange.Interior.ColorIndex = 6;
            }
            rowIndex++;

            for (int i = 0; i < dgvNLDat.Rows.Count; i++)
            {

                for (int j = 0; j < dgvNLDat.Columns.Count; j++)
                {
                    oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, j + 2];
                    oRange.NumberFormat = "@";
                    oRange.Value2 = dgvNLDat[j, i].Value.ToString();
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
            tongT.Value2 = labelTongTien.Text.ToString().Replace('.', ',');
            tongT.Font.Bold = true;

            excelApp.Columns.AutoFit();
            excelApp.Visible = true;
        }

        private void xuatPDHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportExcelFile();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuấtPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SaveFileDialog luu = new SaveFileDialog();
            luu.Filter = "pdf files (*.pdf) |*.pdf";
            if (luu.ShowDialog() == DialogResult.OK)
            {
                string path = luu.FileName;
                ExportPdf(path);
                MessageBox.Show("Xuất file pdf thành công!");
            }
        }
        void ExportPdf(String strPdfPath)
        {
            // Đường dẫn tới file chứa font times news roman
            string timesTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.TTF");
            // Tạo đối tượng BaseFont
            BaseFont bf = BaseFont.CreateFont(timesTTF, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a specific font object
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 13);
            iTextSharp.text.Font fontNghien = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font fontBig = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            //tạo file    
            FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4);
            PdfWriter write = PdfWriter.GetInstance(document, fs);
            document.Open();

            #region subheader
            Paragraph prgCuahang = new Paragraph();
            prgCuahang.Alignment = Element.ALIGN_LEFT;
            prgCuahang.IndentationLeft = 5;
            prgCuahang.SpacingAfter = 5;
            prgCuahang.Add(new Chunk(lblTenCongty.Text, font));
            document.Add(prgCuahang);

            Paragraph prgCuahangdc = new Paragraph();
            prgCuahangdc.Alignment = Element.ALIGN_LEFT;
            prgCuahangdc.IndentationLeft = 5;
            prgCuahangdc.SpacingAfter = 5;
            prgCuahangdc.Add(new Chunk(lblDiaChi.Text, font));
            document.Add(prgCuahangdc);

            Paragraph prgCuahangSDT = new Paragraph();
            prgCuahangSDT.Alignment = Element.ALIGN_LEFT;
            prgCuahangSDT.IndentationLeft = 5;
            prgCuahangSDT.SpacingAfter = 5;
            prgCuahangSDT.Add(new Chunk(lblSdt.Text, font));
            document.Add(prgCuahangSDT);
            #endregion

            #region header

            Paragraph prgdh = new Paragraph();
            prgdh.Alignment = Element.ALIGN_CENTER;
            prgdh.SpacingAfter = 5;
            prgdh.Add(new Chunk(label1.Text, fontBig));
            document.Add(prgdh);

            Paragraph prgMdh = new Paragraph();
            prgMdh.Alignment = Element.ALIGN_CENTER;
            prgMdh.SpacingAfter = 5;
            prgMdh.Add(new Chunk(lblMahdk.Text, fontBold));
            document.Add(prgMdh);
            #endregion

            #region tên người lập
            Paragraph tnn = new Paragraph();
            tnn.Alignment = Element.ALIGN_LEFT;
            tnn.IndentationLeft = 25;
            tnn.SpacingBefore = 10;
            tnn.Add(new Chunk(string.Format("{0,-65}", label4.Text + " " + labelTenNV.Text), font));
            document.Add(tnn);
            #endregion

            #region ngày lập

            Paragraph pStt = new Paragraph();
            pStt.Alignment = Element.ALIGN_LEFT;
            pStt.SpacingAfter = 5;
            pStt.IndentationLeft = 25;
            pStt.SpacingBefore = 15;
            pStt.Add(new Chunk(string.Format("{0,-65}",label6.Text + " " + labelNgayTao.Text), font));
            document.Add(pStt);

            #endregion


            #region DataGridview
            PdfPTable table = new PdfPTable(dgvNLDat.Columns.Count);
            table.SpacingBefore = 30;
            table.WidthPercentage = 100;
            for (int i = 0; i < dgvNLDat.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.YELLOW;
                cell.AddElement(new Chunk(dgvNLDat.Columns[i].HeaderText, font));
                table.AddCell(cell);
            }

            for (int i = 0; i < dgvNLDat.Rows.Count; i++)
            {
                for (int j = 0; j < dgvNLDat.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dgvNLDat[j, i].Value.ToString(), font));
                    table.AddCell(cell);
                }

            }
            document.Add(table);
            #endregion

            #region tổng tiền
            Paragraph pTongtien = new Paragraph();
            pTongtien.Alignment = Element.ALIGN_RIGHT;
            pTongtien.SpacingAfter = 5;
            pTongtien.SpacingBefore = 15;
            pTongtien.Add(new Chunk(string.Format("{0}", label15.Text + " " + labelTongTien.Text), font));
            document.Add(pTongtien);


            #endregion

            document.Close();
            write.Close();
            fs.Close();
        }
    }
}
