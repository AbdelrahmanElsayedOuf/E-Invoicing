﻿using AmazonTours.Application.Utilities.HelperClasses;
using Application.Interfaces.Repositories.Base;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Interfaces.Services.Base
{
    public interface IBaseService<T>: IBaseRepository<T> where T : class, IEntity, new()
    {

    }
}
