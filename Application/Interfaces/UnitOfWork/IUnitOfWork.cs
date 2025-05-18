using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        //Entities Repositories
        public ICityRepository CityRepository { get; }
        public IClientRepository ClientRepository { get;  }
        public ICountryRepository CountryRepository { get; }
        public IHotelRepository HotelRepository { get; }
        public IInquiryRepository InquiryRepository { get; }
        public IReservationRepository ReservationRepository { get; }
        public ITripRepository TripRepository { get; }
        public IRecieptVoucherRepository ReceiptVoucherRepository { get; }



        //Main UnitOfWork Methods
        public Task CommitAsync();
        public void RollBack();

    }
}
