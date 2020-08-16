using Library_Management_Project.Helper;
using Library_Management_Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Management_Project.ViewModel
{
    public class BorrowReceiptViewModel
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
        public ObservableCollection<PhieuMuon> BorrowReceipts { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }
        public ObservableCollection<Sach> Books { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExportCommand { get; set; }




        public BorrowReceiptViewModel()
        {
            Readers = DataProvider.Instance.Readers;
            Books = DataProvider.Instance.Books;
            BorrowReceipts = DataProvider.Instance.BorrowReceipts;
            Holder = new Sach();
            Holder.IdLoai = BorrowReceipts[0].Id;

        }
    }
}
