using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class GameEngine
    {
        private readonly IUserInterface _userInterface;
        private readonly Random _rnd = new Random();
        private readonly GameSettings _settings;
        
        public GameEngine(IUserInterface userInterface, GameSettings settings)
        {
            _userInterface = userInterface;
            _settings = settings;
        }
        public int PlayOneGame()
        {
            int minNumber = _settings.MinNumb;
            int maxNumber = _settings.MaxNumb + 1;
            int number = _rnd.Next(minNumber, maxNumber);
            int counter = 0;
            bool win = false;
            _userInterface.UserMessage("Try guess number!");

            while (counter < _settings.MaxAttempts)
            {
                counter++;
                int userNumber = _userInterface.UserNumber(_settings.MinNumb, _settings.MaxNumb);

                if (userNumber > number)
                    _userInterface.UserMessage("Your number is greater");
                else if (userNumber < number)
                    _userInterface.UserMessage("Your number is less");
                else
                {
                    _userInterface.UserMessage("You win!!!!!!");
                    win = true;
                    break;
                }
            }
            if (win == false)
            {
                _userInterface.UserMessage("Колличество попыток закончилось :(\nВЫ ПРОИГРАЛИ!!!");
            }

            return counter;
        }
       
    }
}
