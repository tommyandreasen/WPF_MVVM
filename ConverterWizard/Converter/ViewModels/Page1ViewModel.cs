using ConverterWizard.Converter.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConverterWizard.Converter.ViewModels
{
    class Page1ViewModel : ObservableObject
    {
        public RelayCommand SelectFileCommand { get; set; }

        private string _fileToConvert;

        public string FileToConvert
        {
            get { return _fileToConvert; }
            set
            {
                if (_fileToConvert != value)
                {
                    _fileToConvert = value;
                    OnPropertyChanged();
                }
            }
        }


        public Page1ViewModel()
        {
            SelectFileCommand = new RelayCommand(o =>
            {
                MessageBox.Show("Select a file to convert");
                FileToConvert = "test.docx";
            });
        }
    }
}
