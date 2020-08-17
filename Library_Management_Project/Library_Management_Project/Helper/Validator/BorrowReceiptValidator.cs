using FluentValidation;
using Library_Management_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_Project.Helper.Validator
{
    class BorrowReceiptValidator : AbstractValidator<PhieuMuon>
    {

        public BorrowReceiptValidator()
        {
            // đặt chế độ dừng khi phát hiện lỗi
            CascadeMode = CascadeMode.StopOnFirstFailure;

            // đặt các điều kiện cho id đọc giả
            RuleSet("IdDocGia", () =>
            {
                RuleFor(receipt => receipt.IdDocGia)
                // id là thuộc tính bắt buộc
                .NotNull().WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}")
                .GreaterThan(0).WithMessage($"Tên {ValidationHelper.NotEmpty_ErrMessage}");


            });

            // đặt điều kiện cho ngày mượn sách
            RuleSet("NgayMuon", () =>
            {
                RuleFor(reader => reader.NgayMuon)
                // ngày mượn là thuộc tính bắt buộc
                .NotNull().WithMessage($"Ngày sinh {ValidationHelper.NotEmpty_ErrMessage}")
                // thẻ đọc giả phải còn hạn sử dụng
                .Must((receipt, val) =>
                {
                    if (receipt.DocGia == null) return false;

                    if (val >= receipt.DocGia.NgayLap && val <= receipt.DocGia.NgayLap.Value.AddMonths(6)) return true;

                    return false;

                }).WithMessage($"Thẻ đọc giả đã hết hạn");
            });

        }
    }
}
