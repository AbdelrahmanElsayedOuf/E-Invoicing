using E_Invoicing.Application.Interfaces.Services;
using E_Invoicing.Application.Interfaces.UnitOfWork;
using E_Invoicing.Application.Services.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Services
{
    public class TripService : BaseService<Trip>, ITripService
    {
        public TripService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.TripRepository) { }
    }
}
