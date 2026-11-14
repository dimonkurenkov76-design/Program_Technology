namespace GuessTheNumber
{
    internal interface IUserInterface
    {
        void UserMessage(string message);
        int UserNumber(int min, int max);
        bool AgainGame();
        public GameSettings ChooseSettings();
    }
}
