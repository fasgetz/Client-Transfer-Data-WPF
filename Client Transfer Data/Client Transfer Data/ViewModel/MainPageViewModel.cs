using Client_Transfer_Data.Model;
using Client_Transfer_Data.MyService;
using Client_Transfer_Data.ViewModel.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client_Transfer_Data.ViewModel
{
    public class MainPageViewModel : MainVM
    {
        #region Свойства



        // Онлайн пользователи
        private User[] _onlineUsers;
        public User[] onlineUsers
        {
            get => _onlineUsers;
            set
            {
                _onlineUsers = value;
                OnPropertyChanged("onlineUsers");
            }
        }

        // Точка подключения к серверу
        private ServiceClient _client;
        
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

        #endregion

        public MainPageViewModel()
        {
            
        }
        
    }
}
