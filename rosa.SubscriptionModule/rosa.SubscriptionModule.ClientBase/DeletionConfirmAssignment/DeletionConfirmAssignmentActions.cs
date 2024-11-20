using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.SubscriptionModule.DeletionConfirmAssignment;

namespace rosa.SubscriptionModule.Client
{
  partial class DeletionConfirmAssignmentActions
  {

    public virtual void ManagerApproval(Sungero.Workflow.Client.ExecuteResultActionArgs e)
    {
      
    }

    public virtual bool CanManagerApproval(Sungero.Workflow.Client.CanExecuteResultActionArgs e)
    {
      return _obj.ManagementApproval ?? false;
    }


    public virtual void Reject(Sungero.Workflow.Client.ExecuteResultActionArgs e)
    {
      SubscriptionModule.SendForDeletionTasks.As(_obj.MainTask).DeletionErrorText = "Удаление отклонено";
    }

    public virtual bool CanReject(Sungero.Workflow.Client.CanExecuteResultActionArgs e)
    {
      return true;
    }

    public virtual void Confirm(Sungero.Workflow.Client.ExecuteResultActionArgs e)
    {
      
    }

    public virtual bool CanConfirm(Sungero.Workflow.Client.CanExecuteResultActionArgs e)
    {
      return true;
    }

  }

}