using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Models.Generics
{
    public class GenericResult
    {

        public bool Success { get; set; } = false;
        //public string Code { get; set; }
        public string Message { get; set; }

    }

    public class GenericInput
    {
        public string TaxNumber { get; set; }
        public string DocNumber { get; set; }
    }

    public class GenericPagination
    {
        public int Page { get; set; }
        public int RecPerPage { get; set; }
    }

    public class GenericPaginationInput : GenericPagination
    {

    }

    public class GenericPaginationResult : GenericPagination
    {
        public int Records { get; set; }
        public int Pages { get; set; }
    }

}
