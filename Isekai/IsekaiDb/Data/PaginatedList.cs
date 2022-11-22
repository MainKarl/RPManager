using IsekaiDb.Domain.Entities;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsekaiDb.Data.Enumerable;

namespace IsekaiDb.Data
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public string Search { get; private set; }
        public string SortOrder { get; private set; }
        public PassiveType PassiveType { get; private set; } // Passive Only

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        #region Passive
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, string search, PassiveType type) {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
            Search = search;
            PassiveType = type;
        }

        public static PaginatedList<Passive> CreateAsync(List<Passive> source, int count, int pageIndex, int pageSize, string search, PassiveType type) 
        { return new PaginatedList<Passive>(source, count, pageIndex, pageSize, search, type); }

        public int getType() 
        {
            switch (PassiveType)
            {
                case PassiveType.ALL:
                    return 0;
                case PassiveType.WEAPON:
                    return 1;
                case PassiveType.ARMOR:
                    return 2;
                case PassiveType.CLASS:
                    return 3;
                case PassiveType.SKILL:
                    return 4;
                case PassiveType.OTHER:
                    return 5;
                default:
                    return 0;

            }
	    }
    #endregion

    #region Normal
    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, string search, string sortOrder) {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
            Search = search;
            SortOrder = sortOrder;
        }



        public static PaginatedList<T> CreateAsync(List<T> source, int pageIndex, int pageSize, string search, string sortOrder) {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize, search, sortOrder);
        }
        #endregion
    }
}
