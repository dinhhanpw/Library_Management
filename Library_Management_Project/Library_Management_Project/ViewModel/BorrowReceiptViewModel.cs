using Library_Management_Project.Helper;
using Library_Management_Project.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
                Debug.WriteLine(selectedReader.PhieuMuons.GetHashCode());
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

        }

        private void OnAddBorrowedBook(GridViewRowEditEndedEventArgs args)
        {
            if (args.EditAction == GridViewEditAction.Cancel) return;

            if (args.EditOperationType == GridViewEditOperationType.Insert || args.EditOperationType == GridViewEditOperationType.Edit)
            {
                Sach newData = args.NewData as Sach;
                Sach editedItem = args.EditedItem as Sach;
                Sach book = Books.Where(obj => obj.Id == newData.Id).FirstOrDefault();

                Debug.WriteLine("Here");
                Debug.WriteLine(newData.GetHashCode());
                Debug.WriteLine(editedItem.GetHashCode());

                editedItem.Ten = book.Ten;
                editedItem.LoaiSach = book.LoaiSach;
                editedItem.TacGia = book.TacGia;
                editedItem.NamXB = book.NamXB;
                editedItem.NhaXB = book.NhaXB;
                editedItem.NgayNhap = book.NgayNhap;
                editedItem.SoLuong = book.SoLuong;
                editedItem.Gia = book.Gia;

                OnPropertyChanged(nameof(CanUserInsertRow));
            }
            //else if (args.EditOperationType == GridViewEditOperationType.Edit)
            //{
            //    Sach newData = args.NewData as Sach;
            //    Sach editedItem = args.EditedItem as Sach;
            //    Debug.WriteLine(newData.GetHashCode());
            //    Debug.WriteLine(editedItem.GetHashCode());
            //}
        }
    }
}
