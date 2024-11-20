using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.PracticalTask.Module.RecordManagementUI.Client
{
  partial class ModuleFunctions
  {
    /// <summary>
    /// Показывает все отчеты + отчет по удаленным документам
    /// </summary>
    [LocalizeFunction("ShowAllReportsFunctionName", "ShowAllReportsFunctionDescription")]
    public override void ShowAllReports()
    {
      var reports = Sungero.RecordManagement.Reports.GetAll()
        .Where(r => !(r is Sungero.RecordManagement.IAcquaintanceReport))
        .ToList();
      reports.Add(Sungero.Docflow.Reports.GetSkippedNumbersReport());
      reports.Add(SubscriptionModule.Reports.GetDocumentDeletionTasks());
      reports.AsEnumerable().Show(Sungero.RecordManagement.Resources.AllReportsTitle);
    }
  }
}