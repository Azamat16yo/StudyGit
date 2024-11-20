using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.HelpDesk.Server
{
  public class ModuleFunctions
  {

    /// <summary>
    /// 
    /// </summary>
    public void Function1()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [Public]
    public static int DayCount(DateTime? createdDate, DateTime? closedDate)
    {
      if(closedDate == null)
        return WorkingTime.GetDurationInWorkingDays(createdDate.Value, Calendar.Today);
      return WorkingTime.GetDurationInWorkingDays(createdDate.Value, closedDate.Value);
    }

    /// <summary>
    /// Поиск обращений организации
    /// </summary>
    [Remote]
    public IQueryable<IInternalRequest> FindRequestByCompany( Sungero.Company.IBusinessUnit company )
    {
      return InternalRequests.GetAll(x => x.Author.Department.BusinessUnit == company);
    }

    /// <summary>
    /// Поиск обращения по номеру
    /// </summary>
    /// <returns>Найденное обращение.</returns>
    [Remote]
    public static IRequest FindRequestByNumber(int? number)
    {
      return Requests.GetAll(x => x.Number == number).First();
    }

    /// <summary>
    /// Создать внешнее обращение
    /// </summary>
    /// <returns>Созданное внутреннее обращение.</returns>
    [Remote]
    public static IExternalRequest CreateExternalRequest()
    {
      return ExternalRequests.Create();
    }

    /// <summary>
    /// Создать внутреннее обращение
    /// </summary>
    //// <returns>Созданное внутреннее обращение.</returns>
    [Remote]
    public static IInternalRequest CreateInternalRequest()
    {
      return InternalRequests.Create();
    }

    
  }
}