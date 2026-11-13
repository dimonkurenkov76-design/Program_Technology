using System;

namespace GuessTheNumber
{
    internal class Programms
    {
        static void Main(string[] args)
        {
            IUserInterface ui = new ConsoleUserInterface();
            GameStatistics statistics = new GameStatistics();
            GameSettings settings = ui.ChooseSettings();
            GameEngine engine = new GameEngine(ui, settings);
            
            engine.OnGameStart += msg => ui.UserMessage(msg);
            engine.OnGuessEvaluated += (num, msg) => ui.UserMessage($"[{num}] {msg}");
            engine.OnGameWon += (attempts, msg) => ui.UserMessage($"{msg} Попыток: {attempts}");
            engine.OnGameLost += (attempts, msg) => ui.UserMessage(msg);

            do
            {
                string playerName = ui.GetPlayerName();
                int attempts = engine.PlayOneGame();
                statistics.TrackGame(playerName, attempts);
            }
            while (ui.AgainGame());
            ui.UserMessage(statistics.GetSummary());
        }
    }
}
