using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.SubscriptionModule
{
  partial class DocumentDeletionTasksClientHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      var dialog = Dialogs.CreateInputDialog("Параметры диалога");
      var startDate = dialog.AddDate("Начальная дата", true, Calendar.Today.AddDays(-180));
      var endDate = dialog.AddDate("Конечная дата", true, Calendar.Today);
      
      if(dialog.Show() != DialogButtons.Ok)
        e.Cancel = true;
      
      DocumentDeletionTasks.EndDate = endDate.Value;
      DocumentDeletionTasks.StartDate = startDate.Value;
    }

  }
}