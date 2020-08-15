using Library_Management_Project.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Library_Management_Project.Helper
{
    public class DataProvider
    {
        private static DataProvider instance = null;

        public QuanLiThuVienEntities DataBase { get; private set; }
        public ObservableCollection<DocGia> Readers { get; private set; }
        public ObservableCollection<Sach> Books { get; private set; }
        public ObservableCollection<LoaiDocGia> ReaderTypes { get; set; }
        public ObservableCollection<LoaiSach> BookType { get; set; }
        public QuyDinh Rule { get; set; }

        private DataProvider()
        {
            DataBase = new QuanLiThuVienEntities();
            Readers = new ObservableCollection<DocGia>(DataBase.DocGias.Where(reader => reader.BiAn == false));
            Books = new ObservableCollection<Sach>(DataBase.Saches.Where(book => book.BiAn == false));
            ReaderTypes = new ObservableCollection<LoaiDocGia>(DataBase.LoaiDocGias.Where(type => type.BiAn == false));
            BookType = new ObservableCollection<LoaiSach>(DataBase.LoaiSaches.Where(type => type.BiAn == false));
        }

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
        }



    }
}
