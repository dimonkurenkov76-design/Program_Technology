namespace Birds
{
    /// <summary>
    /// Класс Орла, который наследует Bird и IFlyable
    /// </summary>
    public class Eagle: Bird, IFlyable
    {
        /// <summary>
        /// Автосовйство размаха крыла
        /// </summary>
        public double WingSpan { get; set; }
        /// <summary>
        /// Вычисляемое свойство, что птица является хищной
        /// </summary>
        public bool IsPredator => true;
        /// <summary>
        /// Предает в автосвойство размах крыла. Перредает общие данные в базовый класс
        /// </summary>
        /// <param name="ringId">уникальный индетификатор кольца птицы</param>
        /// <param name="species">Вид птицы</param>
        /// <param name="weight">Вес птицы</param>
        /// <param name="wingSpan">Размах крыла в метрах</param>
        public Eagle(string ringId, string species, double weight, double wingSpan) :
            base(ringId, species, weight)
        { 
            WingSpan = wingSpan;
        }
        /// <summary>
        /// Метод, пения орла
        /// </summary>
        public override void Sing()
        {
            Console.WriteLine($"{Species} Sings: screech.");

        }
        /// <summary>
        /// Метод, полёта орла
        /// </summary>
        public void Fly()
        {
            Console.WriteLine($"{Species} soars high and flies.");
        }
        /// <summary>
        /// Метод вывода общей информаци о орле
        /// </summary>
        /// <returns>Возращени общей информации о орле</returns>
        public override string ToString()
        {
            return $"[Eagle] {Species}, {Weight} kg, habitat: {Habitat}\n" +
                $"weight in grams: {WeightInGrams}";
        }
    }

    
}

    

