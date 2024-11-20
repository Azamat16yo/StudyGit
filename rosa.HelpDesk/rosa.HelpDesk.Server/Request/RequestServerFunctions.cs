using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.Request;

namespace rosa.HelpDesk.Server
{
  partial class RequestFunctions
  {

    /// <summary>
    /// 
    /// </summary>
    [Remote]
    public IQueryable<IAddendumRequest> GetAddendumsForRequest()
    {
      return AddendumRequests.GetAll(x => x.Request.Equals(_obj));
    }

    /// <summary>
    /// 
    /// </summary>
    [Remote]
    public IAddendumRequest СreateAddendum()
    {
      var document = AddendumRequests.Create();
      document.Request = _obj;
      document.Name = string.Format("Приложение к обращению № {0}", _obj.Number);
      // Перед выдачей прав проверьте их отсутствие
      if(document.AccessRights.IsGranted(DefaultAccessRightsTypes.Change, _obj.Responsible))
        //При создании приложения к обращению выдайте права на изменение документа сотруднику, указанному в поле Ответственный в карточке обращения
      {
        document.AccessRights.Grant(_obj.Responsible, DefaultAccessRightsTypes.Change);
        document.AccessRights.Save();
      }
      return document;
    }
    

  }
}