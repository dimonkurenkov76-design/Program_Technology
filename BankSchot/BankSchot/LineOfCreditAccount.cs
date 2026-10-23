using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;
/// <summary>
/// Представляет счет кредитной линии (кредитную карту) с возможностью ухода в минус до определенного лимита.
/// </summary>
public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса LineOfCreditAccount с заданным кредитным лимитом.
    /// </summary>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
    {

    }

}