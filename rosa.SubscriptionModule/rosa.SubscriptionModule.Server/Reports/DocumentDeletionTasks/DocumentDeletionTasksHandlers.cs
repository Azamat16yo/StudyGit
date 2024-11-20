using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.SubscriptionModule
{
  partial class DocumentDeletionTasksServerHandlers
  {

    public virtual IQueryable<rosa.PracticalTask.IOfficialDocument> GetDocuments()
    {
      return rosa.PracticalTask.OfficialDocuments.GetAll();
    }

    public virtual IQueryable<rosa.SubscriptionModule.ISendForDeletionTask> GetTasks()
    {
      return rosa.SubscriptionModule.SendForDeletionTasks.GetAll().Where(t => t.Created >= DocumentDeletionTasks.StartDate && t.Created <= DocumentDeletionTasks.EndDate);
    }

  }
}