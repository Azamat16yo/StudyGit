using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.HelpDesk
{
  partial class RequestReportServerHandlers
  {

    public virtual IQueryable<rosa.HelpDesk.IRequest> GetRequest()
    {
      return rosa.HelpDesk.Requests.GetAll().Where(r => r.CreatedDate >= RequestReport.startDate).Where(r => r.CreatedDate <= RequestReport.endDate);
    }

  }
}