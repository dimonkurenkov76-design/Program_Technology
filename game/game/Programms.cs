using System;

namespace GuessTheNumber
{
    /// <summary>
    /// точка входа в приложение
    /// </summary>
    internal class Programms
    {
        /// <summary>
        /// Главный метод запуска приложения.
        /// </summary>
        /// <param name="args"></param>
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
        /// <summary>
        /// подписывает пользовательский интерфейс на события в игре
        /// </summary>
        /// <param name="engine">экземпляр игрового движка</param>
        /// <param name="ui">пользовательсикй интерфейс</param>
        private static void SubscribeToEvents(GameEngine engine, IUserInterface ui)
        {
            engine.OnGameStart += msg => ui.UserMessage(msg);
            engine.OnGuessEvaluated += (num, msg) => ui.UserMessage($"[{num}] {msg}");
            engine.OnGameWon += (attempts, msg) => ui.UserMessage($"{msg} Попыток: {attempts}");
            engine.OnGameLost += (attempts, msg) => ui.UserMessage(msg);

        }
    }
}
