using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.Kurs815.ApprovalFunctionStageBase;

namespace rosa.Kurs815.Server
{
  partial class ApprovalFunctionStageBaseFunctions
  {

    /// <summary>
    /// 
    /// </summary>
    public override Sungero.Docflow.Structures.ApprovalFunctionStageBase.ExecutionResult Execute( Sungero.Docflow.IApprovalTask approvalTask )
    {
      var result = base.Execute(approvalTask);
      var document = approvalTask.DocumentGroup.OfficialDocuments.SingleOrDefault();
      if (document == null)
        return this.GetErrorResult("Не найден документ.");
      if (document.DocumentKind == null)
        return this.GetErrorResult("Не найден вид документа.");
      try
      {
        document.LifeCycleState = _obj.ContractStatusrosa; 
        document.Save();
      }
      catch (Exception ex)
      {
        result = this.GetRetryResult(string.Empty);
      }
      return result;
      
    }

  }
}