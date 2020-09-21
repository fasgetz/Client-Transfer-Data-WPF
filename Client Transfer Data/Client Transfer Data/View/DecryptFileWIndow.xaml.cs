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
    /// Логика взаимодействия для DecryptFileWIndow.xaml
    /// </summary>
    public partial class DecryptFileWIndow : Window
    {
        private DecryptFileViewModel vm;


        public DecryptFileWIndow()
        {
            InitializeComponent();

            vm = new DecryptFileViewModel();
            DataContext = vm;

            if (vm.CloseAction == null)
            {
                Action selector = () =>
                {

                    DialogResult = true;
                    this.Close();
                };

                vm.CloseAction = selector;




            }
        }
    }
}
