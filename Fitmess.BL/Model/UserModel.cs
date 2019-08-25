using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model {

    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class UserModel {

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public GenderModel Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set;}
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set;}

        public int Age{get { return DateTime.Now.Year - BirthDay.Year;}}

        /// <summary>
        /// Создаем пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDay">День рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public UserModel(string name, GenderModel gender, DateTime birthDay, double weight, double height) {
            #region Проверка условий
            Name = name ?? throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            Gender = gender ?? throw new ArgumentNullException("Пол пользователя не может быть путсым", nameof(gender));
            if (birthDay < DateTime.Parse("01.01.1910") || birthDay >= DateTime.Now) { throw new ArgumentNullException("Некоректная дата рождения", nameof(birthDay)); }
            if (weight <= 0) { throw new ArgumentNullException("Вес не можт быть меньше или равень НОЛЬ", nameof(weight)); }
            if (weight <= 0) { throw new ArgumentNullException("Рост пользователя не можт меньше или равен", nameof(height)); }
            #endregion
            BirthDay = birthDay;
            Weight = weight;
            Height = height;
        }

        public UserModel(string name) {

            Name = name ?? throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
        }

        public override string ToString() {
            return Name + " " + Age ;
        }
    }




}

