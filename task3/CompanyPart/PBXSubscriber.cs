using System.Collections.Generic;
using task3.CompanyPart.Documents.ContractPart;
using task3.CompanyPart.Interfaces;
using task3.PBXPart;

namespace task3.CompanyPart
{
    internal class PBXSubscriber : IPBXStatusable
    {

        public int Id { get; set; }


        /// <summary>
        /// Link to Contracts
        /// </summary>
        internal virtual IEnumerable<PBXContractModel> Contracts { get; set; }


        /// <summary>
        /// Link to Terminals
        /// </summary>
        internal virtual IEnumerable<TerminalBase> Terminals { get; set; }




        /*
        АБОНЕНТ ( = КЛИЕНТ + ДОГОВОР) – ЭТО СТАТУС ЧЕЛОВЕКА
        •	Имеет:
        o	Идентификационный номер (здесь = первому абонентскому номеру)
        o	Договор (один или несколько)
        o	Терминал с абонентским номером (по количеству Договоров)

        •	Функционал:
        o	Подключать / отключать терминал к порту АТС (Свойства Терминала вкл/откл)
        o	Осуществлять звонок другому Абоненту в пределах АТС (Свойства Терминала: вызов / отбой)
        o	Просмотреть Детализированный Отчет по звонкам сроком до предыдущего месяца
        o	Осуществлять фильтрацию Отчета по звонкам (Запрос у Оператора или подразумевает доступ к Базе данных?):
        	По дате звонка;
        	По сумме звонка
        	По абоненту звонка
        o	(?) Осуществлять звонок Компании – оператору АТС

        •	Генерируемые события:
        o	Заключение Договора
        o	Расторжение Договора

        •	Обрабатываемые события:

        */
    }
}
