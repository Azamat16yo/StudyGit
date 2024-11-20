using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.PracticalTask.Module.RecordManagementUI.Server
{

  partial class EmployeeSubscriptedDocumentsrosaFolderHandlers
  {

    //    public virtual IQueryable<Sungero.Docflow.IDocumentType> EmployeeSubscriptedDocumentsrosaDocumentTyperosaFiltering(IQueryable<Sungero.Docflow.IDocumentType> query)
    //    {
    //      if(_filter == null)
    //        return query;
    //      return query.Where(d => d.DocumentTypeGuid.Equals(_filter.DocumentTyperosa.DocumentTypeGuid));
    //    }

    public virtual IQueryable<Sungero.Docflow.IOfficialDocument> EmployeeSubscriptedDocumentsrosaDataQuery(IQueryable<Sungero.Docflow.IOfficialDocument> query)
    {
      query = query.Where(d => rosa.SubscriptionModule.Subscriptions.
                          GetAll().Where(s => s.Document.Equals(d) && s.Subscriber.Equals(Sungero.Company.Employees.Current)) != null);
      if (_filter == null)
        return query;
      
      if (_filter.DocumentKind != null)
        query = query.Where(d => d.DocumentKind.Equals(_filter.DocumentKind));
      
      if(_filter.LastWeek)
        query = query.Where(d => d.LastVersionChanged > Calendar.Today.AddDays(-7) || d.Modified > Calendar.Today.AddDays(-7));
      
      if(_filter.LastMonth)
        query = query.Where(d => d.LastVersionChanged > Calendar.Today.AddDays(-30) || d.Modified > Calendar.Today.AddDays(-30));
      
      if(_filter.Last90Days)
        query = query.Where(d => d.LastVersionChanged > Calendar.Today.AddDays(-90) || d.Modified > Calendar.Today.AddDays(-90));
      
      if(_filter.ManualPeriod)
      {
        if(_filter.DateRangeFrom != null)
          query = query.Where(d => d.LastVersionChanged > _filter.DateRangeFrom || d.Modified > _filter.DateRangeFrom);
        
        if(_filter.DateRangeTo != null)
          query = query.Where(d => d.LastVersionChanged < _filter.DateRangeTo || d.Modified < _filter.DateRangeFrom);
      }
      
      return query;
    }
  }


  partial class RecordManagementUIHandlers
  {
    
  }
}