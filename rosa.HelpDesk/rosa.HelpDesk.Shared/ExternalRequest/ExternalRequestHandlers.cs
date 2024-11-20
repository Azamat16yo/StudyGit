using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.ExternalRequest;

namespace rosa.HelpDesk
{

  partial class ExternalRequestRequestNotesSharedCollectionHandlers
  {

    public override void RequestNotesAdded(Sungero.Domain.Shared.CollectionPropertyAddedEventArgs e)
    {
      _added.Employee = Sungero.Company.Employees.Current;
      base.RequestNotesAdded(e);
    }
  }

  partial class ExternalRequestSharedHandlers
  {

    public override void RequestNotesChanged(Sungero.Domain.Shared.CollectionPropertyChangedEventArgs e)
    {
      _obj.SumOfHours = _obj.RequestNotes.Sum(x => x.Hours);
      base.RequestNotesChanged(e);
    }

    public virtual void ContactChanged(rosa.HelpDesk.Shared.ExternalRequestContactChangedEventArgs e)
    {
      if(e.NewValue/*.Company*/ != null)
        _obj.Company = e.NewValue.Company;
    }

    public virtual void CompanyChanged(rosa.HelpDesk.Shared.ExternalRequestCompanyChangedEventArgs e)
    {
      if(!Equals(e.NewValue, e.OldValue) && _obj.Contact != null && e.OldValue != null)
      {
        _obj.Contact = null;
      }
    }
  }

}