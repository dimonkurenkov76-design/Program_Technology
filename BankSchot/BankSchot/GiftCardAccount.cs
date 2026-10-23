using System;

namespace Bank;

/// <summary>
/// Представляет подарочный счет с возможностью ежемесячного автопополнения.
/// </summary>
public class GiftCardAccount : BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;

    /// <summary>
    /// Инициализирует новый экземпляр класса GiftCardAccount.
    /// </summary>
    /// <param name="name">Имя владельца.</param>
    /// <param name="initialBalance">Начальная сумма подарка.</param>
    /// <param name="monthlyDeposit">Размер ежемесячного пополнения (по умолчанию 0).</param>
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
        : base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;

    /// <summary>
    /// Автоматически начисляет фиксированный ежемесячный подарочный депозит.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }

    /// <summary>
    /// Расширяет базовое описание информацией о ежемесячном подарочном пополнении.
    /// </summary>
    /// <returns>Строка с полным описанием подарочного счета.</returns>
    public override string ToString() => base.ToString() + $"\tMonthly deposit: {_monthlyDeposit}";
}
