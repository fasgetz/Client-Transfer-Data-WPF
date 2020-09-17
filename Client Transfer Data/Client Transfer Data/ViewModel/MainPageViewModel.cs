using Client_Transfer_Data.ApplicationLogic;
using Client_Transfer_Data.Model;
using Client_Transfer_Data.ServiceFunctions;
using Client_Transfer_Data.ViewModel.MVVM;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Client_Transfer_Data.ViewModel
{
    public class MainPageViewModel : MainVM, IServiceCallback
    {
        #region Свойства

        // Логика приложения
        LogicApp logic;

        // Онлайн пользователи
        private ObservableCollection<User> _onlineUsers;
        public ObservableCollection<User> onlineUsers
        {
            get => _onlineUsers;
            set
            {
                _onlineUsers = value;
                OnPropertyChanged("onlineUsers");
            }
        }

        // Точка подключения к серверу
        private ServiceClient client;
        
        // Пользовательские данные
        private User _myUser;
        public User myUser
        {
            get => _myUser;
            set
            {
                _myUser = value;
                OnPropertyChanged("myUser");
            }
        }

        // Сообщения пользователей
        private ObservableCollection<string> _messages;
        public ObservableCollection<string> messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged("messages");
            }
        }

        // Имя пользователя
        private string _UserName;
        public string UserName
        {
            get => _UserName;
            set
            {
                _UserName = value;                
                OnPropertyChanged("UserName");
            }
        }

        // Айпи адрес
        private string _ipAddress;
        public string ipAddress
        {
            get => _ipAddress;
            set
            {
                _ipAddress = value;
                OnPropertyChanged("ipAddress");
            }
        }

        // Порт
        private string _port;
        public string port
        {
            get => _port;
            set
            {
                _port = value;
                OnPropertyChanged("port");
            }
        }

        // Отправляемое сообщение
        private string _messageEncrypt;
        public string messageEncrypt
        {
            get => _messageEncrypt;
            set
            {
                _messageEncrypt = value;
                OnPropertyChanged("messageEncrypt");
            }
        }
        #endregion

        public MainPageViewModel()
        {
            logic = LogicApp.GetInstance();
            ipAddress = "192.168.43.151";
            port = "8000";

        }

        #region Команды

        // Подключение к серверу
        public DelegateCommand Connect
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    try
                    {
                        // Если клиент не подключен, то подключить
                        if (client == null && myUser == null && !string.IsNullOrEmpty(ipAddress) && !string.IsNullOrEmpty(port))
                        {
                            // Подключение к серверу
                            client = new ServiceClient(new System.ServiceModel.InstanceContext(this),
                                "NetTcpBinding_IMyService",
                                $"net.tcp://{ipAddress}:{port}");

                            // Подключаемся
                            myUser = logic.AuthorizeUser(UserName, ref client);

                            // Если пользователь не авторизован
                            if (myUser == null)
                            {
                                // Получаем 

                            }
                            // Иначе, если пользователь авторизован получить юзеров
                            else
                            {
                                // Получаем подключенных пользователей
                                client.GetOnlineUsers();
                                messages = new ObservableCollection<string>();
                            }
                        }
                        else
                        {
                            client.Disconnect(myUser.ID);
                            onlineUsers = null;
                            client = null;
                            myUser = null;
                        }
                        

                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
            }
        }


        // Отправить сообщение
        public DelegateCommand SendMessage
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    try
                    {
                        // Если пользователь авторизован, то отправь сообщение
                        if (client != null && myUser != null)
                        {
                            client.SendMessage(messageEncrypt, myUser.ID);
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
            }
        }

        #endregion

        #region CallBack методы

        public void MsgCallback(string msg)
        {
            try
            {
                messages.Add(msg);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UserConnected(string json)
        {
            // Получаем пользователей
            onlineUsers = new ObservableCollection<User>(logic.GetOnlineUsers(json));
        }

        public bool HasOnline()
        {
            return true;
        }

        public void GetUsersOnline(string usersOnlineJson)
        {
            // Получаем пользователей
            onlineUsers = new ObservableCollection<User>(logic.GetOnlineUsers(usersOnlineJson));
        }

        #endregion

    }
}
