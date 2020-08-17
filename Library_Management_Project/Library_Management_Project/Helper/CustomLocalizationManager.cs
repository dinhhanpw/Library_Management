using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace Library_Management_Project.Helper
{
    class CustomLocalizationManager : LocalizationManager
    {
        public override string GetStringOverride(string key)
        {
            switch(key)
            {
                case "GridViewAlwaysVisibleNewRow":
                    return "Thêm thông tin vào danh sách";
                case "GridViewClearFilter":
                    return "Hủy";
                case "GridViewFilter":
                    return "Lọc";
                case "GridViewFilterAnd":
                    return "Và";
                case "GridViewFilterContains":
                    return "Bao gồm";
                case "GridViewFilterDoesNotContain":
                    return "Không bao gồm";
                case "GridViewFilterEndsWith":
                    return "Kết thúc với";
                case "GridViewFilterIsContainedIn":
                    return "Thêm thông tin vào danh sách";
                case "GridViewFilterIsEqualTo":
                    return "Bằng";
                case "GridViewFilterIsGreaterThan":
                    return "Lớn hơn";
                case "GridViewFilterIsGreaterThanOrEqualTo":
                    return "Lớn hơn hoặc bằng";
                case "GridViewFilterIsNotContainedIn":
                    return "Thêm thông tin vào danh sách";
                case "GridViewFilterIsLessThan":
                    return "Bé hơn";
                case "GridViewFilterIsLessThanOrEqualTo":
                    return "Bé hơn hoặc bằng";
                case "GridViewFilterIsNotEqualTo":
                    return "Khác";
                case "GridViewFilterOr":
                    return "Hoặc";
                case "GridViewFilterShowRowsWithValueThat":
                    return "Tiêu chí";
                case "GridViewFilterStartsWith":
                    return "Bắt đầu với";
                case "GridViewFilterIsNull":
                    return "Rỗng";
                case "GridViewFilterIsNotNull":
                    return "Khác rỗng";
                case "GridViewFilterIsEmpty":
                    return "Trống";
                case "GridViewFilterIsNotEmpty":
                    return "Khác trống";
                case "GridViewGroupPanelText":
                    return "Thả tiêu đề cột vào đầy để gom nhóm";
                
            }
            return base.GetStringOverride(key);
        }
    }
}
