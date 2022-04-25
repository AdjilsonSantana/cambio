namespace Cambio_24.Domain.Entities
{
    public class ClientEntity : Person
    {
        public string Email { get; set; }
        public long EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
    }
}
