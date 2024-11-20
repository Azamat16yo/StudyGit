using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.SubscriptionModule.Server
{
  public class ModuleFunctions
  {

    /// <summary>
    /// Удалить все подписки на документ
    /// </summary>
    [Public, Remote]
    public void ClearAllSubscriptions(Sungero.Docflow.IOfficialDocument document)
    {
      var subscriptions = Subscriptions.GetAll(s => s.Document.Equals(document));
      foreach(var sub in subscriptions)
        Subscriptions.Delete(sub);
    }


    /// <summary>
    /// Проверить, есть ли у пользователя подписка на документ.
    /// </summary>
    /// <param name="document">Документ, на который будет проверяться подписка.</param>
    /// <param name="employee">Пользователь.</param>
    /// <returns>True, если подписка есть. Иначе - false.</returns>
    [Public, Remote]
    public bool CheckSubscription(Sungero.Docflow.IOfficialDocument document, Sungero.Company.IEmployee employee)
    {
      var CHTOTO_DEBUG = Subscriptions.GetAll().All(x => x.Document.Equals(document) && x.Subscriber.Equals(employee));
      var STATE_DEBUG = document.State.IsInserted;
      bool RESULT_DEBUG = Subscriptions.GetAll().All(x => x.Document.Equals(document) && x.Subscriber.Equals(employee)) && !document.State.IsInserted;
      return Subscriptions.GetAll().Any(x => x.Document.Equals(document) && x.Subscriber.Equals(employee));
    }

  }
}