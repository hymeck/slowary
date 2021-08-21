using System;
using System.Collections.Generic;

namespace Slowary.Application.Common.Models
{
    public class PaginatedList<TData>
    {
        public int PageIndex { get; }
        public int TotalPageCount { get; }
        public int TotalItemsCount { get; }
        public IList<TData> Items { get; }

        public PaginatedList(IList<TData> items, int totalItemsCount, int pageIndex, int itemsPerPage)
        {
            PageIndex = pageIndex;
            TotalPageCount = (int)Math.Ceiling((double)totalItemsCount / itemsPerPage);
            TotalItemsCount = totalItemsCount;
            Items = items;
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPageCount;
    }
}