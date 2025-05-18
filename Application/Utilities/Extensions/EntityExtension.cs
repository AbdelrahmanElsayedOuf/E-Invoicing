using AmazonTours.Application.Utilities.HelperClasses;
using AutoMapper;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Utilities.Extensions
{
    public static class EntityExtension
    {
        public static T ToDTO<T>(this IEntity entity, IMapper mapper)
        {
            return mapper.Map<T>(entity);
        }

        public static PageList<TDto> ToDTOCollection<T, TDto>(this PageList<T> page, IMapper mapper)
    where T : IEntity
        {
            var dtoItems = page.Items.Select(item => mapper.Map<TDto>(item)).ToList();
            PageList<TDto> pageList = new PageList<TDto>(dtoItems, page.TotalItemsCount, page.PageNumber, page.PageSize);
            return pageList;
        }

    }
}
