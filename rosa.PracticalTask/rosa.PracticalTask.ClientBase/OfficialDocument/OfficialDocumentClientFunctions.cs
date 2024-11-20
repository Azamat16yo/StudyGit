using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using rosa.PracticalTask.OfficialDocument;

namespace rosa.PracticalTask.Client
{
  partial class OfficialDocumentFunctions
  {
    /// <summary>
    /// 
    /// </summary>
    [Public]
    public DateTime? ChangedDate()
    {
      return _obj.LastVersionChanged ?? _obj.Modified;
    }

  }
}