using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.Request;

namespace rosa.HelpDesk
{
  partial class RequestSharedHandlers
  {

    public virtual void DescriptionChanged(Sungero.Domain.Shared.StringPropertyChangedEventArgs e)
    {
      // обновить тему обращения
      Functions.Request.GenerateTheme(_obj);
    }

    public virtual void CreatedDateChanged(Sungero.Domain.Shared.DateTimePropertyChangedEventArgs e)
    {
      // обновить тему обращения
      Functions.Request.GenerateTheme(_obj);
    }

    public virtual void NumberChanged(Sungero.Domain.Shared.LongIntegerPropertyChangedEventArgs e)
    {
      // обновить тему обращения
      Functions.Request.GenerateTheme(_obj);
    }

    public virtual void RequestKindChanged(rosa.HelpDesk.Shared.RequestRequestKindChangedEventArgs e)
    {
      // обновить тему обращения
      Functions.Request.GenerateTheme(_obj);
    }

  }
}