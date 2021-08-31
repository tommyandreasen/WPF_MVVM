using ConverterWizard.Converter.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterWizard.Converter.ViewModels
{
    class Page2ViewModel : ObservableObject
    {
        private string _downloadFileName;

        public string DownloadFileName
        {
            get { return _downloadFileName; }
            set
            {
                if (_downloadFileName != value)
                {
                    _downloadFileName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
