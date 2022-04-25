using Cambio_24.Domain.Interfaces.Business.Client;
using Cambio_24.Framework.Interfaces;
using Combio_24.Model.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Client
{
    public class ClientFramework : IClientFramework
    {
        private readonly IClientLogic _clientLogic;
        public ClientFramework(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }
        public ClientResponse Delete(long id)
        {
            return _clientLogic.Delete(id);
        }

        public ClientResponse Get()
        {
            return _clientLogic.Get();
        }

        public ClientResponse Get(long id)
        {
            return _clientLogic.Get(id);
        }

        public ClientResponse GetByDocNumberOrNif(string docOrnif)
        {
            return _clientLogic.GetByDocNumberOrNif(docOrnif);
        }

        public ClientResponse Insert(ClientRequest client)
        {
            return _clientLogic.Insert(client);
        }

        public ClientResponse Update(ClientRequest client)
        {
            return _clientLogic.Update(client);
        }
    }
}
