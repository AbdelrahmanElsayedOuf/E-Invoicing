using E_Invoicing.Application.Interfaces.Services;
using E_Invoicing.Application.Interfaces.UnitOfWork;
using E_Invoicing.Application.Services.Base;
using E_Invoicing.Domain;
using Application.Interfaces.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Services
{
    public class ReceiptVoucherService : BaseService<RecieptVoucher>, IReceiptVoucherService
    {
        public ReceiptVoucherService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ReceiptVoucherRepository) { }
    }
}
    