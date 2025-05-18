using AmazonTours.Application.Interfaces.Services;
using AmazonTours.Application.Interfaces.UnitOfWork;
using AmazonTours.Application.Services.Base;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Services
{
    public class ReservationService : BaseService<Reservation>, IReservationService
    {
        public ReservationService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ReservationRepository) { }
    }
}
