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
            AddCommand = new RelayCommand<Sach>(CanAdd, OnAdd);
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
