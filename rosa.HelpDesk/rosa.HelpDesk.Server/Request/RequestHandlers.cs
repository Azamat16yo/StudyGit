using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.Request;

namespace rosa.HelpDesk
{
  partial class RequestFilteringServerHandler<T>
  {

    public override IQueryable<T> Filtering(IQueryable<T> query, Sungero.Domain.FilteringEventArgs e)
    {
      if(_filter == null)
        return query;
      if(_filter.FlagInWork  || _filter.FlagOnControl || _filter.FlagClosed)
      {
        query = query.Where(r => (_filter.FlagInWork && r.LifeCycle.Equals(Request.LifeCycle.InWork)) ||
                           (_filter.FlagOnControl && r.LifeCycle.Equals(Request.LifeCycle.OnControl)) ||
                           (_filter.FlagClosed && r.LifeCycle.Equals(Request.LifeCycle.Closed)));
        
      }
      if(_filter.FlagInternalRequest || _filter.FlagExternalRequest || _filter.FlagAllRequests)
      {
        query = query.Where(r =>(_filter.FlagInternalRequest && rosa.HelpDesk.InternalRequests.Is(r)) ||
                            (_filter.FlagExternalRequest && rosa.HelpDesk.ExternalRequests.Is(r)));
      }
      return query;
    }
  }

  partial class RequestServerHandlers
  {

    public override void BeforeDelete(Sungero.Domain.BeforeDeleteEventArgs e)
    {
      //Фиксаця номера и темы обращения при его удалении, а также ID пользователя, удалившего запись
      Logger.Debug("Обращение {0} под номером {1} было удалено пользователем с ID = {2}",
                   _obj.Name, _obj.Number, Sungero.Company.Employees.Current);
    }

    public override void BeforeSave(Sungero.Domain.BeforeSaveEventArgs e)
    {
      if(_obj.LifeCycle == Request.LifeCycle.Closed && _obj.ClosedDate == null)
        _obj.ClosedDate = Calendar.Today;
      
      if (_obj.LifeCycle == LifeCycle.Closed && string.IsNullOrEmpty(_obj.Result))
      {
        e.AddError("Перед закрытием обращения заполните результат.");
        return;
      }
      
      // обновить тему обращения
      Functions.Request.GenerateTheme(_obj);
      
    }

    public override void Created(Sungero.Domain.CreatedEventArgs e)
    {
      _obj.Number = _obj.Id;
      _obj.Responsible = Sungero.Company.Employees.Current;
      _obj.LifeCycle = Request.LifeCycle.InWork;
      _obj.CreatedDate = Calendar.Today;
      // При создании поле заполняется текстом  «Тема обращения будет сформирована автоматически»
      _obj.Name = "Тема обращения будет сформирована автоматически";

    }
  }

}