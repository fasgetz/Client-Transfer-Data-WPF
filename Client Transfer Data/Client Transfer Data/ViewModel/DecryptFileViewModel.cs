using Client_Transfer_Data.Model;
using Client_Transfer_Data.ViewModel.MVVM;
using EncryptionLibrary;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client_Transfer_Data.ViewModel
{
    public class DecryptFileViewModel : MainVM
    {


        public Action CloseAction;

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

        // Ключ дешифрования
        private string _KeyDecrypt;
        public string KeyDecrypt
        {
            get => _KeyDecrypt;
            set
            {
                _KeyDecrypt = value;
                OnPropertyChanged("KeyDecrypt");
            }
        }

        #endregion


        #region Команды

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

        // Дешифрование файла
        public DelegateCommand DecryptFile
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    try
                    {
                        // Если выбрали файл для дешифрования
                        if (!string.IsNullOrEmpty(FilePath) && !string.IsNullOrEmpty(KeyDecrypt))
                        {
                            string fileBytes = null;
                            // Считываем файл в string
                            using (StreamReader sr = new StreamReader(FilePath))
                            {
                                fileBytes = sr.ReadToEnd();
                                
                            }

                            // Дешифруем
                            var decrypt = EncryptionLib.Decrypt(fileBytes, KeyDecrypt);

                            // Получаем объект из JSON
                            SendFile myFile = JsonConvert.DeserializeObject<SendFile>(decrypt);


                            // Если файл получить дешифровать, то сохранить его
                            if (myFile != null)
                            {
                                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                                saveFileDialog1.FileName = myFile.FileName;
                                //string extensionFile = Path.GetExtension(myFile.FileName);

                                //saveFileDialog1.DefaultExt = extensionFile;
                                //saveFileDialog1.Filter = $"Тип файла |*{extensionFile}";

                                //saveFileDialog1.AddExtension = true;
                                
                                

                                if (saveFileDialog1.ShowDialog() == true)
                                {
                                    File.WriteAllBytes(saveFileDialog1.FileName, myFile.Data); // Requires System.IO

                                }
                            }

                            CloseAction();
                        }
                        else
                        {
                            MessageBox.Show("Выберите файл и введите ключ");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Введите правильный ключ дешифрования!\n{ex.Message}");
                    }

                });
            }
        }
        #endregion



    }
}
