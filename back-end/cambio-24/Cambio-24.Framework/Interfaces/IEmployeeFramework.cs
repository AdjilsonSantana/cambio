using Combio_24.Model.EmployeeModels;
using System;

namespace Cambio_24.Framework.Interfaces
{
    public interface IEmployeeFramework
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
