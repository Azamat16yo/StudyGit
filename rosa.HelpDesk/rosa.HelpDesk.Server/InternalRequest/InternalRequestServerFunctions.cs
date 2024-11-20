using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.InternalRequest;

namespace rosa.HelpDesk.Server
{
  partial class InternalRequestFunctions
  {

    /// <summary>
    /// Получить все обращения текущего сотрудника
    /// </summary>
    /// <returns>Список обращений.</returns>
    [Remote(IsPure=true)]
    public IQueryable<IInternalRequest>GetEmployeeRequests()
    {
      // 
      return InternalRequests.GetAll(r => Equals(r.Author, _obj.Author));
    }

  }
}