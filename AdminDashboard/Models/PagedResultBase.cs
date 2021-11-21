using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Models
{
    public class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public string SearchKey { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCode { get; set; }
        public string DenomninationName { get; set; }
        public string DenomniationCode { get; set; }
        public int? DropDownFilter { get; set; }
        public int? DropDownFilter2 { get; set; }

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }
}
