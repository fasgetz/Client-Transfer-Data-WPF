using Client_Transfer_Data.ApplicationLogic;
using Client_Transfer_Data.Model;
using Client_Transfer_Data.View;
using Client_Transfer_Data.ViewModel.MVVM;
using EncryptionLibrary;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client_Transfer_Data.ViewModel
{
    public class SendFileViewModel : MainVM
    {

        public Action<SendFile, string> CloseAction { get; set; }

        #region Свойства

        // Путь файла
        private string _FilePath;
        public string FilePath
        {
            get => _FilePath;
            set
            {
                _FilePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        // Ключ шифрования
        private string _KeyEncrypt;
        public string KeyEncrypt
        {
            get => _KeyEncrypt;
            set
            {
                _KeyEncrypt = value;
                OnPropertyChanged("KeyEncrypt");
            }
        }

        // Файл
        private SendFile file;

        // Логика приложения
        LogicApp logic;

        // Пользователь
        User user;


        public string FileName;


        #endregion


        public SendFileViewModel(LogicApp logic, User user)
        {
            this.logic = logic;
            this.user = user;
        }

        /// <summary>
        /// Команда на выбор файла
        /// </summary>
        public DelegateCommand ChooseFile
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    try
                    {
                        // Выбираем файл
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Multiselect = false;

                        if (openFileDialog.ShowDialog() == true)
                        {
                            FilePath = openFileDialog.FileName; // Путь файла
                            file = new SendFile();


                            file.Data = logic.GetFile(openFileDialog.FileName); // Массив байтов
                            file.Name = openFileDialog.FileName; // Путь
                            file.FileName = openFileDialog.SafeFileName; // Сохраняем имя файла

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        
                    }

                });
            }
        }

        /// <summary>
        /// Команда на выбор файла
        /// </summary>
        public DelegateCommand SendFile
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(KeyEncrypt) && file != null)
                        {



                            CloseAction(file, KeyEncrypt);
                        }
                        else
                        {
                            MessageBox.Show("Выберите файл и введите ключ шифрования!");
                        }
                        
                        //// Далее преобразуем в json

                        //// Далее отправляем json
                        //client.SendFile(serialized, myUser.ID);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {

                    }

                });
            }
        }
    }
}
