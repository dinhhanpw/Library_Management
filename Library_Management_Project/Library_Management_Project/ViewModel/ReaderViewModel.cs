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

                // thay đổi dữ liệu trên biểu mẫu thông tin đọc giả
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

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExportCommand { get; set; }

        //public ICommand Add_EditOnTableDataCommand { get; set; }



        public ReaderViewModel()
        {

            Readers = DataProvider.Instance.Readers;
            ReaderTypes = DataProvider.Instance.ReaderTypes;
            Holder = new DocGia();
            Holder.IdLoai = ReaderTypes[0].Id;
            AddCommand = new RelayCommand<DocGia>(CanAdd, OnAdd);
            EditCommand = new RelayCommand<DocGia>(CanEdit, OnEdit);
            DeleteCommand = new RelayCommand<DocGia>(CanDelete, OnDelete);
            ExportCommand = new RelayCommand<Object>(obj => true, OnExport);
            //Add_EditOnTableDataCommand = new RelayCommand<GridViewRowEditEndedEventArgs>(argument => argument != null, OnAdd_Edit);
            //Holder.LoaiDocGia = new LoaiDocGia();
        }

        /// <summary>
        /// xuất thông tin của đọc giả đến tập tin excel
        /// </summary>
        /// <param name="obj"></param>
        private void OnExport(object obj)
        {
            ExportReportDialog dialog = new ExportReportDialog();

            // mở hộp thoại để đặt các thông tin cần thiết
            if(dialog.ShowDialog() == true)
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                // lấy danh sách đọc giả theo tiêu chí đã chọn
                List<DocGia> readerList = 
                    new List<DocGia>(DataProvider.Instance.DataBase.DocGias.Where(reader => reader.NgayLap >= dialog.From && reader.NgayLap<=dialog.To));
                int row = 3;

                SetHeader(worksheet);
                
                // lưu thông tin đọc giả vào tập tin excel
                foreach (DocGia reader in readerList)
                {
                    SetValueOnRowWorksheet(worksheet, reader, row++);
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
            cell.PutValue("Họ Và Tên");
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue("Loại Đọc Giả");
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue("Ngày Sinh");
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue("Địa Chỉ");
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue("Email");
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue("Ngày Lập Thẻ");
        }

        /// <summary>
        /// lưu một đối tượng đọc giả vào một hàng của tập tin excel
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="reader"></param>
        /// <param name="row"></param>
        /// <param name="startCol"></param>
        private void SetValueOnRowWorksheet(Worksheet worksheet, DocGia reader, int row, char startCol = 'A')
        {

            Cell cell = worksheet.Cells[$"{(char)(startCol)}{row}"];
            cell.PutValue(row - 2);
            cell = worksheet.Cells[$"{(char)(startCol + 1)}{row}"];
            cell.PutValue(reader.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 2)}{row}"];
            cell.PutValue(reader.LoaiDocGia.Ten);
            cell = worksheet.Cells[$"{(char)(startCol + 3)}{row}"];
            cell.PutValue(reader.NgaySinh.Value.ToString("MM/dd/yyyy"));
            cell = worksheet.Cells[$"{(char)(startCol + 4)}{row}"];
            cell.PutValue(reader.DiaChi);
            cell = worksheet.Cells[$"{(char)(startCol + 5)}{row}"];
            cell.PutValue(reader.Email);
            cell = worksheet.Cells[$"{(char)(startCol + 6)}{row}"];
            cell.PutValue(reader.NgayLap.Value.ToString("MM/dd/yyyy"));
        }

        /// <summary>
        /// xóa thông tin đọc giả khỏi danh sách
        /// </summary>
        /// <param name="obj"></param>
        private void OnDelete(DocGia obj)
        {
            // hiển thị thông báo để xác nhận xóa
            MessageBoxResult result = 
                MessageBox.Show("Các thông tin liên quan đến đọc giả này cũng sẽ bị xóa, bạn có chấp nhận?", 
                "Xóa Thông Tin Đọc Giả", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                
                ObservableCollection<CTPhieuMuon> ReceiptInfos = DataProvider.Instance.BorrowReceiptInfos;
                ObservableCollection<PhieuMuon> Receipts = DataProvider.Instance.BorrowReceipts;

                
                foreach (PhieuMuon receipt in SelectedReader.PhieuMuons)
                {
                    foreach(CTPhieuMuon receiptInfo in receipt.CTPhieuMuons)
                    {
                        // ẩn thông tin sách mượn
                        receiptInfo.BiAn = true;
                        ReceiptInfos.Remove(receiptInfo);
                    }

                    // ẩn thông tin các phiếu mượn
                    receipt.BiAn = true;
                    Receipts.Remove(receipt);
                }

                // ẩn thông tin đọc giả
                SelectedReader.BiAn = true;
                Readers.Remove(SelectedReader);
                // lưu các thay đổi
                DataProvider.Instance.DataBase.SaveChanges();
                //foreach (CTPhieuMuon receiptInfo in ReceiptInfos)
                //{
                //    if (receiptInfo.IdDocGia == SelectedReader.Id)
                //    {
                //        receiptInfo.BiAn = true;
                //        Receipts.Remove(receiptInfo);
                //    }

                //}
            }
        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép xóa thông tin thẻ đọc giả
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanDelete(DocGia obj)
        {
            return SelectedReader != null;
        }

        /// <summary>
        /// chỉnh sửa thông tin thẻ đọc giả
        /// </summary>
        /// <param name="obj"></param>
        private void OnEdit(DocGia obj)
        {
            // sao chép thông tin
            SelectedReader.Ten = Holder.Ten;
            SelectedReader.NgaySinh = Holder.NgaySinh;
            SelectedReader.IdLoai = Holder.IdLoai;
            SelectedReader.NgayLap = Holder.NgayLap;
            SelectedReader.Email = Holder.Email;
            SelectedReader.DiaChi = Holder.DiaChi;

            DataProvider.Instance.DataBase.SaveChanges();

        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép chỉnh sửa thông tin thẻ đọc giả
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanEdit(DocGia obj)
        {
            return selectedReader != null && !Holder.HasErrors;
        }

        /// <summary>
        /// thêm và chỉnh sửa thông tin đọc giả trên bảng thông tin
        /// </summary>
        /// <param name="args"></param>
        //private void OnAdd_Edit(GridViewRowEditEndedEventArgs args)
        //{
        //    if (args.EditAction == GridViewEditAction.Cancel) return;

        //    if (args.EditOperationType == GridViewEditOperationType.Insert)
        //    {
        //        DocGia reader = args.NewData as DocGia;
        //        if(!CanAdd(reader))
        //        {
        //            Readers.Remove(reader);
        //            return;
        //        }
        //        DataProvider.Instance.DataBase.DocGias.Add(reader);
        //        DataProvider.Instance.DataBase.SaveChanges();
        //    }
        //    else if (args.EditOperationType == GridViewEditOperationType.Edit)
        //    {
        //        DataProvider.Instance.DataBase.SaveChanges();
        //    }
        //}

        /// <summary>
        /// thêm một đọc giả
        /// </summary>
        /// <param name="obj"></param>
        private void OnAdd(DocGia obj)
        {
            // tạo một đọc giả mới với thông tin từ biểu mẫu
            DocGia docGia = new DocGia()
            {
                Ten = Holder.Ten,
                IdLoai = Holder.IdLoai,
                NgaySinh = Holder.NgaySinh,
                DiaChi = Holder.DiaChi,
                Email = Holder.Email,
                NgayLap = Holder.NgayLap,
            };

            // thêm vào cơ sở dữ liệu
            DataProvider.Instance.DataBase.DocGias.Add(docGia);
            DataProvider.Instance.DataBase.SaveChanges();
            // thêm vào danh sách đọc giả
            Readers.Add(docGia);
        }

        /// <summary>
        /// kiểm tra những điều kiện để cho phép thêm thông tin thẻ đọc giả
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAdd(DocGia obj)
        {
            if (obj == null) return false;

            return !obj.HasErrors;
        }
    }
}
