using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    /// <summary>
    /// Перечисление доступных уровней сложности игры.
    /// </summary>
    internal enum DifficultyLevel{Easy, Medium, Hard, Custom}
    /// <summary>
    /// Хранит параметры текущей игровой сессии (диапазон чисел, лимит попыток и выбранную сложность).
    /// </summary>
    internal class GameSettings
    {
        /// <summary>
        /// возращает минимальное значение диапозона
        /// </summary>
        public int MinNumb{get; }
        /// <summary>
        /// возращает максимальное значение диапозона
        /// </summary>
        public int MaxNumb{get; }
        /// <summary>
        /// возращает максимально кол-во попыток на угадывание
        /// </summary>
        public int MaxAttempts{get; }
        /// <summary>
        /// возращает уровень сложности игрока
        /// </summary>
        public DifficultyLevel Level{get; }
        /// <summary>
        /// Инициализирует новый экземпляр настроек игры с проверкой корректности границ.
        /// </summary>
        /// <param name="minNumb">минимальное значение в диапозоне</param>
        /// <param name="maxNumb">максимальное значение в диапозоне</param>
        /// <param name="maxAttempts">Максимальное кол-во попыток</param>
        /// <param name="level">уровень сложности</param>
        /// <exception cref="ArgumentException"></exception>
        public GameSettings(int minNumb, int maxNumb, int maxAttempts, DifficultyLevel level)
        {
            if (minNumb < maxNumb && maxAttempts > 0)
            {
                MinNumb = minNumb;
                MaxAttempts = maxAttempts;
                MaxNumb = maxNumb;
                Level = level;
            }
            else throw new ArgumentException("Ошибка в записи значений");
        }
        /// <summary>
        /// метод по выбору уровня сложности
        /// </summary>
        /// <param name="level">уровень сложности</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Выводит ошибку о некорекности выбора сложности</exception>
        public static GameSettings FromDifficultyLevel(DifficultyLevel level)
        {
            switch(level)
            {
                case DifficultyLevel.Easy:
                    return new GameSettings(1, 50, 15, DifficultyLevel.Easy);
                case DifficultyLevel.Medium:
                    return new GameSettings(1,100,30, DifficultyLevel.Medium);
                case DifficultyLevel.Hard:
                    return new GameSettings(1,300,100, DifficultyLevel.Hard);
                default:
                    throw new ArgumentException("Указали не верный уровень сложноти!");
            }
        }
    }   
}
