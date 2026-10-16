namespace Birds
{
    /// <summary>
    /// Класс попугая
    /// </summary>
    public class Parrot : Bird, IFlyable
    {
        /// <summary>
        /// Автосвойство рзамер Словарного запаса
        /// </summary>
        public int VocabularySize { get; set; }
        /// <summary>
        /// Вычисляемое свойство, говорит ли попугай
        /// </summary>
        public bool CanTalk => VocabularySize > 0;
        /// <summary>
        /// Метод передающий в автосвойство Размер Словарного Запаса
        /// </summary>
        /// <param name="ringId">Кольцо птицы</param>
        /// <param name="species">Вид птицы</param>
        /// <param name="weight">Вес птицы</param>
        /// <param name="vocabularySize">Словарный запас</param>
        public Parrot(string ringId, string species, double weight, int vocabularySize) 
            : base(ringId, species, weight)
        {
            VocabularySize = vocabularySize;
        }
        /// <summary>
        /// Метод, полёта попугая
        /// </summary>
        public void Fly()
        {
            Console.WriteLine($"{Species} soars up, not very high, and flies along.");
        }
        /// <summary>
        /// Метод пения попугая
        /// </summary>
        public override void Sing()
        {
            Console.WriteLine($"{Species} sings: chirp");
        }
        /// <summary>
        /// Метод вывода общей информаци о попугае
        /// </summary>
        /// <returns>Возращени общей информации о попугае</returns>
        public override string ToString() 
        {
            return $"[Parrot] {Species}, {Weight} kg, habitat: {Habitat}\n" +
                $"weight in grams: {WeightInGrams}";
        }
    }
}
