using ConverterWizard.Converter.Commands;
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
    class ConverterViewModel : ObservableObject
    {
        public Page1ViewModel Page1Vm { get; set; }
        public Page2ViewModel Page2Vm { get; set; }
        public Page3ViewModel Page3Vm { get; set; }

        public RelayCommand NextCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public ICommand DownloadCommand { get; }

        private Object _currentView;

        public Object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Page { get; set; }

        public ConverterViewModel()
        {
            Page1Vm = new Page1ViewModel();
            Page2Vm = new Page2ViewModel();
            Page3Vm = new Page3ViewModel();

            DownloadCommand = new DownloadCommand(Page2Vm);

            CurrentView = Page1Vm;
            Page = 1;

            NextCommand = new RelayCommand(o =>
            {
                if (Page == 1)
                {
                    CurrentView = Page2Vm;
                    Page = 2;
                }
                else if (Page == 2)
                {
                    CurrentView = Page3Vm;
                    Page = 3;

                    MessageBox.Show(Page1Vm.FileToConvert);

                    Page2Vm.DownloadFileName = "test.pdf";
                }
            });

            BackCommand = new RelayCommand(o =>
            {
                if (Page == 1)
                {
                    CurrentView = Page1Vm;
                    Page = 1;
                }
                else if (Page == 3)
                {
                    CurrentView = Page2Vm;
                    Page = 2;
                }
            });

            CancelCommand = new RelayCommand(o =>
            {
                MessageBox.Show("Closing window");
            });
        }
    }
}
