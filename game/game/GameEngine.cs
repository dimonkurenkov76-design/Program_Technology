namespace GuessTheNumber
{
    /// <summary>
    /// Игровой движок, инкапсулирующий логику загадывания числа, проверки ответов и генерации событий хода игры.    /// </summary>
    internal class GameEngine
    {
        private readonly IUserInterface _userInterface;
        private readonly Random _rnd = new Random();
        private readonly GameSettings _settings;
        /// <summary>
        /// событие возращаюшие при старте нового раунда
        /// </summary>
        public event Action<string>? OnGameStart;
        /// <summary>
        /// событие возращаюшие после проверки очередной попытки игрока
        /// </summary>
        public event Action<int, string>? OnGuessEvaluated;
        /// <summary>
        /// событие возращаюшие при победе игрока
        /// </summary>
        public event Action<int, string>? OnGameWon;
        /// <summary>
        /// событие возращаюшие при пройгреше
        /// </summary>
        public event Action<int, string>? OnGameLost;
        /// <summary>
        /// Инициализирует новый экземпляр игрового движка с внедрением зависимостей интерфейса и настроек.
        /// </summary>
        /// <param name="userInterface">абстракция игровогоинтерфейса</param>
        /// <param name="settings">Настройки раунда</param>
        public GameEngine(IUserInterface userInterface, GameSettings settings)
        {
            _userInterface = userInterface;
            _settings = settings;
        }
        /// <summary>
        /// запускает один раунд
        /// </summary>
        /// <returns>возращает кол-во попыток</returns>
        public int PlayOneGame()
        {
            int minNumber = _settings.MinNumb;
            int maxNumber = _settings.MaxNumb + 1;
            int number = _rnd.Next(minNumber, maxNumber);
            int counter = 0;
            bool win = false;
            OnGameStart?.Invoke("Число загадано! Попытайтесь отгадать");

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
