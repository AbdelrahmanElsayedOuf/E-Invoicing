using Application.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Infrastructure.Repositories
{
    public class ReservatonRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservatonRepository(EInvocingDBContext context) : base(context) { }
    }
}
