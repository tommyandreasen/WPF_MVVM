using ConverterWizard.Converter.Helpers;
using ConverterWizard.Converter.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConverterWizard.Converter.Commands
{
    class DownloadCommand : BaseCommand
    {
        private readonly Page2ViewModel _page2viewModel;

        public DownloadCommand(Page2ViewModel page2ViewModel)
        {
            _page2viewModel = page2ViewModel;
            _page2viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
                public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_page2viewModel.DownloadFileName);
        }
        public override void Execute(object parameter)
        {
            MessageBox.Show($"Downloading file {_page2viewModel.DownloadFileName}");
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecuteChanged();
        }
    }
}
