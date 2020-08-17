using Aspose.Cells;
using Library_Management_Project.Dialog;
using Library_Management_Project.Helper;
using Library_Management_Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace Library_Management_Project.ViewModel
{
    public class BorrowReceiptViewModel : BindableBase
    {

        private PhieuMuon selectedReceipt;
        private int maxNumberBook = 0;
        private DocGia selectedReader;

        public int MaxNumberBook
        {
            get { return maxNumberBook; }
            set
            {
                SetBindableProperty(ref maxNumberBook, value, nameof(MaxNumberBook));
                OnPropertyChanged(nameof(CanUserInsertRow));
            }
        }

        public bool CanUserInsertRow
        {
            get { return BorrowedBooks.Count < maxNumberBook; }
        }

        public DocGia SelectedReader
        {
            get { return selectedReader; }
            set
            {
                selectedReader = value;
                Holder.DocGia = selectedReader;
                if (selectedReader == null)
                {
                    MaxNumberBook = 0;
                    return;
                }
                MaxNumberBook = 5;

                // tính số lượng sách cho phép được mượn tối đa
                foreach (PhieuMuon receipt in selectedReader.PhieuMuons)
                {
                    MaxNumberBook -= receipt.CTPhieuMuons.Count(receiptInfo => receiptInfo.NgayTra == null);
                    if (maxNumberBook <= 0)
                    {
                        MaxNumberBook = 0;
                        break;
                    }
                }


            }
        }

        public PhieuMuon SelectedReceipt
        {
            get { return selectedReceipt; }
            set
            {
                selectedReceipt = value;
                if (value == null)
                {
                    return;
                }

                // tải thông tin sách mượn trong phiếu mượn
                Holder.IdDocGia = SelectedReceipt.IdDocGia;
                Holder.DocGia = SelectedReceipt.DocGia;
                Holder.NgayMuon = SelectedReceipt.NgayMuon;

                BorrowedBooks.Clear();
                foreach (CTPhieuMuon receiptInfo in SelectedReceipt.CTPhieuMuons)
                {
                    if (!receiptInfo.Sach.BiAn.Value)
                    {
                        BorrowedBooks.Add(receiptInfo.Sach);
                    }
                }

            }
        }

        public PhieuMuon Holder { get; set; }
        public ObservableCollection<PhieuMuon> BorrowReceipts { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }
        public ObservableCollection<Sach> Books { get; set; }
        public ObservableCollection<Sach> BorrowedBooks { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand AddBorrowedBookCommand { get; set; }




        public BorrowReceiptViewModel()
        {
            Readers = DataProvider.Instance.Readers;
            Books = DataProvider.Instance.Books;
            BorrowedBooks = new ObservableCollection<Sach>();
            BorrowReceipts = DataProvider.Instance.BorrowReceipts;
            Holder = new PhieuMuon();
            AddBorrowedBookCommand = new RelayCommand<GridViewRowEditEndedEventArgs>(arg => arg != null, OnAddBorrowedBook);
            AddCommand = new RelayCommand<PhieuMuon>(CanAdd, OnAdd);
            DeleteCommand = new RelayCommand<PhieuMuon>(CanDelete, OnDelete);
            ExportCommand = new RelayCommand<Object>(obj => true, OnExport);

        }

        /// <summary>
        /// xuất thông tin phiếu mượn đến tập tin excel
        /// </summary>
        /// <param name="obj"></param>
        private void OnExport(object obj)
        {
            ExportReportDialog dialog = new ExportReportDialog();

            // mở hộp thoại để đặt các thông tin cần thiết
            if (dialog.ShowDialog() == true)
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                // lấy danh sách đọc giả theo tiêu chí đã chọn
                List<PhieuMuon> bookList =
                    new List<PhieuMuon>(DataProvider.Instance.DataBase.PhieuMuons.Where(reader => reader.NgayMuon >= dialog.From && reader.NgayMuon <= dialog.To));
                int row = 3;

                SetHeader(worksheet);

                // lưu thông tin phiếu mượn vào tập tin excel
                foreach (PhieuMuon receipt in bookList)
                {
                    foreach (CTPhieuMuon receiptInfo in receipt.CTPhieuMuons)
                        SetValueOnRowWorksheet(worksheet, receiptInfo, row++);
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
            cell.PutValue("Tên Đọc Giả");
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue("Ngày Mượn");
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue("Tên Sách");
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue("Loại Sách");
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue("Tác Giả");
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue("Nhà Xuất Bản");
            cell = worksheet.Cells[$"{(char)(startCol + 7)}{row}"];
            cell.PutValue("Năm Xuất Bản");

        }

        /// <summary>
        /// lưu thông tin phiếu mượn vào một hàng của tập tin excel
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="receiptInfo"></param>
        /// <param name="row"></param>
        /// <param name="startCol"></param>
        private void SetValueOnRowWorksheet(Worksheet worksheet, CTPhieuMuon receiptInfo, int row, char startCol = 'A')
        {
            Cell cell = worksheet.Cells[$"{(char)(startCol)}{row}"];
            cell.PutValue(row - 2);
            cell = worksheet.Cells[$"{(char)(startCol + 1)}{row}"];
            cell.PutValue(receiptInfo.PhieuMuon.DocGia.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue(receiptInfo.PhieuMuon.NgayMuon.Value.ToString("MM/dd/yyyy"));
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue(receiptInfo.Sach.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue(receiptInfo.Sach.LoaiSach.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue(receiptInfo.Sach.TacGia);
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue(receiptInfo.Sach.NhaXB);
            cell = worksheet.Cells[$"{(char)(startCol + 7)}{row}"];
            cell.PutValue(receiptInfo.Sach.NamXB);


        }

        /// <summary>
        /// xóa thông tin phiếu mượn khỏi danh sách
        /// </summary>
        /// <param name="obj"></param>
        private void OnDelete(PhieuMuon obj)
        {
            // hiển thị thông báo để xác nhận xóa
            MessageBoxResult result =
                MessageBox.Show("Các thông tin liên quan đến đọc giả này cũng sẽ bị xóa, bạn có chấp nhận?",
                "Xóa Thông Tin Đọc Giả",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ObservableCollection<CTPhieuMuon> ReceiptInfos = DataProvider.Instance.BorrowReceiptInfos;

                // ẩn thông tin các sách mượn
                foreach (CTPhieuMuon receiptInfo in SelectedReceipt.CTPhieuMuons)
                {
                    receiptInfo.BiAn = true;
                    ReceiptInfos.Remove(receiptInfo);
                }

                // ẩn thông tin phiếu mượn
                SelectedReceipt.BiAn = true;
                BorrowReceipts.Remove(SelectedReceipt);

                DataProvider.Instance.DataBase.SaveChanges();

            }
        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép xóa thông tin phiếu mượn
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanDelete(PhieuMuon obj)
        {
            return SelectedReceipt != null;
        }

        /// <summary>
        /// thêm một phiếu mượn
        /// </summary>
        /// <param name="obj"></param>
        private void OnAdd(PhieuMuon obj)
        {
            // kiểm tra tính hợp lệ của sách mượn
            foreach (Sach book in BorrowedBooks)
            {
                DocGia reader = Holder.DocGia;
                // kiểm tra sách còn đủ số lượng để mượn
                if (book.SoLuong < 1)
                {
                    MessageBox.Show($"Số lượng sách {book.Ten} không đủ, không thể mượn!", "Mượn Sách", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // kiểm tra đọc giả có đang mượn những sách trong danh sách
                foreach (PhieuMuon rect in reader.PhieuMuons)
                {
                    try
                    {
                        // nếu không có thì ném một ngoại lệ
                        rect.CTPhieuMuons.First(info => info.IdSach == book.Id && info.NgayTra == null);
                        MessageBox.Show($"Đọc giả đang mượn sách {book.Ten}, không thể tiếp tục mượn!", "Mượn Sách", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    catch (InvalidOperationException ex)
                    {
                        break;
                    }
                }
            }

            // tạo phiếu mượn và lưu thông tin
            PhieuMuon receipt = new PhieuMuon()
            {
                IdDocGia = Holder.DocGia.Id,
                NgayMuon = Holder.NgayMuon,
            };

            // lưu vào cớ sở dữ liệu
            DataProvider.Instance.DataBase.PhieuMuons.Add(receipt);
            DataProvider.Instance.DataBase.SaveChanges();
            BorrowReceipts.Add(receipt);

            // thêm các sách mượn vào cớ sở dữ liệu
            foreach (Sach book in BorrowedBooks)
            {
                // tạo thông tin phiếu mượn
                CTPhieuMuon receiptInfo = new CTPhieuMuon()
                {
                    IdPhieuMuon = receipt.Id,
                    IdSach = book.Id
                };

                // giảm số lượng sách hiện tại
                Sach bk = DataProvider.Instance.Books.FirstOrDefault(arg => arg.Id == book.Id);
                bk.SoLuong--;
                // lưu vào cơ sở dữ liệu
                DataProvider.Instance.DataBase.CTPhieuMuons.Add(receiptInfo);
                DataProvider.Instance.BorrowReceiptInfos.Add(receiptInfo);
                Debug.WriteLine(receiptInfo.GetHashCode());
            }

            DataProvider.Instance.DataBase.SaveChanges();

        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép thêm phiếu mượn sách
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAdd(PhieuMuon obj)
        {
            return Holder != null
                && !Holder.HasErrors
                && BorrowedBooks.Count != 0
                && BorrowedBooks.Count <= MaxNumberBook;
        }

        /// <summary>
        /// thêm sách vào danh sách sách được mượn
        /// </summary>
        /// <param name="args"></param>
        private void OnAddBorrowedBook(GridViewRowEditEndedEventArgs args)
        {
            if (args.EditAction == GridViewEditAction.Cancel) return;

            if (args.EditOperationType == GridViewEditOperationType.Insert)
            {
                // lấy thông tin sách được thêm và kiểm tra đã tồn tại chưa
                Sach newData = args.NewData as Sach;
                if (BorrowedBooks.Count(bk => bk.Id == newData.Id) > 1)
                {
                    // loại bỏ nếu đã tồn tại
                    BorrowedBooks.Remove(newData);
                    return;
                }

                // tìm kiếm sách
                Sach editedItem = args.EditedItem as Sach;
                Sach book = Books.FirstOrDefault(obj => obj.Id == newData.Id);

                // sao chép thông tin
                editedItem.Id = book.Id;
                editedItem.Ten = book.Ten;
                editedItem.LoaiSach = book.LoaiSach;
                editedItem.TacGia = book.TacGia;
                editedItem.NamXB = book.NamXB;
                editedItem.NhaXB = book.NhaXB;
                editedItem.NgayNhap = book.NgayNhap;
                editedItem.SoLuong = book.SoLuong;
                editedItem.Gia = book.Gia;

                // thông báo đến giao diện để ngăn tiếp tục thêm nếu đã đạt số lượng tối đa
                OnPropertyChanged(nameof(CanUserInsertRow));
            }
        }
    }
}
