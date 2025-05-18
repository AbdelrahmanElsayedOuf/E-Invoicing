using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AmazonTours.Application.Utilities.HelperClasses
{



    public class PageList<T>
    {
        public List<T> Items { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItemsCount { get; private set; }
        public int TotalPagesCount { get; private set; }
        public bool HasNextPage => PageNumber < TotalPagesCount;
        public bool HasPreviousPage => PageNumber > 1;

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItemsCount = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPagesCount = (int)Math.Ceiling(count / (double)pageSize);
        }

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
