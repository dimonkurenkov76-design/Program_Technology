namespace GuessTheNumber
{
    internal class ConsoleUserInterface : IUserInterface
    {
        public void UserMessage(string message) 
        {
            Console.WriteLine(message);   
        }
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
        public bool AgainGame() 
        {
            Console.WriteLine("Do you want play game? (Y/N)");
            string num = Console.ReadLine();

            if (string.IsNullOrEmpty(num)) return false;
            char answer = num[0];   
            return answer == 'Y' || answer == 'y';
        }

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
                if (int.TryParse(border, out int min) && int.TryParse(borderHight, out int max) && int.TryParse(atemt, out int attempt))
                {
                    try
                    {
                        return new GameSettings(min, max, attempt);
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
