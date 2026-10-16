namespace Birds
{
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// СОздаем список на основе базового класса
            /// </summary>    
            List<Bird> birds = new List<Bird>();
            /// <summary>
            /// Создаем обекты разных птиц и присваеваем им сразу значения
            /// </summary>
            Eagle goldenEagle = new Eagle("1", "Golden Eagle", 5.2, 2.3);
            Penguin emperorPenguin = new Penguin("2", "Emperor Penguin", 30, 22);
            Parrot Aratinga = new Parrot("3", "Aratinga Parrot", 1.5, 5);
            /// <summary>
            /// Добавляем объекты в список
            /// </summary>
            birds.Add(Aratinga);
            birds.Add(emperorPenguin);
            birds.Add(goldenEagle);
            /// <summary>
            /// Пробегаем по всему списку
            /// </summary>
            foreach (Bird bird in birds)
            {
                /// <summary>
                /// Выводим общую информацию по птицам
                /// </summary>
                Console.WriteLine(bird.ToString());
                /// <summary>
                /// Обращаемся к методу пения и выполняем его
                /// </summary>
                bird.Sing();
                /// <summary>
                /// Проверяем может ли птица летать
                /// </summary>
                if (bird is IFlyable flyable)
                {
                    flyable.Fly();
                    Console.WriteLine("\n.............................\n");
                }
                else 
                { 
                    Console.WriteLine($"{bird.Species} cannot fly.");
                    Console.WriteLine("\n.............................\n");
                }

            }
        }
    }
}
