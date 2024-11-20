using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace rosa.Kurs815.Module.Docflow.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      base.Initializing(e);
      CreateAutoNumberingOfMemoStage();
    }
    /// <summary>
    /// Создание записи нового типа сценария "Установка состояния договора".
    /// </summary>
    public static void CreateAutoNumberingOfMemoStage()
    {
      InitializationLogger.DebugFormat("Init: Create stage for automatic setting the contract status.");
      if (rosa.Kurs815.ApprovalFunctionStageBases.GetAll().Any())
        return;
      var stage = rosa.Kurs815.ApprovalFunctionStageBases.Create();
      stage.Name = "Установка состояния договора";
      stage.TimeoutInHours = 4;
      stage.Save();
    }
  }
}
