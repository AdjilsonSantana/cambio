using Cambio_24.Models.Generics;
using System.Collections.Generic;

namespace Combio_24.Model.ClientModels
{
    public class ClientResponse : GenericResult
    {
        public ClientModel Client { get; set; }
        public IEnumerable<ClientModel> Clients { get; set; }
    }
}
