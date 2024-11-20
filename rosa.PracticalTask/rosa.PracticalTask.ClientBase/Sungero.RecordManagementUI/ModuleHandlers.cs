using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.PracticalTask.Module.RecordManagementUI.Client
{

  partial class EmployeeSubscriptedDocumentsrosaFolderHandlers
  {

    public virtual void EmployeeSubscriptedDocumentsrosaValidateFilterPanel(Sungero.Domain.Client.ValidateFilterPanelEventArgs e)
    {
      if (_filter.ManualPeriod && _filter.Info.DateRangeFrom == null && _filter.Info.DateRangeTo == null)
        e.AddError("Заполните параметры, чтобы сократить число результатов поиска", _filter.Info.DateRangeFrom, _filter.Info.DateRangeTo);
    }
  }



}