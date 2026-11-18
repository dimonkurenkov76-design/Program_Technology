using System;

namespace GuessTheNumber
{
    internal class Programms
    {
        static void Main(string[] args)
        {
            IUserInterface ui = new ConsoleUserInterface();
            GameStatistics statistics = new GameStatistics();

            do
            {
                string playerName = ui.GetPlayerName();
                GameSettings settings = ui.ChooseSettings();

                GameEngine engine = new GameEngine(ui, settings);
                SubscribeToEvents(engine, ui);

                int attempts = engine.PlayOneGame();
                var level = settings.Level;
                statistics.TrackGame(playerName, attempts, level);
            }
            while (
            
            ui.AgainGame()
            
            );
            
            ui.UserMessage(statistics.GetSummary());
            
            
        }
        private static void SubscribeToEvents(GameEngine engine, IUserInterface ui)
        {
            engine.OnGameStart += msg => ui.UserMessage(msg);
            engine.OnGuessEvaluated += (num, msg) => ui.UserMessage($"[{num}] {msg}");
            engine.OnGameWon += (attempts, msg) => ui.UserMessage($"{msg} Попыток: {attempts}");
            engine.OnGameLost += (attempts, msg) => ui.UserMessage(msg);

        }
    }
}
