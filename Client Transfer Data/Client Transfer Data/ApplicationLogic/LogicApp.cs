using Client_Transfer_Data.Model;
using Client_Transfer_Data.MyService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client_Transfer_Data.ApplicationLogic
{
    class LogicApp
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
        public User AuthorizeUser(string userName, ref ServiceClient client)
        {
            User user = new User()
            {
                ID = client.ConnectOnServer(userName),
                Name = userName
            };

            return user;
        }

        #endregion
    }
}
