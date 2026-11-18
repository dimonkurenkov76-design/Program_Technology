namespace GuessTheNumber
{
    /// <summary>
    /// определяет контракт взаимодействия между игровым движком и пользовательским интерфейсом
    /// </summary>
    internal interface IUserInterface
    {
        /// <summary>
        /// Методот выводит сообщение игрока
        /// </summary>
        /// <param name="message">сообщение игрока</param>
        void UserMessage(string message);
        /// <summary>
        /// Метод запращивает ввод числа
        /// </summary>
        /// <param name="min">минимальное значение</param>
        /// <param name="max">максимальное значение</param>
        /// <returns></returns>
        int UserNumber(int min, int max);
        /// <summary>
        /// Спрашивает у пользователя, хочет еще сыграть или нет?
        /// </summary>
        /// <returns></returns>
        bool AgainGame();
        /// <summary>
        /// Метод возражающий имя игрока
        /// </summary>
        /// <returns></returns>
        string GetPlayerName();
        /// <summary>
        /// Метод выбора сложности
        /// </summary>
        /// <returns></returns>
        public GameSettings ChooseSettings();
    }
}
