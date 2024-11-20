using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.SubscriptionModule.DocumentDeletion;

namespace rosa.SubscriptionModule.Server
{
  partial class DocumentDeletionFunctions
  {

    /// <summary>
    /// 
    /// </summary>
    public Sungero.Docflow.Structures.ApprovalFunctionStageBase.ExecutionResult Execute(rosa.SubscriptionModule.ISendForDeletionTask task)
    {
      var result = this.GetSuccessResult();
      try
      {
        var doc = task.DocumentsForDeletionAttachmentGroup.OfficialDocuments.FirstOrDefault();
//      task.DocumentsForDeletionAttachmentGroup.OfficialDocuments.Clear();
        task.DocumentsForDeletionAttachmentGroup.OfficialDocuments.Remove(doc);
//        foreach (var versions in doc.Versions)
//          doc.DeleteVersion(versions);
//        doc.AccessRights.RevokeAll(Roles.AllUsers);
//        Sungero.Docflow.OfficialDocuments.Delete(doc);
      }
      catch (Exception ex)
      {
        result = this.GetErrorResult(ex.Message);
        var notification= Sungero.Workflow.SimpleTasks.CreateWithNotices("Ошибка удаления документа", task.Author);
        notification.ActiveText = ex.Message;
        notification.Start();
      }
      
      return result;
    }

  }
}