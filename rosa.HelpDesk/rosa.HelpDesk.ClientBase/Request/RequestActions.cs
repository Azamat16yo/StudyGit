using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.Request;

namespace rosa.HelpDesk.Client
{
  partial class RequestActions
  {
    public virtual void ShowAddendums(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      Functions.Request.Remote.GetAddendumsForRequest(_obj).Show();
    }

    public virtual bool CanShowAddendums(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      //Действие «Приложения к обращению» сделать недоступным, если обращение только что создано и не сохранено.
      return !_obj.State.IsInserted;
    }

    public virtual void CreateAddendum(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      // Создать документ и показать его карточку
      Functions.Request.Remote.СreateAddendum(_obj).Show();
      
      
    }

    public virtual bool CanCreateAddendum(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      //Действие «Создать приложение к обращению» сделать недоступным, если обращение только что создано и не сохранено.
      return !_obj.State.IsInserted;
    }

    public virtual void OpenRequest(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      //при нажатии состояние свойства Жизненный цикл обращения должно измениться с «Закрыто» на «В работе»
      _obj.LifeCycle = Request.LifeCycle.InWork;
      // Сделать поля карточки доступными для изменения.
      _obj.State.IsEnabled = true;
      // обнулить дату закрытия
      _obj.ClosedDate = null;
    }

    public virtual bool CanOpenRequest(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      //действие должно быть доступно только для закрытых обращений
      return _obj.LifeCycle.Equals(LifeCycle.Closed) && !_obj.State.IsChanged;
    }

  }

}