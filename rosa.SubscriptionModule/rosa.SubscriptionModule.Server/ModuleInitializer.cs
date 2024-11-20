using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace rosa.SubscriptionModule.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      Subscriptions.AccessRights.Grant(Roles.AllUsers, DefaultAccessRightsTypes.Change);
      DocumentDeletions.AccessRights.Grant(Roles.AllUsers, DefaultAccessRightsTypes.Change);
      SendForDeletionTasks.AccessRights.Grant(Roles.AllUsers, DefaultAccessRightsTypes.Change);
      CreateDocumentDeletionStage();
      InitializationLogger.Debug("Выданы права всем пользователям на изменение подписок");
    }
    
    public static void CreateDocumentDeletionStage()
    {
      if (rosa.SubscriptionModule.DocumentDeletions.GetAll().Any())
        return;
      var stage = rosa.SubscriptionModule.DocumentDeletions.Create();
      stage.Name = "Удаление документа";
      stage.TimeoutInHours = 4;
      stage.Save();
    }
  }
}
