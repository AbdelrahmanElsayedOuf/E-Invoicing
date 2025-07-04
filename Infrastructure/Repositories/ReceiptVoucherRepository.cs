﻿using E_Invoicing.Domain;
using Application.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Infrastructure.Repositories
{
    public class ReceiptVoucherRepository : BaseRepository<RecieptVoucher>, IRecieptVoucherRepository
    {
        public ReceiptVoucherRepository(EInvocingDBContext context) : base(context) { }
    }
}
