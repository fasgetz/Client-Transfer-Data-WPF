using Client_Transfer_Data.ApplicationLogic;
using Client_Transfer_Data.Model;
using Client_Transfer_Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client_Transfer_Data.View
{
    /// <summary>
    /// Логика взаимодействия для SendFileWindow.xaml
    /// </summary>
    public partial class SendFileWindow : Window
    {
        public SendFile file; // Полученный файл
        public string KeyEncrypt; // Ключ шифрования

        private SendFileViewModel vm;
        


        public SendFileWindow(LogicApp logic, User user)
        {
            InitializeComponent();

            vm = new SendFileViewModel(logic, user);
            DataContext = vm;

            
            
            if (vm.CloseAction == null)
            {
                Action<SendFile, string> selector = (getFile, key) => 
                {
                    
                    DialogResult = true;
                    file = getFile; // Файл
                    KeyEncrypt = key; // Ключ
                    this.Close();
                };

                vm.CloseAction = selector;



                
            }
                


        }


    }
}
