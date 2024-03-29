﻿namespace GameMarket.Models.Page
{
    public class QueryOption
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public string OrderPropertyName { get; set; }
        public bool DescendingOrder { get; set; }

        public string SearchPropertyName { get; set; }
        public string SearchTerm { get; set; }
    }
}
