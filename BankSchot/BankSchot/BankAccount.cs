using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;

/// <summary>
/// Базовый класс, описывающий стандартный банковский счет.
/// </summary>
public class BankAccount
{
    private readonly decimal _minimumBalance;
    private static int s_accountNuberSeed = 1000000000;

    /// <summary>
    /// Возвращает уникальный номер счета.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Возвращает имя владельца счета.
    /// </summary>
    public string Owner { get; private set; }

    /// <summary>
    /// Динамически вычисляет текущий баланс счета на основе истории всех транзакций.
    /// </summary>
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    /// <summary>
    /// Инициализирует новый счет с нулевым минимальным балансом (без овердрафта).
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {
    }

    /// <summary>
    /// Инициализирует новый счет с указанием минимально допустимого баланса.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    /// <param name="minimumBalance">Минимальный баланс (лимит овердрафта).</param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Owner = name;
        Number = s_accountNuberSeed.ToString();
        s_accountNuberSeed++;
        _minimumBalance = minimumBalance;

        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.UtcNow, "Inital balance");
    }

    /// <summary>
    /// Вносит депозит (положительную сумму) на счет.
    /// </summary>
    /// <param name="amount">Сумма депозита.</param>
    /// <param name="date">Дата операции.</param>
    /// <param name="note">Примечание к операции.</param>
    /// <throws cref="ArgumentOutOfRangeException">Выбрасывается, если сумма меньше или равна нулю.</throws>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    /// <summary>
    /// Снимает деньги со счета с проверкой лимитов остатка.
    /// </summary>
    /// <param name="amount">Сумма снятия.</param>
    /// <param name="date">Дата операции.</param>
    /// <param name="note">Примечание к операции.</param>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);

        try
        {
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance < _minimumBalance);

            if (overdraftTransaction is not null)
                _allTransactions.Add(overdraftTransaction);
        }
        catch (InvalidOperationException)
        {
            _allTransactions.Remove(withdrawal);
            throw;
        }
    }

    /// <summary>
    /// Проверяет, нарушен ли минимальный баланс счета при снятии.
    /// </summary>
    /// <param name="isOverdrawn">Флаг выхода за рамки допустимого лимита.</param>
    /// <returns>Возвращает транзакцию штрафа/комиссии, если овердрафт разрешен наследником.</returns>
    /// <throws cref="InvalidOperationException">Выбрасывается, если на счету недостаточно средств.</throws>
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient rubles for this withdrawal");
        }
        else
        {
            return default;
        }
    }

    /// <summary>
    /// Формирует текстовую выписку по истории всех операций по счету.
    /// </summary>
    /// <returns>Строка с форматированной историей транзакций.</returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;
        report.Append("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" +
                $"{item.Date.ToShortDateString()}\t" +
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }

    /// <summary>
    /// Виртуальный метод обработки ежемесячных начислений (процентов, комиссий, бонусов).
    /// </summary>
    public virtual void PerformMonthAndTransactions()
    {
    }

    /// <summary>
    /// Возвращает текстовое представление счета с информацией о владельце, номере и балансе.
    /// </summary>
    /// <returns>Строка с описанием счета.</returns>
    public override string ToString()
    => $"Type:{GetType().Name}\tOwner:{Owner}\tNumber of account:{Number}\tBalance:{Balance}";
}
