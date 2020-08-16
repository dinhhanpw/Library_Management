using Library_Management_Project.Helper;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Library_Management_Project.Dialog
{
    /// <summary>
    /// Interaction logic for ExportReportDialog.xaml
    /// </summary>
    public partial class ExportReportDialog : Window
    {
        public ExportReportDialog()
        {
            InitializeComponent();
            BrowserCommand = new RelayCommand<Object>(obj => true, OnBrowser);
            AcceptCommand = new RelayCommand<Object>(CanAccept, OnAccept);
            this.DataContext = this;
        }
        public string FileName { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public ICommand BrowserCommand { get; set; }
        public ICommand AcceptCommand { get; set; }

        /// <summary>
        /// chọn đường dẫn để lưu tập tin báo cáo
        /// </summary>
        /// <param name="obj"></param>
        private void OnBrowser(object obj)
        {
            // tạo và hiển thị hộp thoại để chọn tập tin lưu
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            DialogResult result = dialog.ShowDialog();

            // lấy đường dẫn tâp tin
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FileName = dialog.FileName;
                fileNameTxtBlock.Text = FileName;
            }
        }

        /// <summary>
        /// kiểm tra sự hơp lệ của của thông tin để cho phép chấp nhận xuất báo cáo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAccept(object obj)
        {
            return !String.IsNullOrWhiteSpace(FileName)
                && From != null
                && To != null
                && From < To;
        }

        /// <summary>
        /// trả về chấp nhận xuất và đóng hộp thoại
        /// </summary>
        /// <param name="obj"></param>
        private void OnAccept(object obj)
        {
            DialogResult = true;
            Close();
        }


    }
}
