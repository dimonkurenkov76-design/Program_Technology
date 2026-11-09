using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GuessTheNumber
{
    internal class GameStatistics
    {
        private int _minAttempts = 0;
        private int _maxAttempts = 0;
        private int _totalAttempts = 0;
        private int _gamesCount = 0;
        private readonly string _playerName;

        public void TrackGame(string playerName, int attempts)
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
            string text = $"Time: {DateTime.UtcNow}\tPlayer: {playerName}\tAttempt" +
                    $"; {attempts}\n";
            File.AppendAllText("leaderboard.txt", text);
        }
    }
}

