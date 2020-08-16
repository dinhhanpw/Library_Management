using Aspose.Cells;
using Library_Management_Project.Dialog;
using Library_Management_Project.Helper;
using Library_Management_Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library_Management_Project.ViewModel
{
    public class BookViewModel
    {
        private Sach selectedBook;

        public Sach SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                if (value == null) return;

                Holder.Ten = SelectedBook.Ten;
                Holder.IdLoai = SelectedBook.IdLoai;
                Holder.TacGia = SelectedBook.TacGia;
                Holder.NamXB = SelectedBook.NamXB;
                Holder.NhaXB = SelectedBook.NhaXB;
                Holder.NgayNhap = SelectedBook.NgayNhap;
                Holder.SoLuong = SelectedBook.SoLuong;
                Holder.Gia = SelectedBook.Gia;
            }
        }
        public Sach Holder { get; set; }
        public ObservableCollection<LoaiSach> BookTypes { get; set; }
        public ObservableCollection<Sach> Books { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExportCommand { get; set; }




        public BookViewModel()
        {
            Books = DataProvider.Instance.Books;
            BookTypes = DataProvider.Instance.BookTypes;
            Holder = new Sach();
            Holder.IdLoai = BookTypes[0].Id;
            AddCommand = new RelayCommand<Sach>(CanAdd, OnAdd);
            EditCommand = new RelayCommand<Sach>(CanEdit, OnEdit);
            DeleteCommand = new RelayCommand<Sach>(CanDelete, OnDelete);
            ExportCommand = new RelayCommand<Object>(obj => true, OnExport);
        }

        private void OnExport(object obj)
        {
            ExportReportDialog dialog = new ExportReportDialog();

            // mở hộp thoại để đặt các thông tin cần thiết
            if (dialog.ShowDialog() == true)
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                // lấy danh sách đọc giả theo tiêu chí đã chọn
                List<Sach> bookList =
                    new List<Sach>(DataProvider.Instance.DataBase.Saches.Where(reader => reader.NgayNhap >= dialog.From && reader.NgayNhap <= dialog.To));
                int row = 3;

                SetHeader(worksheet);

                // lưu thông tin đọc giả vào tập tin excel
                foreach (Sach book in bookList)
                {
                    SetValueOnRowWorksheet(worksheet, book, row++);
                }

                workbook.Save(dialog.FileName, SaveFormat.Xlsx);
            }
        }

        /// <summary>
        /// đặt các tiêu đề cột trong tập tin excel
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="row"></param>
        private void SetHeader(Worksheet worksheet, int row = 2)
        {
            char startCol = 'A';

            Cell cell = worksheet.Cells[$"{startCol}{row}"];
            cell.PutValue("STT");
            cell = worksheet.Cells[$"{(char)(startCol + 1)}{row}"];
            cell.PutValue("Tên Sách");
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue("Loại Sách");
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue("Ngày Nhập Sách");
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue("Tác Giả");
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue("Nhà Xuất Bản");
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue("Năm Xuất Bản");
            cell = worksheet.Cells[$"{(char)(startCol + 7)}{row}"];
            cell.PutValue("Số Lượng");
            cell = worksheet.Cells[$"{(char)(startCol + 8)}{row}"];
            cell.PutValue("Giá Sách");

        }

        /// <summary>
        /// lưu một đối tượng sách vào một hàng của tập tin excel
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="reader"></param>
        /// <param name="row"></param>
        /// <param name="startCol"></param>
        private void SetValueOnRowWorksheet(Worksheet worksheet, Sach reader, int row, char startCol = 'A')
        {

            Cell cell = worksheet.Cells[$"{(char)(startCol)}{row}"];
            cell.PutValue(row - 2);
            cell = worksheet.Cells[$"{(char)(startCol + 1)}{row}"];
            cell.PutValue(reader.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue(reader.LoaiSach.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue(reader.NgayNhap.Value.ToString("MM/dd/yyyy"));
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue(reader.TacGia);
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue(reader.NhaXB);
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue(reader.NamXB);
            cell = worksheet.Cells[$"{(char)(startCol + 7)}{row}"];
            cell.PutValue(reader.SoLuong);
            cell = worksheet.Cells[$"{(char)(startCol + 8)}{row}"];
            cell.PutValue(reader.Gia);
        }

        /// <summary>
        /// xóa thông tin sách khỏi danh sách
        /// </summary>
        /// <param name="obj"></param>
        private void OnDelete(Sach obj)
        {
            // hiển thị thông báo để xác nhận xóa
            MessageBoxResult result =
                MessageBox.Show("Các thông tin liên quan đến sách này cũng sẽ bị xóa, bạn có chấp nhận?",
                "Xóa Thông Tin Sách",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ObservableCollection<CTPhieuMuon> ReceiptInfos = DataProvider.Instance.BorrowReceiptInfos;

                foreach (CTPhieuMuon receiptInfo in SelectedBook.CTPhieuMuons)
                {
                    // ẩn thông tin sách mượn
                    receiptInfo.BiAn = true;
                    ReceiptInfos.Remove(receiptInfo);
                }

                // ẩn thông tin đọc giả
                SelectedBook.BiAn = true;
                Books.Remove(SelectedBook);
                // lưu các thay đổi
                DataProvider.Instance.DataBase.SaveChanges();
            }
        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép xóa thông tin sách
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanDelete(Sach obj)
        {
            return SelectedBook != null;
        }

        /// <summary>
        /// chỉnh sửa thông tin sách
        /// </summary>
        /// <param name="obj"></param>
        private void OnEdit(Sach obj)
        {
            // sao chép thông tin
            SelectedBook.Ten = Holder.Ten;
            SelectedBook.NgayNhap = Holder.NgayNhap;
            SelectedBook.IdLoai = Holder.IdLoai;
            SelectedBook.TacGia = Holder.TacGia;
            SelectedBook.NhaXB = Holder.NhaXB;
            SelectedBook.NamXB = Holder.NamXB;
            SelectedBook.SoLuong = Holder.SoLuong;
            SelectedBook.Gia = Holder.Gia;

            DataProvider.Instance.DataBase.SaveChanges();
        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép chỉnh sửa thông tin sách
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanEdit(Sach obj)
        {
            return selectedBook != null && !Holder.HasErrors;
        }

        /// <summary>
        /// thêm thông tin sách
        /// </summary>
        /// <param name="obj"></param>
        private void OnAdd(Sach obj)
        {
            // tạo một sách mới với thông tin từ biểu mẫu
            Sach book = new Sach()
            {
                Ten = Holder.Ten,
                IdLoai = Holder.IdLoai,
                NgayNhap = Holder.NgayNhap,
                TacGia = Holder.TacGia,
                NhaXB = Holder.NhaXB,
                NamXB = Holder.NamXB,
                SoLuong = Holder.SoLuong,
                Gia = Holder.Gia,
            };

            // thêm vào cơ sở dữ liệu
            DataProvider.Instance.DataBase.Saches.Add(book);
            DataProvider.Instance.DataBase.SaveChanges();
            // thêm vào danh sách
            Books.Add(book);
        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép thêm thông tin sách
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAdd(Sach obj)
        {
            return Holder != null && !Holder.HasErrors;
        }
    }
}
