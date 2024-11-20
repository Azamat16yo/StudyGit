using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.SubscriptionModule.Server
{
  public class ModuleJobs
  {

    /// <summary>
    /// 
    /// </summary>
    public virtual void SendSubscriptionNotification()
    {
      var subscribers = rosa.SubscriptionModule.Subscriptions.
        GetAll(s => PracticalTask.PublicFunctions.OfficialDocument.ChangedDate(s.Document).Between(Calendar.Today.AddWorkingDays(-1),Calendar.Today)). 
        Select(s => s.Subscriber);
      subscribers = subscribers.Distinct();
      foreach(var sub in subscribers)
      {
        var subscriptions = Subscriptions.GetAll(s => s.Subscriber.Equals(sub));
        var task = Sungero.Workflow.SimpleTasks.CreateWithNotices("Информация по подписке", Sungero.Company.Employees.As(sub) );
        string bufferText = String.Format("Измененные документы в период с {0} до {1}",Calendar.Today.AddWorkingDays(-1),Calendar.Today);
        foreach(var s in subscriptions)
          bufferText += String.Format("\nДокумент \"{0}\" был изменен {1};", s.Document.Name, PracticalTask.PublicFunctions.OfficialDocument.ChangedDate(s.Document));
        //if(subscriptions.Count() > 0) 
        bufferText = bufferText.Remove(bufferText.Length - 1, 1) + '.';
        task.ActiveText = bufferText;
        task.Start();
      }
      
//      foreach(var doc in changedDocuments)
//      {
//        var task = Sungero.Workflow.SimpleTasks.CreateWithNotices("Статистика по обращениям", subscribers);
//        task.ActiveText = String.Format("Документ {0} изменен {1}",doc.Name, doc.LastVersionChanged);
//        var subscribers = rosa.SubscriptionModule.Subscriptions.GetAll().Where(s => s.Document.Equals(doc));
//      }
//      var performer = Sungero.Company.Employees.GetAll().First();
//      var task = Sungero.Workflow.SimpleTasks.CreateWithNotices("Статистика по обращениям", performer);
//      
//      task.Start();
      
    }

  }
}