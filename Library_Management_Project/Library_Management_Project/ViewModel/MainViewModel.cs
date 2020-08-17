using Library_Management_Project.Helper;
using System.Collections.ObjectModel;

namespace Library_Management_Project.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<NavigationItem> Items { get; set; } = new ObservableCollection<NavigationItem>();

        public MainViewModel()
        {
            Items.Add(new NavigationItem() { Title = "Quản Lý Đọc Giả", IconGlyph = "&#xe801", ViewContent = new ReaderViewModel() });
            Items.Add(new NavigationItem() { Title = "Quản Lý Sách", IconGlyph = "&#xe651", ViewContent = new BookViewModel() });
            Items.Add(new NavigationItem() { Title = "Quản Lý Mượn Sách", IconGlyph = "&#xe131", ViewContent = new BorrowReceiptViewModel()});
            Items.Add(new NavigationItem() { Title = "Quản Lý Trả Sách", IconGlyph = "&#xe130", ViewContent = new ReturningBookViewModel() });
            Items.Add(new NavigationItem() { Title = "Quy Định", IconGlyph = "&#xe401", ViewContent = new RuleViewModel() });
        }
    }
}
