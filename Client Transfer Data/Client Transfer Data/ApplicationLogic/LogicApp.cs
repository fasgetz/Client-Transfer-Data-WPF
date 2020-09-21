using Client_Transfer_Data.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Client_Transfer_Data.ApplicationLogic
{
    public class LogicApp
    {
        private static LogicApp instance;


        private LogicApp()
        {
            
        }

        public static LogicApp GetInstance()
        {
            if (instance == null)
                instance = new LogicApp();

            return instance;
        }



        #region Методы

        // Преобразование JSON в Models
        public User[] GetOnlineUsers(string jsonUsersResult)
        {
            return JsonConvert.DeserializeObject<User[]>(jsonUsersResult);
        }


        // Авторизация пользователя
        public User AuthorizeUser(string userName, ref ServiceFunctions.ServiceClient client)
        {
            User user = new User()
            {
                ID = client.ConnectOnServer(userName),
                Name = userName
            };

            return user;
        }

        /// <summary>
        /// Преобразовать файл в массив байтов
        /// </summary>
        /// <param name="fullPath">Путь</param>
        /// <returns>Массив байтов</returns>
        public byte[] GetFile(string fullPath)
        {
            return System.IO.File.ReadAllBytes(fullPath);
        }

        /// <summary>
        /// Преобразовать массив байтов в файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="byteArray">Массив байтов</param>
        /// <returns>Файл</returns>
        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        #endregion
    }
}
