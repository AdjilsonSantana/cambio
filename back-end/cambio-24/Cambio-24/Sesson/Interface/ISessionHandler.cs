namespace Cambio_24.WebApi.Sesson.Interface
{
    public interface ISessionHandler
    {
        void SetSessionKey(SessionOptions option, string value);
        string GetSessionKey(SessionOptions option);
    }
}
