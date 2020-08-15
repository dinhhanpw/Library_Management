using System;

namespace Library_Management_Project.Helper.Validator
{
    class ValidationHelper
    {
        public static string NotEmpty_ErrMessage = "không được để trống";
        public static string MustGreater_ErrMessage = "phải lớn hơn";
        public static string MustLess_ErrMessage = "phải nhỏ hơn";
        public static string MustLeast_ErrMessage = "phải có ít nhất";
        public static string InValid_ErrMessage = "không hợp lệ";
        public static string Range_ErrMessage(int from, int to)
        {
            return $"phải từ {from} đến {to}";
        }
        public static DateTime currentDate = DateTime.Now;
    }
}
