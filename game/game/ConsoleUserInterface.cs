namespace GuessTheNumber
{
    internal class ConsoleUserInterface : IUserInterface
    {
        /// <summary>
        /// Методо который выводит сообщение игрока
        /// </summary>
        /// <param name="message">Cjj,otybt buhjrf</param>
        public void UserMessage(string message) 
        {
            Console.WriteLine(message);   
        }
        /// <summary>
        /// Метод проверяющий число игрока
        /// </summary>
        /// <param name="min">миимальное значение числа</param>
        /// <param name="max">максимальное значение числа</param>
        /// <returns>завершает программу</returns>
        public int UserNumber(int min, int max) 
        {
            int userNumber;
            
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Input number from [{min},{max}]");
                
                if (int.TryParse(Console.ReadLine(), out userNumber)
                    && userNumber >= min && userNumber <= max)
                {
                    return userNumber;
                }

                Console.WriteLine("Invalid input!");
            }
            Console.WriteLine("Too many wrong attempts. Game over.");
            Environment.Exit(0);
            return 0;
        }
        /// <summary>
        /// Метод спрашивает будет ли играть снова
        /// </summary>
        /// <returns></returns>
        public bool AgainGame() 
        {
            Console.WriteLine("Do you want play game? (Y/N)");
            string num = Console.ReadLine();

            if (string.IsNullOrEmpty(num)) return false;
            char answer = num[0];   
            return answer == 'Y' || answer == 'y';
        }
        /// <summary>
        /// Метод по введению имени игрока
        /// </summary>
        /// <returns>Возращает имя игрока</returns>
        public string GetPlayerName()
        {
            Console.WriteLine("Введите ваше имя: ");
            while(true)
            {
                string? playerName = Console.ReadLine();
                if (!string.IsNullOrEmpty(playerName)) return playerName;
                else Console.WriteLine("Ввели не корректное имя. Имя не длжно быть пустым");
            }
        }
        /// <summary>
        /// Метод спрашивабщий на каком уровне сложности будет играть игрок
        /// </summary>
        /// <returns>Возращает выбраный уровень сложности</returns>
        /// <exception cref="ArgumentException">Выводит ошибку</exception>
        public GameSettings ChooseSettings()
        {
            while (true)
            {
                Console.WriteLine("Выбор уровня сложности: 1 - Easy; 2 - Medium; 3 - Hard; 4 - Custom");
                string? level = Console.ReadLine();
                if (int.TryParse(level, out int difLevel))
                {
                    try
                    {
                        switch (difLevel)
                        {
                            case 1:
                                return GameSettings.FromDifficultyLevel(DifficultyLevel.Easy);
                            case 2:
                                return GameSettings.FromDifficultyLevel(DifficultyLevel.Medium);
                            case 3:
                                return GameSettings.FromDifficultyLevel(DifficultyLevel.Hard);
                            case 4:
                                return CustomSetting();
                            default:
                                throw new ArgumentException("Не верное значение");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else Console.WriteLine("Не верное значение. Введите от 1 до 4");
            }
        }
        /// <summary>
        /// Метод по созданию собственного уровня
        /// </summary>
        /// <returns>Возращает введенные параметры для уровня</returns>
        private GameSettings CustomSetting()
        {
            while (true)
            {
                Console.WriteLine("Введите нижнию границу");
                string? border = Console.ReadLine();
                Console.WriteLine("Введите верхнюю границу");
                string? borderHight = Console.ReadLine();
                Console.WriteLine("Введите кол-во попыток");
                string? atemt = Console.ReadLine();
                var level = DifficultyLevel.Custom;
                if (int.TryParse(border, out int min) && int.TryParse(borderHight, out int max) && int.TryParse(atemt, out int attempt))
                {
                    try
                    {
                        return new GameSettings(min, max, attempt, level);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else Console.WriteLine("Введите только целые значения");
            }
        }
    }
}
