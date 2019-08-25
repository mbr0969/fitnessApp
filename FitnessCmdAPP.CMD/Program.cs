using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitness.BL.Controller;

namespace FitnessCmdAPP.CMD {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Вас приветствует Fitness");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();


            var userController = new UserController(name);

            if (userController.IsNewUser) {
                Console.WriteLine("Введите пол пользователя");
                var gender = Console.ReadLine();
                var birthDay = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                userController.SetNewUserData(gender, birthDay, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime() {
            DateTime birthDay;
            while (true) {
                Console.WriteLine("Введите день рождения пользователя (dd.mm.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay)) {
                    break;
                } else {
                    Console.WriteLine("Неверный формат даты ");

                }
            }

            return birthDay;
        }
        private static double ParseDouble(string name) {

            while (true){
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value)) {
                    return value;
                }else {
                    Console.WriteLine($"Неверный формат {name}а: ");
                }
            }
        }
    }


   
}
