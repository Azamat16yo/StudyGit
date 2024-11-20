using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;
using rosa.SubscriptionModule.SendForDeletionTask;

namespace rosa.SubscriptionModule.Server.SendForDeletionTaskBlocks
{
  partial class DeleteDocumentHandlers
  {

//    public virtual void DeleteDocumentExecute()
//    {
//      try
//      {
//        var document = _obj.DocumentsForDeletionAttachmentGroup.OfficialDocuments.FirstOrDefault();
//        Locks.Unlock(document);
//        document.Reg
//        _obj.DocumentsForDeletionAttachmentGroup.OfficialDocuments.Remove(document);
//        document.Versions.Clear();
//        var subjects = document.AccessRights.Current.Select(r => r.Recipient);
//        foreach (var subject in subjects)
//          document.AccessRights.RevokeAll(subject);
//        SubscriptionModule.Functions.Module.ClearAllSubscriptions(document);
//        document.AccessRights.Grant(Roles.AllUsers, DefaultAccessRightsTypes.Forbidden);
//      }
//      catch (Exception ex)
//      {
//        _obj.DeletionErrorText = "Ошибка при удалении документа:"ex.Message;
//      }
//    }
    public virtual void DeleteDocumentExecute()
    {
      try
      {
        var document = _obj.DocumentsForDeletionAttachmentGroup.OfficialDocuments.FirstOrDefault();
        _obj.DocumentsForDeletionAttachmentGroup.OfficialDocuments.Remove(document);
        document.Versions.Clear();
        var subjects = document.AccessRights.Current.Select(r => r.Recipient);
        foreach (var subject in subjects)
          document.AccessRights.RevokeAll(subject);
        SubscriptionModule.Functions.Module.ClearAllSubscriptions(document);
        document.AccessRights.Grant(Roles.AllUsers, DefaultAccessRightsTypes.Forbidden);
      }
      catch (Exception ex)
      {
        _obj.DeletionErrorText = "Ошибка при удалении: " + ex.Message;
      }
    }
  }

}