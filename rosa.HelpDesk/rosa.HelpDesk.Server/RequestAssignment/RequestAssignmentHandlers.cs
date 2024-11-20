using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.RequestAssignment;

namespace rosa.HelpDesk
{
  partial class RequestAssignmentServerHandlers
  {

    public override void BeforeComplete(Sungero.Workflow.Server.BeforeCompleteEventArgs e)
    {
      if(_obj.Result.Equals(Result.Readdress) && _obj.NewResponsible == null)
        e.AddError("Для переадресации необходимо указать нового ответственного");
    }
  }

}