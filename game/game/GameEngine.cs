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
        
        public GameEngine(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public int PlayOneGame()
        {
            int number = _rnd.Next(1,101);
            int counter = 0;

            _userInterface.UserMessage("Try guess number!");

            while (true)
            {
                counter++;
                int userNumber = _userInterface.UserNumber();

                if (userNumber > number)
                    _userInterface.UserMessage("Your number is greater");
                else if (userNumber < number)
                    _userInterface.UserMessage("Your number is less");
                else
                {
                    _userInterface.UserMessage("You win!!!!!!");
                    break;
                }
            }

            return counter;
        }
       
    }
}
