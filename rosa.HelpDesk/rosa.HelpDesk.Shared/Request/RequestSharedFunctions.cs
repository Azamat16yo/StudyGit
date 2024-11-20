using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.HelpDesk.Request;

namespace rosa.HelpDesk.Shared
{
  partial class RequestFunctions
  {

    /// <summary>
    /// 
    /// </summary>       
    public void GenerateTheme()
    {
      if(_obj.RequestKind != null && _obj.Number != null &&_obj.CreatedDate != null && _obj.Description != null)
        _obj.Name = String.Format("{0} № {1} от {2}: {3}",
                                  _obj.RequestKind, _obj.Number,
                                  _obj.CreatedDate, _obj.Description.Length>50 ?
                                  _obj.Description.Substring(0,50): _obj.Description);
    }

  }
}