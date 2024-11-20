using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.InternalRequest;

namespace rosa.HelpDesk.Client
{
  partial class InternalRequestActions
  {

    public virtual void EmployeeRequests(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      Functions.InternalRequest.Remote.GetEmployeeRequests(_obj).Show();
    }

    public virtual bool CanEmployeeRequests(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return true;
    }

  }

}