using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceFirstFull.Models
{
    public class RequestParameters
    {
        private int pageSize = 24;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > pageSize || value <= 0) ? pageSize : value;
            }
        }
        private int pageNumber = 1;
        public int PageNumber
        {
            get
            {
                return pageNumber;
            }
            set
            {
                pageNumber = (value <= 0) ? pageNumber : value;
            }
        }


        public string Genre { get; set; }
        public string Features { get; set; }
        public string Platform { get; set; }
        public SortState SortOrder { get; set; }
        public bool SearchForm { get; set; }
        public string SearchQuery { get; set; }


    }
}
