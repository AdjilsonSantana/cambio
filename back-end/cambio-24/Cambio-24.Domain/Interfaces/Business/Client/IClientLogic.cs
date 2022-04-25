using Combio_24.Model.ClientModels;

namespace Cambio_24.Domain.Interfaces.Business.Client
{
    public interface IClientLogic
    {
        ClientResponse Get();
        ClientResponse Get(long id);
        ClientResponse GetByDocNumberOrNif(string docOrnif);
        ClientResponse Insert(ClientRequest client);
        ClientResponse Update(ClientRequest client);
        ClientResponse Delete(long id);
    }
}
