using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FitnessAPP.BL.Model;


namespace FitnessAPP.BL.Controller{

    class UserCondroller {

        public UserModel User { get; }

        public UserCondroller(UserModel user) {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public void Save() {

            var formater = new BinaryFormatter();

            using (var fs = new FileStream("user.data", FileMode.OpenOrCreate)) {

                formater.Serialize(fs, User);

            }
        }

        public UserModel Load()
        {

            var formater = new BinaryFormatter();

            using (var fs = new FileStream("user.data", FileMode.OpenOrCreate))
            {

                if (formater.Deserialize(fs) is UserModel user)
                {

                    return user;
                }
                else {
                    throw new FileLoadException("Не удалось получить пользователя", "user.data");
                }

                

            }
        }

    }
}
