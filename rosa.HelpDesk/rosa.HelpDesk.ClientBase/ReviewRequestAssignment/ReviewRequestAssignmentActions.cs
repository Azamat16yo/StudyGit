using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.ReviewRequestAssignment;

namespace rosa.HelpDesk.Client
{
  partial class ReviewRequestAssignmentActions
  {
    public virtual void Review(Sungero.Workflow.Client.ExecuteResultActionArgs e)
    {
      
    }

    public virtual bool CanReview(Sungero.Workflow.Client.CanExecuteResultActionArgs e)
    {
      return true;
    }

    public virtual void Accepted(Sungero.Workflow.Client.ExecuteResultActionArgs e)
    {
      
    }

    public virtual bool CanAccepted(Sungero.Workflow.Client.CanExecuteResultActionArgs e)
    {
      return true;
    }

  }


}