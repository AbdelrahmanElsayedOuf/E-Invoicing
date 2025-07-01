using E_Invoicing.Application.Interfaces.UnitOfWork;
using E_Invoicing.Infrastructure.Repositories;
using Application.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Invoicing.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EInvocingDBContext _context;
        
        private CityRepository cityRepository;
        private ClientRepository clientRepository;
        private CountryRepository countryRepository;
        private HotelRepository hotelRepository;
        private InquiryRepository inquiryRepository;
        private ReservatonRepository reservatonRepository;
        private TripRepository tripRepository;
        private ReceiptVoucherRepository receiptVoucherRepository;
        
        public UnitOfWork(EInvocingDBContext context)
        {
            _context = context;
        }

        public ICityRepository CityRepository 
        { 
            get
            {
                if(cityRepository == null)
                    cityRepository = new CityRepository(_context);
                
                return cityRepository;
            }
        }
        public IClientRepository ClientRepository 
        { 
            get
            {
                if(clientRepository == null)
                    clientRepository = new ClientRepository(_context);

                return clientRepository;
            }
        }
        public ICountryRepository CountryRepository 
        { 
            get
            {
                if(countryRepository == null)
                    countryRepository = new CountryRepository(_context);

                return countryRepository;
            } 
        }
        public IHotelRepository HotelRepository
        {
            get
            {
                if(hotelRepository == null)
                    hotelRepository = new HotelRepository(_context);

                return hotelRepository;
            }
        }
        public IInquiryRepository InquiryRepository 
        {
            get
            {
                if(inquiryRepository == null)
                    inquiryRepository = new InquiryRepository(_context);
                
                return inquiryRepository;
            }
        }
        public IReservationRepository ReservationRepository 
        {
            get
            {
                if(reservatonRepository == null)
                    reservatonRepository = new ReservatonRepository(_context);

                return reservatonRepository;
            }
        }
        public ITripRepository TripRepository
        {
            get
            {
                if(tripRepository == null)
                    tripRepository = new TripRepository(_context);

                return tripRepository;
            }
        }

        public IRecieptVoucherRepository ReceiptVoucherRepository
        {
            get
            {
                if (receiptVoucherRepository == null)
                    receiptVoucherRepository = new ReceiptVoucherRepository(_context);

                return receiptVoucherRepository;
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();            
        }

        public void RollBack()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
