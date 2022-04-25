using Cambio_24.Domain.Interfaces.Business.Employee;
using Cambio_24.Framework.Interfaces;
using Combio_24.Model.EmployeeModels;
using System;

namespace Cambio_24.Framework.Employee
{
    public class EmployeeFramework : IEmployeeFramework
    {
        private readonly IEmployeeLogic _employeeLogic;
        public EmployeeFramework(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        public EmployeeResponse Delete(long id)
        {
            return _employeeLogic.Delete(id);
        }

        public EmployeeResponse Get()
        {
            return _employeeLogic.Get();
        }

        public EmployeeResponse Get(long id)
        {
            return _employeeLogic.Get(id);
        }

        public EmployeeResponse GetByDocNumberOrNif(string docOrnif)
        {
            return _employeeLogic.GetByDocNumberOrNif(docOrnif);
        }

        public EmployeeResponse GetByUser(string user)
        {
            return _employeeLogic.GetByUser(user);
        }

        public EmployeeResponse Insert(EmployeeRequest employee, string role="")
        {
            return _employeeLogic.Insert(employee,role);
        }

        public EmployeeResponse Update(EmployeeRequest employee)
        {
            return _employeeLogic.Update(employee);
        }
    }
}
