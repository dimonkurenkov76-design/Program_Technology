namespace GuessTheNumber
{
    internal interface IUserInterface
    {
        void UserMessage(string message);
        int UserNumber();
        bool AgainGame();
    }
}
