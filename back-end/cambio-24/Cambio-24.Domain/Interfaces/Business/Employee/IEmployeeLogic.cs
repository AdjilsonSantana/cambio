using Combio_24.Model.EmployeeModels;

namespace Cambio_24.Domain.Interfaces.Business.Employee
{
    public interface IEmployeeLogic
    {
        EmployeeResponse Get();
        EmployeeResponse Get(long id);
        EmployeeResponse GetByUser(string user);
        EmployeeResponse GetByDocNumberOrNif(string docOrnif);
        EmployeeResponse Insert(EmployeeRequest employee, string role);
        EmployeeResponse Update(EmployeeRequest employee);
        EmployeeResponse Delete(long id);
    }
}
