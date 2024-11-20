using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace rosa.HelpDesk.Server
{
  public partial class ModuleInitializer
  {
    /// <summary>
    /// Обработчик события инициализации
    /// </summary>
    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      HelpDesk.Requests.AccessRights.Grant(Roles.AllUsers, DefaultAccessRightsTypes.Read);
      InitializationLogger.Debug("Выданы права всем пользователям на просмотр всех обращений");
      Sungero.Docflow.PublicInitializationFunctions.Module.CreateDocumentType(
        "Договор на сопровождение",
        SupportContract.ClassTypeGuid,
        Sungero.Docflow.DocumentType.DocumentFlow.Contracts,
        true);
      // Cоздание ролей дежурный 1 и Дежурный 2
      CreateRoles();
    }

    /// <summary>
    /// 
    /// </summary>
    public void CreateRoles()
    {
      // Cоздание ролей дежурный 1 и Дежурный 2
      var role1 = Sungero.Docflow.Server.ModuleInitializer.CreateRole("Дежурный 1","Дежурит первую половину месяца", Constants.Module.Duty1HelpDesk);
      var role2 = Sungero.Docflow.Server.ModuleInitializer.CreateRole("Дежурный 2","Дежурит вторую половину месяца", Constants.Module.Duty2HelpDesk);
      HelpDesk.Requests.AccessRights.Grant(role1, DefaultAccessRightsTypes.FullAccess);
      HelpDesk.Requests.AccessRights.Grant(role2, DefaultAccessRightsTypes.FullAccess);
    }
  }
}
