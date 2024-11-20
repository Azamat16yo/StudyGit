using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.PracticalTask.OfficialDocument;

namespace rosa.PracticalTask.Client
{
  partial class OfficialDocumentActions
  {
    public override void DeleteEntity(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      base.DeleteEntity(e);
    }

    public override bool CanDeleteEntity(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return base.CanDeleteEntity(e);
    }

    public virtual void SendForDeletionrosa(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      PracticalTask.Functions.OfficialDocument.Remote.StartDeletionTask(_obj);
      e.CloseFormAfterAction = true;
      Dialogs.ShowMessage("Задача на удалениe документа была отправлена");
    }

    public virtual bool CanSendForDeletionrosa(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return !PracticalTask.Functions.OfficialDocument.Remote.IsDocumentInDeletionTask(_obj);
    }

    public virtual void Unsubscriberosa(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      rosa.PracticalTask.Functions.OfficialDocument.Remote.DeleteSubscription(_obj);
      e.CloseFormAfterAction = true;
      Dialogs.ShowMessage("Подписка отменена");
    }

    public virtual bool CanUnsubscriberosa(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return rosa.SubscriptionModule.PublicFunctions.Module.Remote.CheckSubscription(_obj, Sungero.Company.Employees.Current) && !_obj.State.IsInserted && !_obj.AccessRights.IsGranted(DefaultAccessRightsTypes.Forbidden, Sungero.Company.Employees.Current);
    }

    public virtual void Subscriberosa(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      rosa.PracticalTask.Functions.OfficialDocument.Remote.CreateSubscription(_obj);
      e.CloseFormAfterAction = true;
      Dialogs.ShowMessage("Подписка оформлена");
    }

    public virtual bool CanSubscriberosa(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return !rosa.SubscriptionModule.PublicFunctions.Module.Remote.CheckSubscription(_obj, Sungero.Company.Employees.Current) && !_obj.State.IsInserted && !_obj.AccessRights.IsGranted(DefaultAccessRightsTypes.Forbidden, Sungero.Company.Employees.Current); //
    }

  }

}