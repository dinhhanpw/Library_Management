using FluentValidation;
using Library_Management_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Project.Helper.Validator
{
    public class ReaderValidator : AbstractValidator<DocGia>
    {
        private int MinLength { get; set; } = 5;

        public ReaderValidator()
        {
            // đặt chế độ dừng khi phát hiện lỗi
            CascadeMode = CascadeMode.StopOnFirstFailure;

            // đặt các điều kiện cho tên đọc giả
            RuleSet("Ten", () =>
            {
                RuleFor(reader => reader.Ten)
                // tên là thuộc tính bắt buộc
                .NotNull().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                // tên không được trống
                .NotEmpty().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                // đô dài tối thiểu của tên
                .MinimumLength(MinLength).WithMessage($"Tên {ValidationHelper.MustLeast_ErrMessage} {MinLength} kí tự");
            });

            // đặt điều kiện cho ngày sinh đọc giả
            RuleSet("NgaySinh", () =>
            {
                RuleFor(reader => reader.NgaySinh)
                // ngày sinh là thuộc tính bắt buộc
                .NotNull().WithMessage($"Ngày sinh {ValidationHelper.NotEmpty_ErrMessage}")
                // độ tuổi cho phép lập thẻ theo quy định
                .Must((reader, val) =>
                {
                    if (reader.NgayLap == null) return false;

                    if (val <= reader.NgayLap.Value.AddYears(-18) && val > reader.NgayLap.Value.AddYears(-36)) return true;

                    return false;

                }).WithMessage($"Đọc giả phải {ValidationHelper.Range_ErrMessage(18, 35)} tuổi");
            });

            // đặt các điều kiện cho thuộc tính địa chỉ
            RuleSet("DiaChi", () =>
            {
                RuleFor(reader => reader.DiaChi)
                // địa chỉ là thuộc bắt buộc
                .NotNull().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                // địa chỉ không được trống
                .NotEmpty().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                // độ dài tối thiểu của địa chỉ
                .MinimumLength(MinLength).WithMessage($"Địa chỉ {ValidationHelper.MustLeast_ErrMessage} {MinLength} kí tự");
            });

            // đặt điều kiện cho thuộc tính email
            RuleSet("Email", () =>
            {
                RuleFor(reader => reader.Email)
                // email là thuộc tính bắt buộc
                .NotEmpty().WithMessage($"Email {ValidationHelper.NotEmpty_ErrMessage}")
                // kiểm tra email hợp lệ
                .EmailAddress().WithMessage("Email không hợp lệ");
            });

            // đặt điều kiện cho thuộc tính ngày lập thẻ
            RuleSet("NgayLap", () =>
            {
                RuleFor(reader => reader.NgayLap)
                // ngày lập là thuộc tính bắt buộc
                .NotNull().WithMessage($"Ngày lập thẻ {ValidationHelper.NotEmpty_ErrMessage}")
                // độ tuổi được phép lập thẻ phải theo quy định
                .Must((reader, val) =>
                {
                    if (reader.NgayLap == null) return false;

                    if (val >= reader.NgaySinh.Value.AddYears(18) && val < reader.NgaySinh.Value.AddYears(36)) return true;
                    return false;

                }).WithMessage($"Đọc giả phải {ValidationHelper.Range_ErrMessage(18, 35)} tuổi");
            });
        }
    }
}
