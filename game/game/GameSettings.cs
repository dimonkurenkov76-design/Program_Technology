using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal enum DifficultyLevel{Easy, Medium, Hard, Custom}
    
    internal class GameSettings
    {
        public int MinNumb{get; }
        public int MaxNumb{get; }
        public int MaxAttempts{get; }

        public GameSettings(int minNumb, int maxNumb, int maxAttempts)
        {
            if(minNumb < maxNumb && maxAttempts > 0)
            {
                MinNumb = minNumb;
                MaxAttempts = maxAttempts;
                MaxNumb = maxNumb;
            }
            else throw new ArgumentException("Ошибка в записи значений");
        }

        public static GameSettings FromDifficultyLevel(DifficultyLevel level)
        {
            switch(level)
            {
                case DifficultyLevel.Easy:
                    return new GameSettings(1, 50, 10);
                case DifficultyLevel.Medium:
                    return new GameSettings(1,100,20);
                case DifficultyLevel.Hard:
                    return new GameSettings(1,300,30);
                default:
                    throw new ArgumentException("Указали не верный уровень сложноти!");
            }
        }
    }   
}
