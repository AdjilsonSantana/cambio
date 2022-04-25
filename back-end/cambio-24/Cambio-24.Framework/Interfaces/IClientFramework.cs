using Combio_24.Model.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Framework.Interfaces
{
    public interface IClientFramework
    {
        ClientResponse Get();
        ClientResponse Get(long id);
        ClientResponse GetByDocNumberOrNif(string docOrnif);
        ClientResponse Insert(ClientRequest client);
        ClientResponse Update(ClientRequest client);
        ClientResponse Delete(long id);
    }
}
