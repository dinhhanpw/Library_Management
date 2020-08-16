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
    public class BookViewModel
    {
        private Sach selectedBook;

        public Sach SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (value == null) return;
                selectedBook = value;

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
        }

    }
}
