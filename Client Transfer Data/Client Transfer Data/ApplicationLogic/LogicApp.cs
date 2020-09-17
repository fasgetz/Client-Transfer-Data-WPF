using Client_Transfer_Data.Model;
using Newtonsoft.Json;

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
        public User AuthorizeUser(string userName, ref ServiceFunctions.ServiceClient client)
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
