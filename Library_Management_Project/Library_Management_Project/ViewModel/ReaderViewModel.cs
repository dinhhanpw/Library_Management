using Library_Management_Project.Helper;
using Library_Management_Project.Model;
using System.Collections.ObjectModel;

namespace Library_Management_Project.ViewModel
{
    public class ReaderViewModel
    {
        private DocGia selectedReader;

        public DocGia SelectedReader
        {
            get { return selectedReader; }
            set
            {
                if (value == null) return;
                selectedReader = value;

                Holder.Ten = SelectedReader.Ten;
                Holder.NgaySinh = SelectedReader.NgaySinh;
                Holder.IdLoai = SelectedReader.IdLoai;
                Holder.NgayLap = SelectedReader.NgayLap;
                Holder.Email = SelectedReader.Email;
                Holder.DiaChi = SelectedReader.DiaChi;

            }
        }
        public DocGia Holder { get; set; }
        public ObservableCollection<LoaiDocGia> ReaderTypes { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }



        public ReaderViewModel()
        {

            Readers = DataProvider.Instance.Readers;
            ReaderTypes = DataProvider.Instance.ReaderTypes;
            Holder = new DocGia();
            //Holder.LoaiDocGia = new LoaiDocGia();
        }
    }
}
