using System;

namespace Bank;

/// <summary>
/// Представляет сберегательный счет, на остаток которого ежемесячно набегают проценты.
/// </summary>
public class InterestEarningAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса InterestEarningAccount.
    /// </summary>
    /// <param name="name">Имя владельца сберегательного счета.</param>
    /// <param name="initialBalance">Начальный баланс.</param>
    public InterestEarningAccount(string name, decimal initialBalance)
         : base(name, initialBalance)
    { }

    /// <summary>
    /// Начисляет 2% на остаток счета в конце месяца, если текущий баланс превышает 500 единиц.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}
