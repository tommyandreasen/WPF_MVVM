using ConverterWizard.Converter.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ConverterWizard.Converter.ViewModels
{
    class Page1ViewModel : ObservableObject
    {
        public RelayCommand SelectFileCommand { get; set; }

        public ICommand PreviewDropCommand
        {
            get { return _PreviewDropCommand ?? (_PreviewDropCommand = new RelayCommand(HandlePreviewDrop)); }
            set
            {
                _PreviewDropCommand = value;
                OnPropertyChanged("PreviewDropCommand");
            }
        }
        private ICommand _PreviewDropCommand;

        private void HandlePreviewDrop(object inObject)
        {
            IDataObject ido = inObject as IDataObject;
            if (null == ido) return;

            // Get all the possible format
            string[] formats = ido.GetFormats();

            if (ido.GetData(DataFormats.FileDrop) is string[] files)
            {
                FileToConvert = files[0];
            }

            // Do what you need here based on the format passed in.
            // You will probably have a few options and you need to
            // decide an order of preference.
        }

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
                //FileToConvert = "test.docx";
            });
        }
    }
}
