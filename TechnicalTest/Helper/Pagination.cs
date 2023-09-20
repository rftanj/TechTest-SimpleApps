using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TechnicalTest.Helper
{
    public class PaginationHelper<T> : List<T>
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public PaginationHelper(
            List<T> items,
            int count,
            int pageIndex,
            int pageSize
            )
        {
            PageIndex = pageIndex;
            TotalPages =
                (int)Math.Ceiling(count / (double)pageIndex); //bulat ke atas
                                                              // (int)Math.Round(count/(double)pageIndex)); //bulat normal
                                                              // (int)Math.Floor(count/(double)pageIndex)); //bulat ke bawah


            this.AddRange(items);
        }

        public bool HasPrevPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static PaginationHelper<T> Create(
            List<T> source,
            int pageIndex,
            int pageSize
        )
        {
            var count = source.Count();
            var items = source
                        .Skip((pageIndex - 1) * pageSize)    //syntax Linq
                        .Take(pageSize)
                        .ToList();
            return new PaginationHelper<T>(items, count, pageIndex, pageSize);
        }
    }
}