using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GuessTheNumber
{
    /// <summary>
    /// Отвечает за подсчёт статистики текущей сессии и сохранение результатов игроков в текстовый файл.
    /// </summary>
    internal class GameStatistics
    {
        /// <summary>
        /// минимальное значение попыток
        /// </summary>
        private int _minAttempts = 0;
        /// <summary>
        /// Максимальное значение попыток
        /// </summary>
        private int _maxAttempts = 0;
        /// <summary>
        /// общее значение попыток
        /// </summary>
        private int _totalAttempts = 0;
        /// <summary>
        /// Игр сыграно
        /// </summary>
        private int _gamesCount = 0;
        /// <summary>
        /// Имя игрока
        /// </summary>
        private readonly string _playerName;
        /// <summary>
        /// Метод записывающий каждую игру в файл
        /// </summary>
        /// <param name="playerName">Имя игрока</param>
        /// <param name="attempts">колличество попыток</param>
        /// <param name="level">Уровень сложности</param>
        public void TrackGame(string playerName, int attempts, DifficultyLevel level)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine($"Ввели не корректное имя!\nИмя не должно содеожать пробелы или null");
                return;
            }
            if (_minAttempts == 0 || attempts < _minAttempts) _minAttempts = attempts;
            if (attempts > _maxAttempts) _maxAttempts = attempts;

            _totalAttempts += attempts;
            _gamesCount++;
            string text = $"Time: {DateTime.UtcNow}\nPlayer: {playerName}\nAttempt" +
                    $"; {attempts}\nLevel: {level}\n\n";
            File.AppendAllText("leaderboard.txt", text);
        }
        /// <summary>
        /// Метод подсчета статистики
        /// </summary>
        /// <returns>Возращает строку со значениями</returns>
        public string GetSummary()
        {
            if (_gamesCount == 0) return "No game played yet.";
            double avg = (double)_totalAttempts / _gamesCount;
            return $"min = {_minAttempts} max = {_maxAttempts} avg = {avg:F2}";
        }
    }
}

