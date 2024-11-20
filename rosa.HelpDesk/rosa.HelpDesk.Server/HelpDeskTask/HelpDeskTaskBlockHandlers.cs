using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;
using rosa.HelpDesk.HelpDeskTask;

namespace rosa.HelpDesk.Server.HelpDeskTaskBlocks
{
  partial class LifeCycleRequestHandlers
  {

    public virtual void LifeCycleRequestExecute()
    {
      // Настройка ЖЦ обращения
      var request = _obj.AttachmentGroupRequest.Requests.Single();
      request.LifeCycle = _block.LifeCycleEnum;
      // Заполнение поля Результат
      if(request.LifeCycle == HelpDesk.Request.LifeCycle.Closed && request.Result == null)
        request.Result = _obj.ActiveText;
    }
  }

  partial class RequestAssignmentHandlers
  {

    public virtual void RequestAssignmentCompleteAssignment(rosa.HelpDesk.IRequestAssignment assignment)
    {
      var request = _obj.AttachmentGroupRequest.Requests.Single();
      if(assignment.Result == rosa.HelpDesk.RequestAssignment.Result.Readdress)
      {
        request.Responsible = assignment.NewResponsible;
        request.AccessRights.Grant(assignment.NewResponsible, DefaultAccessRightsTypes.Change);
        request.Save();
      }
    }
  }

  partial class RequestCreatingHandlers
  {

    public virtual void RequestCreatingExecute()
    {
      // Создать внутреннее обращение
      var request = InternalRequests.Create();
      // Заполнить обязательные поля
      request.Description = _obj.ActiveText.Length > 150 ? _obj.ActiveText.Substring(0, 150) : _obj.ActiveText;
      request.Author = Sungero.Company.Employees.As(_obj.Author);
      request.RequestKind = _obj.RequestKind;
      request.Responsible = Sungero.Company.Employees.As(_block.Responsible);
      request.Name = String.Format("{0} : {1}",
                                   _obj.RequestKind, _obj.ActiveText.Length>50 ?
                                   _obj.ActiveText.Substring(0,50): _obj.ActiveText);
      request.LifeCycle = rosa.HelpDesk.Request.LifeCycle.InWork;
      _obj.AttachmentGroupRequest.Requests.Add(request);
    }
  }

}