namespace GuessTheNumber
{
    internal class GameEngine
    {
        private readonly IUserInterface _userInterface;
        private readonly Random _rnd = new Random();
        private readonly GameSettings _settings;
        public event Action<string>? OnGameStart;
        public event Action<int, string>? OnGuessEvaluated;
        public event Action<int, string>? OnGameWon;
        public event Action<int, string>? OnGameLost;

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
            OnGameStart?.Invoke("Try guess number!");

            while (counter < _settings.MaxAttempts)
            {
                counter++;
                int userNumber = _userInterface.UserNumber(_settings.MinNumb, _settings.MaxNumb);

                if (userNumber > number)
                    OnGuessEvaluated?.Invoke(userNumber,"Your number is greater");
                else if (userNumber < number)
                    OnGuessEvaluated?.Invoke(userNumber,"Your number is less");
                else
                {
                    OnGameWon?.Invoke(counter, "You win!");
                    win = true;
                    break;
                }
            }
            if (win == false)
            {
                OnGameLost?.Invoke(counter, $"Колличество попыток закончилось :(\nВЫ ПРОИГРАЛИ!!!\nЗагаданное число: {number}");
            }


            return counter;
        }
    }
}
