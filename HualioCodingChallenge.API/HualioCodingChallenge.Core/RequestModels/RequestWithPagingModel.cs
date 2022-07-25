using System;
using System.Collections.Generic;
using System.Text;

namespace HualioCodingChallenge.Core.RequestModels
{
    public class RequestWithPagingModel
    {
        public string SearchValue { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
