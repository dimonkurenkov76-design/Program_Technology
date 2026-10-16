using System;
using System.Collections.Generic;
using System.Text;

namespace Birds
{
    /// <summary>
    /// Класс Пингвин
    /// </summary>
    public class Penguin : Bird
    {
        /// <summary>
        /// Автосвойство Скорости плавания
        /// </summary>
        public double SwimSpeed { get; set; }
        /// <summary>
        /// Перевод из км/ч в м/с 
        /// </summary>
        public bool IsFastSwimmer => true;
        /// <summary>
        /// Метод передающий в автосвойство скорость плавания
        /// </summary>
        /// <param name="ringId">Кольцо птицы</param>
        /// <param name="species">Вид птицы</param>
        /// <param name="weight">Вес птицы</param>
        /// <param name="swimSpeed">Скорость плавания</param>
        public Penguin(string ringId, string species, double weight, double swimSpeed) 
            : base(ringId, species, weight)
        {
            SwimSpeed = swimSpeed;
        }
        /// <summary>
        /// Метод пения Пингвина
        /// </summary>
        public override void Sing()
        {
            Console.WriteLine($"{Species} sings: squawk");
        }
        /// <summary>
        /// Метод Плавания пингвина
        /// </summary>
        public void Swim()
        {
            Console.WriteLine($"{Species} swims fast and dives well.");
        }
        /// <summary>
        /// Метод вывода общей информаций о Пингвине
        /// </summary>
        /// <returns> Возращение строки </returns>
        public override string ToString()
        {
            return $"[Penguin] {Species}, {Weight} kg, habitat: {Habitat}\n" +
                $"weight in grams: {WeightInGrams}";
        }
    }
}
