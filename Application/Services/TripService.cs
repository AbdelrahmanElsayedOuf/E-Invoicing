using AmazonTours.Application.Interfaces.Services;
using AmazonTours.Application.Interfaces.UnitOfWork;
using AmazonTours.Application.Services.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Services
{
    public class TripService : BaseService<Trip>, ITripService
    {
        public TripService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.TripRepository) { }
    }
}
