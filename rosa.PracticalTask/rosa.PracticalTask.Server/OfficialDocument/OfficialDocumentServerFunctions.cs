using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.PracticalTask.OfficialDocument;

namespace rosa.PracticalTask.Server
{
  partial class OfficialDocumentFunctions
  {
    /// <summary>
    /// 
    /// </summary>
    [Remote]
    public bool IsDocumentInDeletionTask()
    {
      if (SubscriptionModule.SendForDeletionTasks.GetAll().Count() == 0)
        return false;
      return SubscriptionModule.SendForDeletionTasks.GetAll().
        Where(t => t.Status == Sungero.Workflow.Task.Status.InProcess /*|| t.Status == Sungero.Workflow.Task.Status.Suspended*/).
        Where(t => t.AttachmentDetails.Any(att => att.AttachmentId.Value == _obj.Id)).Any();
    }

    /// <summary>
    /// Запустить задачу по удалению документа
    /// </summary>
    [Remote]
    public void StartDeletionTask()
    {
      var task = SubscriptionModule.SendForDeletionTasks.Create();
      task.Subject = "Прошу удалить документ \"" + _obj.Name +"\"";
      task.Author = Sungero.Company.Employees.Current;
      task.DocumentsForDeletionAttachmentGroup.OfficialDocuments.Add(_obj);
      task.DocumentId = _obj.Id;
      task.Start();
    }

    /// <summary>
    /// 
    /// </summary>
    [Remote]
    public void CreateSubscription()
    {
      var subscription = rosa.SubscriptionModule.Subscriptions.Create();
      subscription.Document = _obj;
      subscription.Subscriber = Sungero.Company.Employees.Current;
      subscription.Name = String.Format("Подписка на документ {0} от пользователя {1}", _obj.Name, Sungero.Company.Employees.Current.Name);
      subscription.Save();
    }

    /// <summary>
    /// 
    /// </summary>
    [Remote]
    public void DeleteSubscription()
    {
      var subscription = rosa.SubscriptionModule.Subscriptions.GetAll().
        Where(x => x.Subscriber.Equals(Sungero.Company.Employees.Current) && x.Document.Equals(_obj)).
        FirstOrDefault();
      if(subscription != null)
        rosa.SubscriptionModule.Subscriptions.Delete(subscription);
      return;
    }

  }
}