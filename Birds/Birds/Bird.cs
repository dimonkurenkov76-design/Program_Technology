using System;
using System.Collections.Generic;
using System.Text;

namespace Birds
{
    public abstract class Bird
    {
        /// <summary>
        /// Приватное поле, чтобы значения не изменялись из вне
        /// Принимает значение из Конструктора Птиц
        /// </summary>
        private string _ringId;
        /// <summary>
        /// Автосвойство Вид птицы
        /// Создаваемая скрытая пременная(свойство), которая дает прочитать, 
        /// получить значения из нее. Так же записать новые значения в нее
        /// </summary>
        public string Species { get; set; }
        /// <summary>
        /// Автосвойство Веса
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Вычисляемое совойство, переводя кг в граммы
        /// </summary>
        public double WeightInGrams => Weight * 1000;
        /// <summary>
        /// Присваевание значения для Леса 
        /// </summary>
        public Habitat Habitat { get; set; } = Habitat.Forest;
        /// <summary>
        /// Конструтор Птиц
        /// Принимате и записывает данные в приватное поле, 
        /// после чего очищает от пробелов и содержание переменное
        /// Записывает значение веса
        /// </summary>
        /// <param name="ringId"></param>
        /// <param name="species">Вид птицы</param>
        /// <param name="weight">Вес птицы</param>
        public Bird(string ringId, string species, double weight)
        {
            _ringId = ringId;
            Species = species.Trim();
            Weight = weight;
        }
        /// <summary>
        /// Кострутор принимает вид птицы, после передает 
        /// данные в первый конструктор, для дальнейшей работы
        /// </summary>
        /// <param name="species">Вид птицы</param>
        public Bird(string species) : this("N/A", species, 0) 
        { 
        
        }
        /// <summary>
        /// Абстрактный метод для пения птицы
        /// </summary>
        public abstract void Sing();
    }
}
