using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace rosa.HelpDesk.Client
{
  public class ModuleFunctions
  {

    /// <summary>
    /// 
    /// </summary>
    [LocalizeFunction("Найти обращения организации")]
    public virtual void FindRequestByCompany()
    {
      // Вывести диалог выбора организации
      var dialog = Dialogs.CreateInputDialog("Выберите организацию");
      //
      var company = dialog.AddSelect("Организации", true, Sungero.Company.BusinessUnits.Null);
      if(dialog.Show() == DialogButtons.Ok)
      {
        Functions.Module.Remote.FindRequestByCompany(company.Value).Show();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [LocalizeFunction("Найти обращение по номеру")]
    public virtual void FindRequestByNumber()
    {
      // Вывести диалог ввода номера искомого обращения
      var dialog = Dialogs.CreateInputDialog("Введите номер обращения");
      // Добавить контрол для ввода номера
      var number = dialog.AddInteger("Номер обращения", true);
      // Показать карточку найденного обращения
      if(dialog.Show() ==DialogButtons.Ok)
      {
        var request = Functions.Module.Remote.FindRequestByNumber(number.Value);
        // Проверка на наличие нужного обращения
        if(request == null)
        {
          Dialogs.NotifyMessage("Обращения с введенным номером нет в системе");
        }
        else
        {
          request.Show();
        }
      }
    }

    /// <summary>
    /// Создать и отобразить карточку внешнего обращения
    /// </summary>
    [LocalizeFunction("Создать внешнее обращение", "Быстрое создание внешнего обращения")]
    public virtual void CreateExternalRequest()
    {
      Functions.Module.Remote.CreateExternalRequest().Show();
    }

    /// <summary>
    /// Создать и отобразить карточку внутреннего обращения.

    /// </summary>
    [LocalizeFunction("Создать внутреннее обращение", "Быстрое создание внутреннего обращения")]
    public virtual void CreateInternalRequest()
    {
      Functions.Module.Remote.CreateInternalRequest().Show();
    }

  }
}