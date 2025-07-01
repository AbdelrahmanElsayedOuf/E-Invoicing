using E_Invoicing.Application.Interfaces.Services;
using E_Invoicing.Application.Interfaces.UnitOfWork;
using E_Invoicing.Application.Services.Base;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Application.Services
{
    public class ReservationService : BaseService<Reservation>, IReservationService
    {
        public ReservationService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ReservationRepository) { }
    }
}
