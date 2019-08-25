using System;

namespace Fitness.BL.Model {

    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class GenderModel {
        public string Name { get; }

        /// <summary>
        /// Устанавливаем пол 
        /// </summary>
        /// <param name="name"></param>
        public GenderModel(string name){

            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }

            Name = name;
        }

        public override string ToString() {
            return Name;
        }
    }
}