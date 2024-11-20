using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.Request;

namespace rosa.HelpDesk
{
  partial class RequestFilteringClientHandler
  {

    public override void ValidateFilterPanel(Sungero.Domain.Client.ValidateFilterPanelEventArgs e)
    {
      
    }
  }

  partial class RequestClientHandlers
  {

    public override void Refresh(Sungero.Presentation.FormRefreshEventArgs e)
    {
      if(_obj.LifeCycle == Request.LifeCycle.Closed && _obj.Result != null)
      {
        _obj.State.IsEnabled = false;
      }
      if(Equals(Sungero.Company.Employees.Current, _obj.Responsible))
      {
        //_obj.AccessRights.
      }
    }

  }
}