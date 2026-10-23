using System;

namespace Bank;

/// <summary>
/// Представляет неизменяемую запись банковской транзакции (депозит или снятие).
/// </summary>
/// <param name="Amount">Сумма операции (положительная для депозита, отрицательная для снятия).</param>
/// <param name="Date">Дата и время проведения операции.</param>
/// <param name="Note">Текстовое примечание или обоснование платежа.</param>
public record Transaction(decimal Amount, DateTime Date, string Note);
