using Cambio_24.Models.Generics;
using System.Collections.Generic;

namespace Combio_24.Model.RatesModels
{
    public class RateResponse : GenericResult
    {
        public RateModel Rate { get; set; }
        public IEnumerable<RateModel> Rates { get; set; }
    }
}
