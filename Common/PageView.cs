using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class PageView<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PagesCount => (int) Math.Ceiling(Items.Count() * 1.0 / HARDCODED_SETTINGS.ITEMS_PER_PAGE);
        public int ItemsCount => Items.Count();
        public int CurrentPage { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < PagesCount;
    }
}