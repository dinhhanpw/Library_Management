using FluentValidation;
using Library_Management_Project.Model;
using System;

namespace Library_Management_Project.Helper.Validator
{
    public class BookValidator : AbstractValidator<Sach>
    {

        private int MinLength { get; set; } = 5;

        public BookValidator()
        {
            // đặt chế độ dừng khi phát hiện lỗi
            CascadeMode = CascadeMode.StopOnFirstFailure;

            // đặt các điều kiện cho tên sách
            RuleSet("Ten", () =>
            {
                RuleFor(book => book.Ten)
                // tên sách là thuộc tính bắt buộc
                .NotNull().WithMessage($"Tên sách {ValidationHelper.NotEmpty_ErrMessage}")
                // tên sách không được trống
                .NotEmpty().WithMessage($"Tên sách {ValidationHelper.NotEmpty_ErrMessage}")
                // đô dài tối thiểu của tên
                .MinimumLength(MinLength).WithMessage($"Tên sách {ValidationHelper.MustLeast_ErrMessage} {MinLength} kí tự");
            });

            // đặt điều kiện cho ngày nhập sách
            RuleSet("NgayNhap", () =>
            {
                RuleFor(book => book.NgayNhap)
                // ngày nhập là thuộc tính bắt buộc
                .NotNull().WithMessage($"Ngày nhập sách {ValidationHelper.NotEmpty_ErrMessage}")
                // khoảng ngày nhập hợp lệ
                .Must((book, val) =>
                {
                    // trong năm xuất bản đến ngày hiện tại
                    return val.Value.Year >= book.NamXB && val <= DateTime.Now;

                }).WithMessage($"Ngày nhập {ValidationHelper.InValid_ErrMessage}");
            });

            // đặt các điều kiện cho thuộc tính tác giả
            RuleSet("TacGia", () =>
            {
                RuleFor(book => book.TacGia)
                // tên tác giả là thuộc bắt buộc
                .NotNull().WithMessage($"Tên tác giả {ValidationHelper.NotEmpty_ErrMessage}")
                // tên tác giả không được trống
                .NotEmpty().WithMessage($"Tên tác giả {ValidationHelper.NotEmpty_ErrMessage}")
                // độ dài tối thiểu của tên tác giả
                .MinimumLength(MinLength).WithMessage($"Tên tác giả {ValidationHelper.MustLeast_ErrMessage} {MinLength} kí tự");
            });

            // đặt điều kiện cho thuộc tính nhà xuất bản
            RuleSet("NhaXB", () =>
            {
                RuleFor(book => book.NhaXB)
                // nhà xuất bản là thuộc tính bắt buộc
                .NotEmpty().WithMessage($"Nhà xuất bản {ValidationHelper.NotEmpty_ErrMessage}")
                // nhà xuất bản không được trống
                .NotEmpty().WithMessage($"Nhà xuất bản {ValidationHelper.NotEmpty_ErrMessage}")
                // độ dài tối thiểu của tên nhà xuất bản
                .MinimumLength(MinLength).WithMessage($"Tên nhà xuất bản {ValidationHelper.MustLeast_ErrMessage} {MinLength} kí tự");
            });

            // đặt điều kiện cho thuộc tính năm xuất bản
            RuleSet("NamXB", () =>
            {
                RuleFor(book => book.NamXB)
                // năm xuất bản là thuộc tính bắt buộc
                .NotNull().WithMessage($"Năm xuất bản {ValidationHelper.NotEmpty_ErrMessage}")
                // năm xuất bản phải nằm trong khoảng năm nhất định theo quy định
                .GreaterThanOrEqualTo(DateTime.Now.Year - 8).WithMessage($"Năm xuất bản {ValidationHelper.InValid_ErrMessage}");
            });

            // đặt điều kiện cho thuộc tính số lượng sách
            RuleSet("SoLuong", () =>
            {
                RuleFor(book => book.SoLuong)
                // số lượng sách là thuộc tính bắt buộc
                .NotNull().WithMessage($"Số lượng sách {ValidationHelper.NotEmpty_ErrMessage}")
                // số lượng sách phải ít nhất là 1
                .GreaterThan(0).WithMessage($"Số lượng sách {ValidationHelper.InValid_ErrMessage}");
            });

            // đặt điều kiện cho thuộc tính số giá sách
            RuleSet("Gia", () =>
            {
                RuleFor(book => book.Gia)
                // giá sách là thuộc tính bắt buộc
                .NotNull().WithMessage($"Giá sách {ValidationHelper.NotEmpty_ErrMessage}")
                // giá sách phải lớn hớn 500 đồng
                .GreaterThan(500).WithMessage($"Giá sách {ValidationHelper.InValid_ErrMessage}");
            });
        }
    }
}
