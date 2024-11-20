using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.HelpDesk
{
  partial class RequestReportClientHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      var dialog = Dialogs.CreateInputDialog("Параметры отчета");
      var startDate = dialog.AddDate("Дата от", true, Calendar.Today.AddDays(-30));
      var endDate = dialog.AddDate("Дата по", true, Calendar.Today);
      
      if(dialog.Show() != DialogButtons.Ok)
        e.Cancel = true;
      
      RequestReport.startDate = startDate.Value;
      RequestReport.endDate = endDate.Value;
    }

  }
}