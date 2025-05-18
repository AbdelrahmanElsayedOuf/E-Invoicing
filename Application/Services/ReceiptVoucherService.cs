using AmazonTours.Application.Interfaces.Services;
using AmazonTours.Application.Interfaces.UnitOfWork;
using AmazonTours.Application.Services.Base;
using AmazonTours.Domain;
using Application.Interfaces.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Services
{
    public class ReceiptVoucherService : BaseService<RecieptVoucher>, IReceiptVoucherService
    {
        public ReceiptVoucherService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ReceiptVoucherRepository) { }
    }
}
    