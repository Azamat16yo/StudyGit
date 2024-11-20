using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.Kurs815.Employee;

namespace rosa.Kurs815.Server
{
  partial class EmployeeFunctions
  {

    /// <summary>
    /// 
    /// </summary>       
    [Remote]
    public IQueryable<rosa.HelpDesk.IInternalRequest>  GetEmployeeRequests()
    {
      return rosa.HelpDesk.InternalRequests.GetAll().Where(r => r.Author == _obj);
    }

  }
}