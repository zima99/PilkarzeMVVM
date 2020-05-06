using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PilkarzeMVVM.ViewModel.BaseClass
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] Propertiers)
        {
            if (PropertyChanged != null)
            {
                foreach (var property in Propertiers)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        }
    }
}
