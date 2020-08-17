using Library_Management_Project.Helper;
using Library_Management_Project.Model;
using System;
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
