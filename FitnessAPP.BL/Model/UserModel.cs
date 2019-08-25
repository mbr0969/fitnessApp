using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAPP.BL.Model {

    /// <summary>
    /// Клас пользователей
    /// </summary>
    [Serializable]
    class UserModel {
        #region Свйоства класса
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// пол пользователя
        /// </summary>
        public GenderModel Gender { get; }

        public DateTime BirthDay { get; }

        public double Weight { get; set; }
        public double Height { get; set; }
        #endregion

        public UserModel(string name, GenderModel gender, DateTime birthDay, double weight, double height) {
            #region Првоерка условий
            Name = name ?? throw new ArgumentNullException("Имя пользователя не пожт быть пустым",nameof(name));
            Gender = gender ?? throw new ArgumentNullException("Пол пользователя не можт быть путсым",nameof(gender));
            if (BirthDay < DateTime.Parse("01.01.1910") || BirthDay >= DateTime.Now) { throw new ArgumentNullException("Некоректная дата рождения", nameof(birthDay)); }
            if (Weight <= 0) { throw new ArgumentNullException("Вес не можт быть меньше или равень НОЛЬ", nameof(weight)); }
            if (Height <= 0) { throw new ArgumentNullException("Рост пользователя не можт меньше или равен", nameof(height)); }
            #endregion
            BirthDay = birthDay;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }




}
