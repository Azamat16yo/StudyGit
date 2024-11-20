using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.SubscriptionModule.SendForDeletionTask;

namespace rosa.SubscriptionModule.Server
{
  partial class SendForDeletionTaskFunctions
  {

    /// <summary>
    /// 
    /// </summary>     
    [Public,ExpressionElement("Получить всех подписчиков из документа")]
    public static IQueryable<Sungero.Company.IEmployee> GetSubscribers(PracticalTask.IOfficialDocument document)
    {
      var debug = SubscriptionModule.Subscriptions.GetAll().Where(s => s.Document.Equals(document)).Select(s => s.Subscriber);
      return SubscriptionModule.Subscriptions.GetAll().Where(s => s.Document.Equals(document)).Select(s => s.Subscriber);
    }

  }
}