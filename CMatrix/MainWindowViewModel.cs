using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMatrix
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Implemantation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public MainWindowViewModel()
        {
            
        }

    }
}
