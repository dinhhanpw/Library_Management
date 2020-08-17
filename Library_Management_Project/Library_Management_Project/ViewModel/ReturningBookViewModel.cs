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
    class ReturningBookViewModel : BindableBase
    {
        private PhieuMuon selectedReceipt;
        private DateTime? returningDate;

        public DateTime? ReturningDate
        {
            get { return returningDate; }
            set { SetBindableProperty(ref returningDate, value); }
        }

        public PhieuMuon SelectedReceipt
        {
            get { return selectedReceipt; }
            set
            {
                selectedReceipt = value;
                BorrowReceiptInfos.Clear();

                if (value == null)
                {
                    return;
                }
                // tải thông tin sách mượn trong phiếu mượn

                foreach (CTPhieuMuon receiptInfo in SelectedReceipt.CTPhieuMuons)
                {
                    if (!receiptInfo.Sach.BiAn.Value && receiptInfo.NgayTra == null)
                    {
                        CTPhieuMuon temp = new CTPhieuMuon();
                        temp.IdPhieuMuon = receiptInfo.IdPhieuMuon;
                        temp.IdSach = receiptInfo.IdSach;
                        temp.PhieuMuon = receiptInfo.PhieuMuon;
                        temp.Sach = receiptInfo.Sach;


                        BorrowReceiptInfos.Add(temp);
                    }
                }

            }
        }

        public ObservableCollection<PhieuMuon> BorrowReceipts { get; set; }
        public ObservableCollection<CTPhieuMuon> BorrowReceiptInfos { get; set; }
        public ObservableCollection<DocGia> Readers { get; set; }
        public ObservableCollection<Sach> Books { get; set; }

        public ICommand ReturnCommand { get; set; }





        public ReturningBookViewModel()
        {
            Readers = DataProvider.Instance.Readers;
            Books = DataProvider.Instance.Books;
            BorrowReceipts = DataProvider.Instance.BorrowReceipts;
            BorrowReceiptInfos = new ObservableCollection<CTPhieuMuon>();
            ReturnCommand = new RelayCommand<ObservableCollection<Object>>(CanReturn, OnReturn);


        }

        /// <summary>
        /// trả sách đã mượn
        /// </summary>
        /// <param name="objs"></param>
        private void OnReturn(ObservableCollection<Object> objs)
        {
            foreach (Object obj in objs)
            {
                CTPhieuMuon temp = obj as CTPhieuMuon;

                // tìm kiếm chi tiết phiếu mượn tương ứng
                CTPhieuMuon receiptInfo =
                    SelectedReceipt.CTPhieuMuons.FirstOrDefault(arg => arg.IdPhieuMuon == temp.IdPhieuMuon && arg.IdSach == temp.IdSach);

                // sao chép thông tin
                receiptInfo.NgayTra = temp.NgayTra = ReturningDate;
                receiptInfo.BiMat = temp.BiMat;
                receiptInfo.TienPhat = temp.TienPhat;
                
                // tăng số lượng sách nếu không bị mất sách
                if (!receiptInfo.BiMat.Value)
                    receiptInfo.Sach.SoLuong++;

            }

            DataProvider.Instance.DataBase.SaveChanges();
        }

        /// <summary>
        /// kiểm tra các điều kiện để cho phép trả sách
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        private bool CanReturn(ObservableCollection<Object> objs)
        {
            if (SelectedReceipt == null
                || ReturningDate == null
                || objs == null
                || SelectedReceipt.NgayMuon > ReturningDate
                || objs.Count < 1) return false;
            foreach (Object obj in objs)
            {
                CTPhieuMuon receipt = obj as CTPhieuMuon;
                if (receipt.NgayTra != null) return false;

                receipt.TienPhat = 0;
                int daySpan = ReturningDate.Value.Subtract(selectedReceipt.NgayMuon.Value).Days;
                if (daySpan > 5)
                {
                    receipt.TienPhat += (daySpan - 5) * 1000;

                }
                if (receipt.BiMat.Value)
                {
                    receipt.TienPhat += receipt.Sach.Gia;
                    receipt.TienPhat += 50000;
                }
            }

            return true;
        }
    }
}
