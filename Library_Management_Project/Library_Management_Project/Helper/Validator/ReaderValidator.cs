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

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleSet("Ten", () =>
            {
                RuleFor(reader => reader.Ten)
                .NotNull().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                .NotEmpty().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                .MinimumLength(MinLength).WithMessage($"Tên {ValidationHelper.MustLeast_ErrMessage} {MinLength} kí tự");
            });

            RuleSet("NgaySinh", () =>
            {
                RuleFor(reader => reader.NgaySinh)
                .NotNull().WithMessage($"Ngày sinh {ValidationHelper.NotEmpty_ErrMessage}")
                .Must((reader, val) =>
                {
                    if (val == null || reader.NgayLap == null) return false;

                    if (val <= reader.NgayLap.Value.AddYears(-18) && val > reader.NgayLap.Value.AddYears(-36)) return true;

                    return false;

                }).WithMessage($"Đọc giả phải {ValidationHelper.Range_ErrMessage(18, 35)} tuổi");
            });

            RuleSet("DiaChi", () =>
            {
                RuleFor(reader => reader.DiaChi)
                .NotNull().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                .NotEmpty().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                .MinimumLength(MinLength).WithMessage($"Địa chỉ {ValidationHelper.MustLeast_ErrMessage} {MinLength} kí tự");
            });

            RuleSet("Email", () =>
            {
                RuleFor(reader => reader.Email)
                .NotEmpty().WithMessage($"Email {ValidationHelper.NotEmpty_ErrMessage}")
                .EmailAddress().WithMessage("Email không hợp lệ");
            });

            RuleSet("NgayLap", () =>
            {
                RuleFor(reader => reader.NgayLap)
                .NotNull().WithMessage($"Ngày lập thẻ {ValidationHelper.NotEmpty_ErrMessage}")
                .Must((reader, val) =>
                {
                    if (val == null || reader.NgayLap == null) return false;

                    if (val >= reader.NgaySinh.Value.AddYears(18) && val < reader.NgaySinh.Value.AddYears(36)) return true;
                    return false;

                }).WithMessage($"Đọc giả phải {ValidationHelper.Range_ErrMessage(18, 35)} tuổi");
            });
        }
    }
}
