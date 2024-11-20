using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.Kurs815.Employee;

namespace rosa.Kurs815.Client
{
  partial class EmployeeActions
  {
    public virtual void EmpoyeeRequestsrosa(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      var requests = rosa.Kurs815.Functions.Employee.Remote.GetEmployeeRequests(_obj);
      var otladka = requests.Count();
      if(requests.Count() == 0)
      {
        Dialogs.NotifyMessage("У сотрудника нет обращений");
        return;
      }
      requests.Show();
    }

    public virtual bool CanEmpoyeeRequestsrosa(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return !_obj.State.IsInserted;
    }

  }

}