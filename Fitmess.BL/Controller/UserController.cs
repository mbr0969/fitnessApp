using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller {

    /// <summary>
    /// Класс контроллер пользователя
    /// </summary>
   public class UserController {

       public List<UserModel> Users { get; }
        public UserModel CurrentUser { get; }
        public bool IsNewUser { get; } = false;



        /// <summary>
        /// Конструктор инициализации пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="genderName"></param>
        /// <param name="birthday"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public UserController(string userName) {

            if (string.IsNullOrWhiteSpace(userName)){
                throw new ArgumentException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null){
                CurrentUser = new UserModel(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }

        /// <summary>
        /// Созраняем пользвателя
        /// </summary>
        /// <returns></returns>
        public bool Save() {

            var forrmatter = new BinaryFormatter();

            using (var fs = new FileStream("users,dat", FileMode.OpenOrCreate))  {

                forrmatter.Serialize(fs, Users);
            }
           return true;
       }

        /// <summary>
        /// Загружаем список пользователей
        /// </summary>
        /// <returns></returns>
     private List<UserModel> GetUsersData() {
            var forrmatter = new BinaryFormatter();

            using (var fs = new FileStream("users,dat", FileMode.OpenOrCreate)) {

                if (fs.Length > 0 && forrmatter.Deserialize(fs) is List<UserModel> users){
                   return users;
                }
                else {
                    return new List<UserModel>();
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height =1){

            CurrentUser.Gender = new GenderModel(genderName);
            CurrentUser.BirthDay = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }

    }
}
